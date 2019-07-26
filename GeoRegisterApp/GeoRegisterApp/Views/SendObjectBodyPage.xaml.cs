using GeoRegisterApp.Models;
using System;
using Xamarin.Essentials;

namespace GeoRegisterApp.Views
{
	//[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SendObjectBodyPage
    {
        public SendObjectBodyPage ()
		{
                InitializeComponent();
		}
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var sendobject = (SendObjectBody)BindingContext;

            Preferences.Set("user_id", sendobject.userId);

            await Navigation.PushAsync(new RegisterPage());
        }
    }
}