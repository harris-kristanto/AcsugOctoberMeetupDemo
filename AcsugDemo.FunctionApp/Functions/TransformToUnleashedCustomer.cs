using System.Net.Http;
using System.Threading.Tasks;
using AcsugDemo.FunctionApp.BusinessLogics;
using AcsugDemo.FunctionApp.Contracts.Salesforce;
using AcsugDemo.FunctionApp.Contracts.Unleashed;
using AcsugDemo.FunctionApp.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace AcsugDemo.FunctionApp.Functions
{
    public static class TransformToUnleashedCustomer
    {
        [FunctionName("TransformToUnleashedCustomer")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            var duplicateCheckService = new DuplicateCheckService();
            var requestBody = await req.Content.ReadAsStringAsync();
            var salesforceAccount = JsonConvert.DeserializeObject<Account>(requestBody);

            //Transform SF Account to Unleashed Customer
            Customer unleashedCustomer = TransformLogic.TransformToUnleashedCustomer(salesforceAccount);

            unleashedCustomer.IsMessageDuplicated = duplicateCheckService.PerformDuplicateCheck("Customer", salesforceAccount.AccountNumber);

            return new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(unleashedCustomer, Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            }), System.Text.Encoding.UTF8, "application/json")
            };
        }
    }
}
