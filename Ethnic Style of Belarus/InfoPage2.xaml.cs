using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ethnic_Style_of_Belarus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage2 : ContentPage
    {
        private bool _allStudied;

        public InfoPage2(string objectInfo, bool allStudied)
        {
            InitializeComponent();
            infoLabel.Text = objectInfo;
            _allStudied = allStudied;

            if (_allStudied)
            {
                nextButton.IsVisible = false;
                GoToWardrobeButton.IsVisible = true;
            }
        }

        private async void OnNextClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void OnGoToWardrobeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WardrobePage());
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            StopAudio();
        }
        private void StopAudio()
        {
            var player = CrossSimpleAudioPlayer.Current;
            if (player.IsPlaying)
            {
                player.Stop();
            }
        }
    }
}
