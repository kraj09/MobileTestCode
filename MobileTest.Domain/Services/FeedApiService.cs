using MobileTest.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MobileTest.Domain.Services
{
    public class FeedApiService : IFeedApiService
    {
        public async Task<List<FeedModel>> CallApi()
        {
            Uri uri = new Uri("https://next.json-generator.com/api/json/get/Nk63L1Weu");
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage responseMessage = await client.GetAsync(uri);
                if (responseMessage.IsSuccessStatusCode)
                {
                    string content = await responseMessage.Content.ReadAsStringAsync();
                    List<FeedModel> feeds = JsonConvert.DeserializeObject<List<FeedModel>>(content);
                    return feeds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                // log exception
                return null;
            }
        }
    }
}
