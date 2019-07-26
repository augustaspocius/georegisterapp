using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GeoRegisterApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BusyPopUp
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