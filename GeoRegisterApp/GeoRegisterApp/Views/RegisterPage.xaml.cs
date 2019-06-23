using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using GeoRegisterApp.Models;
using Xamarin.Essentials;
using GeoRegisterApp.Services;

namespace GeoRegisterApp.Views
{
    public partial class RegisterPage : ContentPage
    {
        RestService _restService;

        public RegisterPage()
        {
            InitializeComponent();
            _restService = new RestService();
        }

        public async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            String myDate = DateTime.Now.ToString();
            string latitude = "37.422";
            string longitude = "-122.084";

            try
            {
                //var location = await Geolocation.GetLastKnownLocationAsync();
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    latitude = location.Latitude.ToString();
                    longitude = location.Longitude.ToString();
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Alert", "Neįjungtos GPS teisės", "OK");
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }

           SendObjectResult result = await _restService.PostSendObjectResultAsync(Constants.StatybuDemoEndpoint, myDate, Preferences.Get("user_id", ""), longitude, latitude);
            if(_restService.ResultIsOk("0"))
            {
                await Navigation.PushAsync(new ArrivalDeparturePage(Preferences.Get("user_id", ""), myDate, result));
            }
        }

        
    
    }
}