using KleineZelfstandige.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace KleineZelfstandige.Repository
{
    public class DoodleRepo
    {
        HttpClient httpClient;

        public DoodleRepo()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://a9ab-84-195-70-6.eu.ngrok.io");
        }
        List<Doodle> doodleLijst = new();
        string table = "/api/Doodle";
        
        public async Task<List<Doodle>> GetDoodlesAsync()
        {
            if (doodleLijst?.Count > 0)
            {
                return doodleLijst;
            }
            var url = $"{table}";
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var doodleArray = await response.Content.ReadFromJsonAsync<Doodle[]>();
                doodleLijst = doodleArray.ToList();
            }

            return doodleLijst;
        }
        public async Task PostAsync<Doodle>(Doodle data)
        {
            string json = JsonConvert.SerializeObject(data);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(table, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to send data to API.");
            }
        }
        public async Task PutAsync<Doodle>(Doodle data)
        {
            string json = JsonConvert.SerializeObject(data);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PutAsync(table, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to update data in API.");
            }
        }

        public async Task DeleteAsync(Doodle data)
        {
            Uri uri = new(httpClient.BaseAddress, table);
            string json = JsonConvert.SerializeObject(data);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpRequestMessage request = new HttpRequestMessage
            {

                Method = HttpMethod.Delete,
                RequestUri = uri,
                Content = content

            };
            HttpResponseMessage response = await httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to delete data in API.");
            }
        }
    }
}
