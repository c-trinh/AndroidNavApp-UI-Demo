using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Theia.Models.SettingsSystem;
using Theia.ViewModels;

using Theia.Models.PhoneDialerSystem;

namespace Theia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {

        public Settings settings;

        public SettingsPage()
        {
            InitializeComponent();
            settings = Settings.GetInstance();

            BindingContext = new SettingsViewModel();
            
        }

        async private void Save_Clicked(object sender, EventArgs e)
        {
            //PhoneCaller phoneCaller = new PhoneCaller();
            //phoneCaller.DialEmergencyContact();
            await DisplayAlert("Save", "Changes Saved.", "Okay");
            
        }



    }
}