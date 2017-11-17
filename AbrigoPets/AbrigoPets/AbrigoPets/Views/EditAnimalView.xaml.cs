using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbrigoPets.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AbrigoPets.Code;
using AbrigoPets.Models;
using Newtonsoft.Json;

namespace AbrigoPets.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditAnimalView : ContentPage
    {
        public PetViewModel EditingModel;
        public EditAnimalView(PetViewModel model)
        {
            InitializeComponent();

            EditingModel = model;

            Title = "Editar Pet";

            this.BindingContext = EditingModel;
        }

        private async void EditAnimal(object sender, EventArgs e)
        {
            //Edit animal
            var result = await PetsHelper.UpdatePet(this.EditingModel);

            var aux = JsonConvert.DeserializeObject<ResultMessage>(result);

            if (aux.Success)
            {
                PetsHelper.LastPetUpdated = this.EditingModel;
                await DisplayAlert("Concluído", aux.Message, "OK");
            }
            else
            {
                PetsHelper.LastPetUpdated = null;
                await DisplayAlert("Oops.Algo deu errado...", aux.Message, "OK");
            }

            //Reload to AnimalsListView
            await Navigation.PopAsync(true);
        }
    }
}