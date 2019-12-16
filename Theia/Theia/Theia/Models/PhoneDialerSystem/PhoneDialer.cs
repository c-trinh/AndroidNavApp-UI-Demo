using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Theia.Models.SettingsSystem;


namespace Theia.Models.PhoneDialerSystem
{
    public class PhoneCaller
    {
        private Settings settings = Settings.GetInstance();
        public void PlacePhoneCall(string number)
        {
            try
            {
                PhoneDialer.Open(number);
            }
            catch (ArgumentNullException anEx)
            {
                // Number was null or white space
                DialEmergencyContact();
            }
            catch (FeatureNotSupportedException ex)
            {
                // Phone Dialer is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }

        public void DialEmergencyContact()
        {
            //usage
            //PhoneCaller phoneCaller = new PhoneCaller();
            //phoneCaller.DialEmergencyContact();
            PlacePhoneCall(settings.EmergencyContact.ToString());
        }

       
    }
}
