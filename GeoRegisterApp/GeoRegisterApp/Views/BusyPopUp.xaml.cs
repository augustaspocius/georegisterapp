using Rg.Plugins.Popup.Pages;
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
	public partial class BusyPopUp : PopupPage
	{
        public BusyPopUp(string BusyReason)
        {
            // busy indicator popup
            InitializeComponent();
            busyReason.Text = BusyReason;
            busyReason.FontAttributes = FontAttributes.Bold;
        }
        protected override void OnDisappearing()
        {

        }
    }
}