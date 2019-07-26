using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GeoRegisterApp.Views;
using System.IO;
using Xamarin.Essentials;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GeoRegisterApp
{
    public partial class App
    {
//        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
//        public static string AzureBackendUrl = "http://localhost:5000";
//        public static bool UseMockDataStore = true;
        public static string FolderPath { get; private set; }

        public App()
        {
            InitializeComponent();
            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
//            if (UseMockDataStore)
//                DependencyService.Register<MockDataStore>();
//            else
//                DependencyService.Register<AzureDataStore>();

            var id = Preferences.Get("user_id", "");

            MainPage = id == "" ? new NavigationPage(new SendObjectBodyPage()) : new NavigationPage(new RegisterPage());

            // MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
