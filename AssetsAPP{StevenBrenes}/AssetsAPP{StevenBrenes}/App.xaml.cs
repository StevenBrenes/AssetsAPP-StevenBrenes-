using AssetsAPP_StevenBrenes_.Services;
using AssetsAPP_StevenBrenes_.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AssetsAPP_StevenBrenes_
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
           
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
