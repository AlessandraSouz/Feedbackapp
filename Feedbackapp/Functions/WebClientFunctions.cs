using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Feedbackapp.Model;
using Newtonsoft.Json;

namespace Feedbackapp.Functions
{
    public class WebClientFunctions
    {
        private static HttpClient Client { get; set; }
        private static Uri BaseAddress = new Uri("https://feedbackapp-webapi.azurewebsites.net/api/evaluation/");

        static WebClientFunctions()
        {
            Client = new HttpClient();
            Client.BaseAddress = BaseAddress;
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<Evaluation> GetEvaluation(string pin)
        {
            var result = new Evaluation();
            var response = await Client.GetAsync(pin);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<Evaluation>(responseContent);
                result = responseObject;
            }

            return result;
        }

        public static async Task PostEvaluation(Evaluation evaluation)
        {
            var jsonContent = JsonConvert.SerializeObject(evaluation);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            await Client.PostAsync("", content);
        }

        public static async Task PutEvaluation(Evaluation evaluation)
        {
            var jsonContent = JsonConvert.SerializeObject(evaluation);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            await Client.PutAsync("", content);
        }

        public static async Task<List<Evaluation>> GetEvaluations()
        {
            var result = new List<Evaluation>();
            var response = await Client.GetAsync("");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<List<Evaluation>>(responseContent);
                result = responseObject;
            }

            return result;
        }
    }
}