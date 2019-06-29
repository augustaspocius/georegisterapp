using GeoRegisterApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GeoRegisterApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InfoPage : ContentPage
	{
        private string userNameProperty;
        public string UserNameProperty
        {
            get { return userNameProperty; }
            set
            {
                userNameProperty = value;
                OnPropertyChanged(nameof(userNameProperty)); // Notify that there was a change on this property
            }
        }

        public InfoPage (ArrivalDeparture arrivalDeparture)
		{
			InitializeComponent ();
            if (arrivalDeparture.add == "0")
            {
                arrivalDeparture.add = "Išvyko";
            }
            else if (arrivalDeparture.add == "1")
            {
                arrivalDeparture.add = "Atvyko";
            }
            BindingContext = arrivalDeparture;
            //var sendobject = (ArrivalDeparture)BindingContext;
            //sendobject = arrivalDeparture;
            
		}

        async void NextRegistrationButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        async void ExitButtonClicked(object sender, EventArgs e)
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}