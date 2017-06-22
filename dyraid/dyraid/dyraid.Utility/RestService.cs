using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace dyraid.Utility
{
    public class RestService
    {
        HttpClient client;

        public RestService()
        {
            client = new HttpClient();
        }

        // public async Task<string> GetUserAsync(string restUrl)
        public async Task<string> GetUserAsync(string restUrl, string username, string password)
        {
            string res = null;
            var uri = new Uri(string.Format(restUrl, string.Empty));
            
            var values = new Dictionary<string, string>();
            values.Add("username", username);
            values.Add("password", password);
            var request = new FormUrlEncodedContent(values);

            try
            {
                var response = await client.PostAsync(uri, request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    // res = JsonConvert.DeserializeObject<string>(content);
                    res = (string)Newtonsoft.Json.Linq.JObject.Parse(content)["key"];
                }
            }
            catch (Exception ex)
            {    }

            return res;
        }

    }
}
