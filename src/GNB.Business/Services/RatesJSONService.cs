using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GNB.Business.Interfaces;
using GNB.Business.Models;
using Newtonsoft.Json;

namespace GNB.Business.Services
{
    public class RatesJSONService : IRatesService
    {
        private readonly HttpClient _client;

        public RatesJSONService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("QuietStone");
        }


        public async Task<IEnumerable<ConversionRate>> GetConversionRates()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync("rates.json");
                string contentString = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    IEnumerable<ConversionRate> rates = JsonConvert.DeserializeObject<IEnumerable<ConversionRate>>(contentString);
                    return rates;
                }
                else
                {
                    throw new Exception($"Status Code: {response.StatusCode} - Content {contentString}");
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
