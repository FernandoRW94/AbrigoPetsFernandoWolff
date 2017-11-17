using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AbrigoPets.Models;
using AbrigoPets.ViewModels;
using Newtonsoft.Json;

namespace AbrigoPets.Code
{
    public static class PetsHelper
    {
        public static PetViewModel LastPetCreated;
        public static PetViewModel LastPetUpdated;

        public static string CreatePetAsync(PetViewModel model)
        {
            var pet = JsonConvert.SerializeObject(model.Pet);

            var body = new StringContent(pet,Encoding.UTF8,"application/json");
            
            string url = Globals.ServerPath + "/PetsApi/CreateNewPet";

            HttpClient client = new HttpClient();
            
            var response = client.PostAsync(url, body).Result;

            var responseResult = response.Content.ReadAsStringAsync().Result;
            
            return responseResult;
        }

        public static Task<string> GetPetsList()
        {
            HttpClient client = new HttpClient();

            string url = Globals.ServerPath + "/PetsApi/GetPetsList";

            var retorno = client.GetStringAsync(url);

            return retorno;
        }

        public static Task<string> UpdatePet(PetViewModel model)
        {
            var pet = JsonConvert.SerializeObject(model.Pet);

            var body = new StringContent(pet, Encoding.UTF8, "application/json");

            string url = Globals.ServerPath + "/PetsApi/UpdatePet";
            
            HttpClient client = new HttpClient();

            var response = client.PostAsync(url, body).Result;

            var responseResult = response.Content.ReadAsStringAsync();

            return responseResult;
        }
    }
}
