using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.SimpleAudioPlayer;

namespace Ethnic_Style_of_Belarus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : ContentPage
    {
        private ISimpleAudioPlayer _player;
        public InfoPage(string userName)
        {
            InitializeComponent();
            welcomeLabel.Text = $"Прывітанне, {userName}! Я рада з вамі пазнаёміцца. Дадзённая навучальная гульня прызначана для вывучэння беларускага касцюма. Часта беларускі строй блытаюць з расійскім ці іншым. Каб даведацца лепш пра беларускі касцюм, неабходна прайсці заданне. У ім вам трэба знайсці прадметы беларускага народнага касцюма. У ходе пошукаў вы даведае пра асаблівасці беларускага народнага касцюма.";
            PlayWelcomeAudio();
        }

        private void PlayWelcomeAudio()
        {
            _player = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            _player.Load("hello.mp3");
            _player.Play();

        }
        private async void OnStartClicked(object sender, EventArgs e)
        {
            if (_player == null || !_player.IsPlaying)
            {
                return;
            }
            _player.Stop();
            await Navigation.PushAsync(new ClothingRoomPage());
        }

    }
}