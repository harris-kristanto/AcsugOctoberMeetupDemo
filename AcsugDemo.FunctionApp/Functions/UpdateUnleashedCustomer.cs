using System;
using System.Net.Http;
using System.Threading.Tasks;
using AcsugDemo.FunctionApp.Contracts.Unleashed;
using AcsugDemo.FunctionApp.Services;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace AcsugDemo.FunctionApp.Functions
{
    public static class UpdateUnleashedCustomer
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public class UnleashedConfig
        {
            internal string ApiId { get; set; }
            internal string ApiKey { get; set; }
        }

        public static async Task<UnleashedConfig> GetUnleashedConfigAsync()
        {
            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            var kvClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback), httpClient);
            var config = new UnleashedConfig()
            {
                ApiId = Environment.GetEnvironmentVariable("UnleashedApiId"),
                ApiKey = (await kvClient.GetSecretAsync(Environment.GetEnvironmentVariable("UnleashedApiKey-SecretUrl"))).Value
            };

            return config;
        }

        [FunctionName("UpdateUnleashedCustomer")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {

            var unleashedConfig = GetUnleashedConfigAsync().Result;
            string requestBody = await req.Content.ReadAsStringAsync();
            var unleashedCustomer = JsonConvert.DeserializeObject<Customer>(requestBody);
            var unleashedService = new UnleashedService(unleashedConfig.ApiId, unleashedConfig.ApiKey);

            return await unleashedService.CreateNewCustomer(unleashedCustomer);

        }
    }
}
