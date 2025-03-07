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
    public partial class InfoPage3 : ContentPage
    {
        private ISimpleAudioPlayer _player;
        public InfoPage3()
        {
            InitializeComponent();
            welcomeLabel.Text = "Малайчына! Вы прайшлі гульню, вывучылі беларускі касцюм і азнаёміліся з арнаментамі. Цяпер вы ведаеце асаблівасці беларускага касцюма. Дзякуй вам, да новых сустрэч!";
            PlayWelcomeAudio();
        }
        private void PlayWelcomeAudio()
        {
            _player = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            _player.Load("razvitane.mp3");

            _player.Play();
        }
        private void OnCloseClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }
    }
}