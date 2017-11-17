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
    }
}