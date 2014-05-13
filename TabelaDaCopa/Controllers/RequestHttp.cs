using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TabelaDaCopa.Models;
using Newtonsoft.Json;

namespace TabelaDaCopa.Controllers
{
    public class RequestHttp
    {

        public static async Task<List<RootObject>> GetGrupos(Uri webServiceBaseAddress, string webServiceToken)
        {
            try
            {
                var client = new HttpClient();

                client.BaseAddress = webServiceBaseAddress;
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("X-Mashape-Authorization", webServiceToken);

                var response = await client.GetAsync("/Classificacao/Todas");
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();

                var groups = await JsonConvert.DeserializeObjectAsync<List<RootObject>>(result);

                return groups;
            }
            catch
            {
                throw;
            }

        }
    }
}
