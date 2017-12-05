using System;
using AbrigoPets.Code;
using Xamarin.Forms;

namespace AbrigoPets.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
               
            Title = Globals.AppName;
        }

        private void LoadShelterManagementView(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ManagementView());
        }

        private void LoadPetsManagementView(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AnimalsListView());
        }
        
    }
}
