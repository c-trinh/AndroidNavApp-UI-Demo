using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Theia.Models.SettingsSystem
{
    public class Settings
    {
        private readonly string ConfigFile = "settings.conf";
        private static ISettings AppSettings
        {
            get
            {
                if(CrossSettings.IsSupported)
                    return CrossSettings.Current;
                return null;
            }
        }
            

        private readonly int maxList = 5;

        private static Settings obj = new Settings();

        private readonly List<SettingsProfile> Rooms = new List<SettingsProfile>();

        private readonly List<SettingsProfile> Contacts = new List<SettingsProfile>();

        public string Name
        {
            get => AppSettings.GetValueOrDefault(nameof(Name), string.Empty, ConfigFile);
            set => AppSettings.AddOrUpdateValue(nameof(Name), value, ConfigFile);
        }

        public long EmergencyContact
        {
            get => AppSettings.GetValueOrDefault(nameof(EmergencyContact), 4257723574, ConfigFile);
            set => AppSettings.AddOrUpdateValue(nameof(EmergencyContact), value, ConfigFile);
        }

        public int StepLength
        {
            get => AppSettings.GetValueOrDefault(nameof(StepLength), 1, ConfigFile);
            set => AppSettings.AddOrUpdateValue(nameof(StepLength), value, ConfigFile);
        }

        public string StartLocation
        {
            get => AppSettings.GetValueOrDefault(nameof(StartLocation), string.Empty, ConfigFile);
            set => AppSettings.AddOrUpdateValue(nameof(StartLocation), value, ConfigFile);
        }

        public string Building
        {
            get => AppSettings.GetValueOrDefault(nameof(Building), string.Empty, ConfigFile);
            set => AppSettings.AddOrUpdateValue(nameof(Building), value, ConfigFile);
        }

        public string EndLocation
        {
            get => AppSettings.GetValueOrDefault(nameof(EndLocation), string.Empty, ConfigFile);
            set => AppSettings.AddOrUpdateValue(nameof(EndLocation), value, ConfigFile);
        }

        public int VoiceVolume
        {
            get => AppSettings.GetValueOrDefault(nameof(VoiceVolume), 5, ConfigFile);
            set => AppSettings.AddOrUpdateValue(nameof(VoiceVolume), value, ConfigFile);
        }

        private Settings() { 
            
        }

        public static Settings GetInstance()
        {
            if (obj == null)
            {
                obj = new Settings();
            }
            //obj.Name = "testere";
            //obj.StepLength = 10;
            return obj;
        }

        public SettingsProfile GetRoom(int index)
        {
            if(index < 0 || index > maxList || index > Rooms.Count) { 
                return null;
            };
            return Rooms[index];
        }
        public void SetRoom(int index, SettingsProfile settingsProfile)
        {
            if (index < 0 || index > maxList || index > Rooms.Count) {
                return;
            };
            Rooms[index] = settingsProfile;
        }

        public SettingsProfile GetContact(int index)
        {
            if (index < 0 || index > maxList || index > Rooms.Count)
            {
                return null;
            };
            return Contacts[index];
        }
        public void SetContact(int index, SettingsProfile settingsProfile)
        {
            if (index < 0 || index > maxList || index > Rooms.Count)
            {
                return;
            };
            Contacts[index] = settingsProfile;
        }




    }
}
