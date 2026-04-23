using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;


namespace CRMS.EnterpriseClient.Services
{
    public class ApiClient
    {
        private HttpClient client;
        public ApiClient()
        {
            client = new HttpClient();

        client.BaseAddress = new Uri("http://jds-tech4263-crms.runasp.net");
        }

        public void SetLogin(string username, string password)
        {
            string loginText = username + ":" + password;

            byte[] loginBytes = Encoding.UTF8.GetBytes(loginText);

            string encodedLogin = Convert.ToBase64String(loginBytes);

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", encodedLogin);
        }

        public async Task<string> GetAsync(string route)
        {
            HttpResponseMessage response = await client.GetAsync(route);

            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            return result;
        }

        public async Task<string> PostAsync(string route, object data)
        {
            string json = JsonConvert.SerializeObject(data);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(route, content);

            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            return result;
        }

        public async Task<string> PutAsync(string route, object data)
        {
            string json = JsonConvert.SerializeObject(data);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(route, content);

            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            return result;
        }

        public async Task<string> DeleteAsync(string route)
        {
            HttpResponseMessage response = await client.DeleteAsync(route);

            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            return result;
        }
    }
}

