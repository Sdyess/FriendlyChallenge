using Newtonsoft.Json;
using System;
using System.IO;
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
            using (var result = await client.GetAsync(url).ConfigureAwait(false))
            {
                if (result.IsSuccessStatusCode)
                {
                    using (var dataStream = await result.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    using (var streamReader = new StreamReader(dataStream))
                    using (var jsonReader = new JsonTextReader(streamReader))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        return serializer.Deserialize<T>(jsonReader);
                    }
                    
                }
            }
                

            return default;            
        }
    }
}
