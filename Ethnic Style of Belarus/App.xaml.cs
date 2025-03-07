using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ethnic_Style_of_Belarus
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}
