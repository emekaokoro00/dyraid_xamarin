using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace dyraid
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }

        public App()
        {
            //InitializeComponent();
            //MainPage = new dyraid.MainPage();
            
            if (!IsUserLoggedIn)  {
                MainPage = new NavigationPage(new dyraid.LoginPage());
            }
            else {
                MainPage = new NavigationPage(new dyraid.MainPage());
            }
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
