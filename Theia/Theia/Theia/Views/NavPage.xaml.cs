using System;
using Theia.Models.PhoneDialerSystem;
using Theia.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Theia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavPageContent : ContentPage
    {
        NavViewModel NavViewModel = new NavViewModel();
        public NavPageContent()
        {
            InitializeComponent();
            //This sets the binding context to be the navigation view model
            //All actions occur in the view model
            BindingContext = NavViewModel;
            MessagingCenter.Subscribe<NavViewModel, string>(this, "BadMapAlert", async (sender,args) =>
            {
                await DisplayAlert("Bad Map", "The building set in settings is not downloaded. Please download " + args + " or use Test map to continue", "Okay");
            });
        }

        private void Emergency_Call_Clicked(object sender, EventArgs e)
        {
            PhoneCaller phoneCaller = new PhoneCaller();
            phoneCaller.DialEmergencyContact();
        }
    }
}