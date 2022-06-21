using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PersistenceTask.Models;

namespace PersistenceTask.Services
{
    public class BeerService
    {
        private const string PRODUCTS_RESOURCE_URI = "v2/beers";
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _api = @"https://api.punkapi.com/";
        public BeerService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
        }
        public async Task<IReadOnlyList<BeerInfo>> GetProductListAsync()
        {
            var client = _clientFactory.CreateClient();
            var uri = new Uri(string.Concat(_api, PRODUCTS_RESOURCE_URI));
            using var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await client.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<BeerInfo>>(json);
        }
    }
}