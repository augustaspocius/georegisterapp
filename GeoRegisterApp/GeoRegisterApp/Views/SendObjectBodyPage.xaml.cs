using GeoRegisterApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GeoRegisterApp.Views
{
	//[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SendObjectBodyPage : ContentPage
	{
        private RegisterPage registerPage;

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