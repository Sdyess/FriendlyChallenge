using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenLibraryAPI
{
    public class OpenLibraryClient
    {
        public HttpClient client { get; private set; }
        private static readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new OpenLibraryContractResolver(true)
        };

        public OpenLibraryClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://openlibrary.org/api/");
            client = httpClient;
        }

        public async Task<T> GetDeserializedObjectAsync<T>(string url)
        {
            var result = await client.GetAsync(url).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<T>(jsonData, jsonSettings);
            }

            return default;            
        }
    }
}
