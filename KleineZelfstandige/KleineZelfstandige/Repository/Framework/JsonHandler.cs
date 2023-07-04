using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace KleineZelfstandige.Repository.Framework
{
    public class JsonHandler
    {
        HttpClient _client;


        public JsonHandler()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://060d-84-195-70-6.eu.ngrok.io/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task<List<T>> ListAsync<T>(string apiUrl)
        {
            List<T> result = new List<T>();
            var response = await _client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadFromJsonAsync<T[]>();
                result = json.ToList();
            }
            
            return result;
        }

        public async Task<T> GetAsync<T>(string apiUrl, int id)
        {
            T result;
            HttpResponseMessage response = await _client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadFromJsonAsync<T[]>();                
                result = json[id];
            }
            else
            {
                throw new Exception("Failed to retrieve data from API.");
            }
            return result;
        }

        public async Task PostAsync<T>(T data, string apiUrl)
        {
            string json = JsonConvert.SerializeObject(data);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(apiUrl, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to send data to API.");
            }
        }

        public async Task PutAsync<T>(T data, string apiUrl)
        {
            string json = JsonConvert.SerializeObject(data);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PutAsync(apiUrl, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to update data in API.");
            }
        }

        public async Task DeleteAsync(string apiUrl)
        {

            HttpResponseMessage response = await _client.DeleteAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to delete data in API.");
            }
        }


    }

}
