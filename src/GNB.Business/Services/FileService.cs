using GNB.Business.Interfaces;
using GNB.Business.Models;
using GNB.Business.Utils;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GNB.Business.Services
{
    public class FileService : IPersistenceService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public FileService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public void SaveTransactions(IEnumerable<BusinessTransaction> transactions)
        {
            try
            {
                string path = $"{_hostingEnvironment.ContentRootPath }\\Data";
                string fileName = $"{DateTime.Now.ToString("yyyyMMddTHHmmss")}-transactions.json";

                FileUtils.WriteJSONFile(path, fileName, transactions);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SaveRates(IEnumerable<ConversionRate> rates)
        {
            try
            {
                string path = $"{_hostingEnvironment.ContentRootPath }\\Data";
                string fileName = $"{DateTime.Now.ToString("yyyyMMddTHHmmss")}-rates.json";

                FileUtils.WriteJSONFile(path, fileName, rates);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
}
