using SharedLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.Clients
{
    public class RestClient
    {
        private static readonly HttpClient _client = new HttpClient();
        public async Task<PdfModel> RestGetPdfBytIdAsync()
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var id = new Random().Next(1,10);
            return await _client.GetFromJsonAsync<PdfModel>($"https://localhost:7297/api/Pdf/GetById/{id}");
        }

        public async Task<IEnumerable<PdfModel>> RestGetAllPdfsAsync()
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
            return await _client.GetFromJsonAsync<IEnumerable<PdfModel>>($"https://localhost:7297/api/Pdf/GetAll");
        }
    }
}
