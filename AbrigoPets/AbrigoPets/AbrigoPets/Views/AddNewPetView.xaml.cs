using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbrigoPets.Code;
using AbrigoPets.Models;
using AbrigoPets.ViewModels;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AbrigoPets.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewPetView : ContentPage
    {
        public PetViewModel NewPet;

        public AddNewPetView()
        {
            InitializeComponent();

            Title = "Adicionar novo Pet";

            this.NewPet = new PetViewModel(new Pet()
            {
                DateOfArrival = DateTime.Now,
                NextVaccine = DateTime.Now
            });

            this.BindingContext = NewPet;
        }

        private async void CreateNewAnimal(object sender, EventArgs e)
        {
            var validModel = validatePet();
            if (!string.IsNullOrEmpty(validModel))
            {
                await DisplayAlert("Oops. Os seguintes campos precisam ser preenchidos...", string.Join(", ", validModel.Split(';')), "OK");

                return;
            }

            //Create animal
            var result = PetsHelper.CreatePetAsync(this.NewPet);

            var aux = JsonConvert.DeserializeObject<ResultMessage>(result);

            if (aux.Success)
            {
                this.NewPet.Pet.PetId = aux.NewId;
                PetsHelper.LastPetCreated = this.NewPet;
                await DisplayAlert("Concluído", aux.Message, "OK");
            }
            else
            {
                PetsHelper.LastPetCreated = null;
                await DisplayAlert("Oops. Algo deu errado...", aux.Message, "OK");
            }

            //Reload to AnimalsListView
            await Navigation.PopAsync(true);
        }

        private string validatePet()
        {
            string result = "";

            if (string.IsNullOrEmpty(this.NewPet.Type)){
                result += "Tipo;";
            }
            if (string.IsNullOrEmpty(this.NewPet.Name))
            {
                result += "Nome;";
            }
            if (string.IsNullOrEmpty(this.NewPet.Breed))
            {
                result += "Raça;";
            }
            if (string.IsNullOrEmpty(this.NewPet.Size))
            {
                result += "Porte;";
            }
            if (string.IsNullOrEmpty(this.NewPet.Sex))
            {
                result += "Sexo;";
            }
            if (this.NewPet.Age < 0)
            {
                result += "Idade;";
            }

            if (result.EndsWith(";"))
                result = result.Substring(0, result.Length - 1);

            return result;

        }
    }
}