using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace dyraid.Utility
{
    public sealed class RestService
    {
        HttpClient client;
        string auth_key;

        private static readonly Lazy<RestService> lazy =
            new Lazy<RestService>(() => new RestService());

        public static RestService Instance { get { return lazy.Value; } }
        
        private RestService()
        {
            client = new HttpClient();
            auth_key = null;
        }

        public async Task<string> AuthenticateUserAsync(string restUrl, string username, string password)
        {
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
                    auth_key = (string)Newtonsoft.Json.Linq.JObject.Parse(content)["key"];
                }
            }
            catch (Exception ex)
            {    }

            return auth_key;
        }

        public async Task<string> GetUserDetailsAsync(string restUrl)
        {
            string res = null;
            var uri = new Uri(string.Format(restUrl, string.Empty));
            
            //ANOTHER  WAY
            // HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, uri);
            // msg.Headers.Add("X-AUTH", auth_key);
            // var response = await client.SendAsync(msg);

            client.DefaultRequestHeaders.TryAddWithoutValidation("X-AUTH‌​", auth_key);

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    res = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            { }

            return res;
        }

    }
}
