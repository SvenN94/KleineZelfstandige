using KleineZelfstandige.Models;
using KleineZelfstandige.Repository.Framework;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace KleineZelfstandige.Repository
{
    public class KlantRepo
    {
        HttpClient httpClient;
        public KlantRepo()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://a9ab-84-195-70-6.eu.ngrok.io");

        }
        List<Klant> klantenLijst = new();
        string table = "/api/Klant";
       
        public async Task<List<Klant>> GetKlantLijstAsync()
        {
            if (klantenLijst?.Count > 0)
            {
                return klantenLijst;
            }
            var url = $"{table}";
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var klantArrey = await response.Content.ReadFromJsonAsync<Klant[]>();
                klantenLijst = klantArrey.ToList();
            }

            return klantenLijst;
        }
        public async Task PostAsync<Klant>(Klant data)
        {
            string json = JsonConvert.SerializeObject(data);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(table, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to send data to API.");
            }
        }
        public async Task PutAsync<Klant>(Klant data)
        {
            string json = JsonConvert.SerializeObject(data);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PutAsync(table, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to update data in API.");
            }
        }

        public async Task DeleteAsync(Klant data)
        {
            Uri uri = new(httpClient.BaseAddress, table);
            string json = JsonConvert.SerializeObject(data);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpRequestMessage request = new HttpRequestMessage
            {

                Method = HttpMethod.Delete,
                RequestUri = uri,
                Content= content

            };
            HttpResponseMessage response = await httpClient.SendAsync(request);            
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to delete data in API.");
            }
        }



    }
}
