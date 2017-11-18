using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AbrigoPets.ViewModels;
using Newtonsoft.Json;

namespace AbrigoPets.Code
{
    public static class ManagementHelper
    {
        public static Task<string> GetManagementInfos()
        {
            HttpClient client = new HttpClient();

            string url = Globals.ServerPath + "/PetsApi/GetManagementInfos";

            var retorno = client.GetStringAsync(url);

            return retorno;
        }

        public static Task<string> UpdateManagement(dynamic model)
        {
            var management = JsonConvert.SerializeObject(model);

            var body = new StringContent(management, Encoding.UTF8, "application/json");

            string url = Globals.ServerPath + "/PetsApi/UpdateShelter";

            HttpClient client = new HttpClient();

            var response = client.PostAsync(url, body).Result;

            var responseResult = response.Content.ReadAsStringAsync();

            return responseResult;
        }
    }
}
