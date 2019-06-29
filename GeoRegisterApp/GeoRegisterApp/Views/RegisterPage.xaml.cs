﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using GeoRegisterApp.Models;
using Xamarin.Essentials;
using GeoRegisterApp.Services;
using Rg.Plugins.Popup.Services;
using Rg.Plugins.Popup.Contracts;

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
            string latitude = "-";
            string longitude = "-";
            
            //((App)App.Current).MainPage = new NavigationPage(busyPopUp);
            //await Navigation.PushAsync(busyPopUp);
            await PopupNavigation.Instance.PushAsync(new BusyPopUp("Nustatomos koordinatės"), true);
            try
            {
                //var location = await Geolocation.GetLastKnownLocationAsync();
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    latitude = location.Latitude.ToString("0.0000", System.Globalization.CultureInfo.InvariantCulture);
                    longitude = location.Longitude.ToString("0.0000", System.Globalization.CultureInfo.InvariantCulture);
                    SendObjectResult result = await _restService.PostSendObjectResultAsync(Constants.StatybuDemoEndpoint, myDate, Preferences.Get("user_id", ""), longitude, latitude);
                    if (_restService.ResultIsOk(result.errorID))
                    {
                        await PopupNavigation.Instance.PopAsync();
                        await Navigation.PushAsync(new ArrivalDeparturePage(Preferences.Get("user_id", ""), myDate, result));
                    }
                    else
                    {
                        await DisplayAlert("Įspėjimas", "Sistemoje objektas nerastas. Klaidos pranešimas:\n" + result.errorDesc, "OK");
                        await PopupNavigation.Instance.PopAsync();
                        //((App)App.Current).MainPage = new NavigationPage(new SendObjectBodyPage());
                        //// Application.Current.MainPage = new SendObjectBodyPage();
                        //await Navigation.PopToRootAsync();
                    }
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Įspėjimas", "GPS nepalaikymo telefone klaida / Handle not supported on device exception", "OK");
                await PopupNavigation.Instance.PopAsync();
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                await DisplayAlert("Įspėjimas", "GPS neįjungimo telefone klaida / Handle not enabled on device exception", "OK");
                await PopupNavigation.Instance.PopAsync();
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Įspėjimas", "Neįjungtos GPS teisės / Handle permission exception", "OK");
                await PopupNavigation.Instance.PopAsync();
                // Handle permission exception
            }
            catch (Exception ex)
            {
                await DisplayAlert("Įspėjimas", "GPS koordinatės negautos, nustatykite leidimą naudoti GPS ir įsijunkite GPS / Unable to get location", "OK");
                await PopupNavigation.Instance.PopAsync();
                // Unable to get location
            }
        }

        
    
    }
}