using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
    public partial class AnimalsListView : ContentPage
    {
        public ObservableCollection<PetViewModel> Animals { get; set; }

        public AnimalsListView()
        {
            InitializeComponent();

            Title = "Animais no abrigo";
            
            //GetAnimals list
            Animals = new ObservableCollection<PetViewModel>();

            GetPetsFromServer();

            MyListView.ItemsSource = Animals;
        }

        private void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            Navigation.PushAsync(new EditAnimalView((PetViewModel) e.Item));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddNewPetView());
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (PetsHelper.LastPetCreated != null)
            {
                Animals.Add(PetsHelper.LastPetCreated);
                PetsHelper.LastPetCreated = null;
            }

            if (PetsHelper.LastPetUpdated != null)
            {
                var lastUpdated = PetsHelper.LastPetUpdated;

                var listAnimal = Animals.FirstOrDefault(x => x.Pet.PetId == lastUpdated.Pet.PetId);

                if (listAnimal != null)
                {
                    listAnimal.Age = lastUpdated.Age;
                    listAnimal.Breed = lastUpdated.Breed;
                    listAnimal.Castrated = lastUpdated.Castrated;
                    listAnimal.DateOfArrival = lastUpdated.DateOfArrival;
                    listAnimal.Description = lastUpdated.Description;
                    listAnimal.Name = lastUpdated.Name;
                    listAnimal.NextVaccine = lastUpdated.NextVaccine;
                    listAnimal.Note = lastUpdated.Note;
                    listAnimal.Sex = lastUpdated.Sex;
                    listAnimal.Type = lastUpdated.Type;
                    listAnimal.Size = lastUpdated.Size;
                    listAnimal.ToBeAdopted = lastUpdated.ToBeAdopted;
                    listAnimal.UpToDateVaccines = lastUpdated.UpToDateVaccines;
                }

                PetsHelper.LastPetUpdated = null;
            }
        }

        async void GetPetsFromServer()
        {
            var animalsJson = await PetsHelper.GetPetsList();
            var animals = JsonConvert.DeserializeObject<List<Pet>>(animalsJson);

            foreach (var animal in animals)
            {
                Animals.Add(new PetViewModel(animal));
            }
        }
    }
}
