using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

using Theia.Models.SettingsSystem;
using Theia.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Theia.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        
        Settings Settings = Settings.GetInstance();
        public SettingsViewModel()
        {
            

            //Title = "Settings";
            MessagingCenter.Subscribe<SettingsPage, Settings>(this, "UpdateSettings", async (obj, settings) =>
            {
                var newSettings = settings;
                Settings.Name = newSettings.Name;
                Settings.StepLength = newSettings.StepLength;
                
            });
        }

        public string Name
        {
            get => Settings.Name;
            set
            {
                if (Settings.Name == value) return;
                Settings.Name = value;
                OnPropertyChanged();
            }
        }

        public string Building
        {
            get => Settings.Building;
            set
            {
                if (Settings.Building == value) return;
                Settings.Building = value;
                OnPropertyChanged();
            }
        }

        public int StepLength
        {
            get => Settings.StepLength;
            set
            {
                if (Settings.StepLength == value) return;
                Settings.StepLength = value;
                OnPropertyChanged();
            }
        }

        public string StartLocation
        {
            get => Settings.StartLocation;
            set
            {
                if (Settings.StartLocation == value) return;
                Settings.StartLocation = value;
                OnPropertyChanged();
            }
        }

        public string EndLocation
        {
            get => Settings.EndLocation;
            set
            {
                if (Settings.EndLocation == value) return;
                Settings.EndLocation = value;
                OnPropertyChanged();
            }
        }

        public int VoiceVolume
        {
            get => Settings.VoiceVolume;
            set
            {
                if (Settings.VoiceVolume == value) return;
                Settings.VoiceVolume = value;
                OnPropertyChanged();
            }
        }

        public long EmergencyContact
        {
            get => Settings.EmergencyContact;
            set
            {
                if (Settings.EmergencyContact == value) return;
                Settings.EmergencyContact = value;
                OnPropertyChanged();
            }
        }

        private Command updateName;
        public Command UpdateName(string newName) =>
            updateName ?? (updateName = new Command(() => Name = newName));

        private Command updateStepLength;
        public Command UpdateStepLength(int newStepLength) =>
            updateStepLength ?? (updateStepLength = new Command(() => StepLength = newStepLength));

        private Command updateEmergencyContact;
        public Command UpdateEmergencyContact(int newEmergencyContact) =>
            updateEmergencyContact ?? (updateEmergencyContact = new Command(() => EmergencyContact = newEmergencyContact));

        private Command updateStartLocation;
        public Command UpdateStartLocation(string newStart) =>
            updateStartLocation ?? (updateStartLocation = new Command(() => StartLocation = newStart));

        private Command updateEndLocation;
        public Command UpdateEndLocation(string newEnd) =>
            updateEndLocation ?? (updateEndLocation = new Command(() => EndLocation = newEnd));

        private Command updateBuilding;
        public Command UpdateBuilding(string newBuilding) =>
            updateBuilding ?? (updateBuilding = new Command(() => Building = newBuilding));


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private Command updateVoiceVolume;
        public Command UpdateVoiceVolume(int newVoiceVolume) =>
            updateVoiceVolume ?? (updateVoiceVolume = new Command(() => VoiceVolume = newVoiceVolume));

    }
}
