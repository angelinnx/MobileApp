using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ethnic_Style_of_Belarus
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnNextClicked(object sender, EventArgs e)
        {
            string userName = NameEntry.Text;
            if (!string.IsNullOrWhiteSpace(userName))
            {
                var infoPage = new InfoPage(userName);
                await Navigation.PushAsync(infoPage);
            }
            else
            {
                await DisplayAlert("Памылка!", "Калі ласка, увядзіце ваша імя.", "ОК");
            }
        }

    }
}

