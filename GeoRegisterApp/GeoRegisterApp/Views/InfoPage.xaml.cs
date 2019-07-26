using GeoRegisterApp.Models;
using System;
using Xamarin.Forms.Xaml;

namespace GeoRegisterApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InfoPage
    {

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

        void ExitButtonClicked(object sender, EventArgs e)
        {
            Environment.Exit(0);
            //System.Threading.Thread.CurrentThread.Abort();
        }
    }
}