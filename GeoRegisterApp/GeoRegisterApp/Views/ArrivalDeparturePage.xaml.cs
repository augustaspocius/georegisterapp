using GeoRegisterApp.Models;
using GeoRegisterApp.Services;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GeoRegisterApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ArrivalDeparturePage : ContentPage
	{
        ArrivalDeparture arrivalDepartureobj;
        RestService _restService;

        public ArrivalDeparturePage (string userid, string datetime, SendObjectResult result)
		{
			InitializeComponent();
            arrivalDepartureobj = new ArrivalDeparture { userid = userid, userName = result.userName, userSurname = result.userSurname, dateTime = datetime, workingPlaceId = result.workingPlaceId, workingPlaceName = result.workingPlaceName};
            _restService = new RestService();
		}

        async void OnArrivalButtonClicked(object sender, EventArgs e)
        {
            arrivalDepartureobj.add = "1";
            await PopupNavigation.Instance.PushAsync(new BusyPopUp("Registruojamas atvykimas"), true);
            await _restService.PostArrivalDepartureAsync(Constants.ArrivalDepartureEndpoint, arrivalDepartureobj);
            if (_restService.ResultIsOk("0"))
            {
                await PopupNavigation.Instance.PopAsync();
                await Navigation.PushAsync(new InfoPage(arrivalDepartureobj));
            }
        }

        async void OnDepartureButtonClicked(object sender, EventArgs e)
        {
            arrivalDepartureobj.add = "0";
            await PopupNavigation.Instance.PushAsync(new BusyPopUp("Registruojamas išvykimas"), true);
            await _restService.PostArrivalDepartureAsync(Constants.ArrivalDepartureEndpoint, arrivalDepartureobj);
            if (_restService.ResultIsOk("0"))
            {
                await PopupNavigation.Instance.PopAsync();
                await Navigation.PushAsync(new InfoPage(arrivalDepartureobj));
            }
        }
    }
}