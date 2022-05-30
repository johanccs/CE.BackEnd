using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CE.Services.Helper
{
    public static class RemoteApiHelper
    {
        public static async  Task<string> GetAsync(string baseUrl, string api_key, string parms)
        {
            //https://api-dev.channelengine.net/api/v2/orders?statuses=IN_PROGRESS&apikey=541b989ef78ccb1bad630ea5b85c6ebff9ca3322
            //var url = $"{baseUrl}?statusses={parms}&apikey={api_key}";
            var url = $"{baseUrl}&apikey={api_key}";
            
            using(HttpClient http = new HttpClient())
            {
                try
                {
                    var responseTask = await http.GetAsync(url);

                    if(responseTask.IsSuccessStatusCode)
                    {
                        if(responseTask.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var result = await responseTask.Content.ReadAsStringAsync();

                            return result;
                        }
                    }

                    return null;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static async Task<string> PostAsync(string baseUrl, string serializedObject, string api_key)
        {
            //https://api-dev.channelengine.net/api/v2/products?ignoreStock=false&apikey=541b989ef78ccb1bad630ea5b85c6ebff9ca3322
            var url = $"{baseUrl}?ignoreStock=false&apikey={api_key}";
            var content = new StringContent(serializedObject, Encoding.UTF8, "application/json");

            using (HttpClient http = new HttpClient())
            {
                try
                {
                    var responseTask = await http.PostAsync(url, content);

                    if (responseTask.IsSuccessStatusCode)
                    {
                        if (responseTask.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var result = await responseTask.Content.ReadAsStringAsync();

                            return result;
                        }
                    }

                    return null;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
