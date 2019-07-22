using GNB.Business.Enums;
using GNB.Business.Interfaces;
using GNB.Business.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GNB.Business.Services
{
    public class TransactionsJSONService : ITransactionsService
    {
        private readonly HttpClient _client;

        public TransactionsJSONService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("QuietStone");
        }

        public async Task<IEnumerable<BusinessTransaction>> GetTransactions()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync("transactions.json");
                string contentString = await response.Content.ReadAsStringAsync();
                
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    IEnumerable<BusinessTransaction> transactions = JsonConvert.DeserializeObject<IEnumerable<BusinessTransaction>>(contentString);
                    return transactions;
                }
                else
                {
                    throw new Exception($"Status Code: {response.StatusCode} - Content {contentString}");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<BusinessTransaction>> GetTransactionsBySKU(string SKU)
        {
            try
            {
                IEnumerable<BusinessTransaction> transactions = await GetTransactions();
                return transactions.Where(t => t.SKU == SKU);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

