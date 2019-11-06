using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Feedbackapp.Model;
using Newtonsoft.Json;

namespace Feedbackapp.Functions
{
    public class WebClientFunctions
    {
        private static HttpClient Client { get; set; }
        private static Uri BaseAddress = new Uri("http://*:5000/api/evaluation");

        static WebClientFunctions()
        {
            Client = new HttpClient { BaseAddress = BaseAddress };
        }

        public static async Task<Evaluation> GetEvaluation(int pin)
        {
            var result = new Evaluation();
            var response = await Client.GetAsync(pin.ToString());
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
            var content = new StringContent(jsonContent);
            await Client.PostAsync("", content);
        }
    }
}