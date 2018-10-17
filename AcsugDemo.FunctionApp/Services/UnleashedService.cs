using AcsugDemo.FunctionApp.Contracts.Unleashed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AcsugDemo.FunctionApp.Services
{
    public class UnleashedService
    {

        public string ApiId { get; set; }
        public string ApiKey { get; set; }
        public HttpClient UnleashedClient { get; set; }

        public UnleashedService(string unleashedApiId, string unleashedApiKey)
        {
            ApiId = unleashedApiId;
            ApiKey = unleashedApiKey;
            UnleashedClient = GetUnleashedClient();
        }

        public HttpClient GetUnleashedClient()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri($"https://api.unleashedsoftware.com/"),
                MaxResponseContentBufferSize = 25600000
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("api-auth-id", ApiId);
            client.DefaultRequestHeaders.Add("api-auth-signature", GetAuthSignature(""));

            return client;
        }

        public string GetAuthSignature(string args)
        {
            var encoding = new System.Text.ASCIIEncoding();
            byte[] key = encoding.GetBytes(ApiKey);
            var myHmacSha256 = new HMACSHA256(key);
            byte[] hashValue = myHmacSha256.ComputeHash(encoding.GetBytes(args));
            string hmac64 = Convert.ToBase64String(hashValue);
            myHmacSha256.Clear();
            return hmac64;
        }

        public async Task<HttpResponseMessage> CreateNewCustomer(Customer unleashedCustomer)
        {
            var content = new StringContent(JsonConvert.SerializeObject(unleashedCustomer, Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            }), Encoding.UTF8, "application/json");
            var restUrl = $"customers/{unleashedCustomer.Guid}";
            var httpResponse = await UnleashedClient.PostAsync(restUrl, content);

            return httpResponse;
        }
    }
}
