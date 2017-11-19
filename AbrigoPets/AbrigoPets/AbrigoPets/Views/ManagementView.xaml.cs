using AbrigoPets.Code;
using AbrigoPets.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Dynamic;
using AbrigoPets.Models;

namespace AbrigoPets.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManagementView : ContentPage
    {
        public ManagementViewModel Model;

        public ManagementView()
        {
            InitializeComponent();
            Title = "Gerenciamento";

            Model = new ManagementViewModel();

            GetManagementInfosFromServer();

            this.BindingContext = Model;
        }

        private async void RegisterChanges(object sender, EventArgs e)
        {
            if(Model.Revenue > 0)
            {
                Model.ShelterMoney += Model.Revenue;
                Model.LastRevenue = Model.Revenue;
                Model.Revenue = 0;
            }
            if (Model.Expense > 0)
            {
                Model.ShelterMoney -= Model.Expense;
                Model.LastExpense = Model.Expense;
                Model.Expense = 0;
            }
            if(Model.FoodConsumption > 0)
            {
                Model.TotalFood -= Model.FoodConsumption;
                Model.FoodConsumption = 0;
            }
            if(Model.FoodEntry > 0)
            {
                Model.TotalFood += Model.FoodEntry;
                Model.FoodEntry = 0;
            }

            dynamic aux = new ExpandoObject();

            aux.ShelterName = Model.ShelterName;
            aux.ShelterMoney = Model.ShelterMoney;
            aux.LastRevenue = Model.LastRevenue;
            aux.LastExpense = Model.LastExpense;
            aux.TotalFood = Model.TotalFood;
            
            string resultString = await ManagementHelper.UpdateManagement(aux);
            
            dynamic result = JsonConvert.DeserializeObject<ExpandoObject>(resultString);

            if(result != null && result.Success)
            {
                await DisplayAlert("Concluído", result.Message, "OK");
            }
            else
            {
                await DisplayAlert("Oops", result.Message + "Basta clicar novamente em registrar mudanças.", "OK");
            }
        }

        async void GetManagementInfosFromServer()
        {
            var result = await ManagementHelper.GetManagementInfos();
            var aux = JsonConvert.DeserializeObject<dynamic>(result);
            
            if(aux != null)
            {
                Model.ShelterName = aux.shelterName;
                Model.ShelterMoney = aux.shelterMoney;
                Model.LastRevenue = aux.lastRevenue;
                Model.LastExpense = aux.lastExpense;
                Model.TotalFood = aux.totalFood;

                var animalsJson = await PetsHelper.GetPetsList();
                var animals = JsonConvert.DeserializeObject<List<Pet>>(animalsJson);

                Model.TotalAnimals = animals.Count;
                Model.TotalDogs = animals.Count(x => x.Type.Equals("Cachorro") || x.Type.Equals("Dog"));
                Model.TotalCats = animals.Count(x => x.Type.Equals("Gato") || x.Type.Equals("Cat"));
            }
            else
            {
                await DisplayAlert("Oops. Algo deu errado...", aux.Message, "OK");
                await Navigation.PopAsync(true);
            }
        }

    }
}