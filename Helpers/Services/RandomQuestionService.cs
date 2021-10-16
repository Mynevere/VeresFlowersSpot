using FlowrSpotPovio.Interfaces;
using FlowrSpotPovio.ViewModels;
using MassTransit.JobService.Components;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FlowrSpotPovio.Helpers.Services
{
    public class RandomQuestionService : IRandomQuestionService
    {
        public RandomQuestionService()
        {
        }

        public async Task<string> GenerateRandomQuestion()
        {
            string openDbUrl = "https://opentdb.com/api.php?amount=1&category=17";
            HttpClient client = new HttpClient();

            string question = null;
            client.BaseAddress = new Uri(openDbUrl);
            HttpResponseMessage response = await client.GetAsync(openDbUrl);

            if (response.IsSuccessStatusCode)
            {
                JObject obj = JsonConvert.DeserializeObject<JObject>(response.Content.ReadAsStringAsync().Result);
                var resultProp = (JObject)(obj.Property("results").Value.FirstOrDefault());
                question = resultProp.Property("question").Value.ToString();
                return question;
            }
            return question;
        }
    }
}
