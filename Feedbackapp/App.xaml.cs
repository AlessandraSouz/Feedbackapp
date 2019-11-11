using System;
using Feedbackapp.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Feedbackapp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage()) { BarBackgroundColor = Color.FromHex("#02ADA0"), BarTextColor = Color.FromHex("#080808") };
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
