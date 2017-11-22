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
            var validModel = validatePet();
            if (!string.IsNullOrEmpty(validModel))
            {
                await DisplayAlert("Oops. Os seguintes campos precisam ser preenchidos...", string.Join(", ", validModel.Split(';')), "OK");

                return;
            }

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

        private string validatePet()
        {
            string result = "";

            if (string.IsNullOrEmpty(this.EditingModel.Type))
            {
                result += "Tipo;";
            }
            if (string.IsNullOrEmpty(this.EditingModel.Name))
            {
                result += "Nome;";
            }
            if (string.IsNullOrEmpty(this.EditingModel.Breed))
            {
                result += "Raça;";
            }
            if (string.IsNullOrEmpty(this.EditingModel.Size))
            {
                result += "Porte;";
            }
            if (string.IsNullOrEmpty(this.EditingModel.Sex))
            {
                result += "Sexo;";
            }
            if (this.EditingModel.Age < 0)
            {
                result += "Idade;";
            }

            if (result.EndsWith(";"))
                result = result.Substring(0, result.Length - 1);

            return result;
        }
    }
}