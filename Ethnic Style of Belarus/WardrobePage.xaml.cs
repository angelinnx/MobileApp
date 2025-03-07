using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Ethnic_Style_of_Belarus.OrnamentPage;

namespace Ethnic_Style_of_Belarus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WardrobePage : ContentPage
    {
        private List<ImageItem> imageItems;
        private int currentIndex;
        private ISimpleAudioPlayer audioPlayer;

        public WardrobePage()
        {
            InitializeComponent();
            audioPlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            imageItems = new List<ImageItem>
            {
                new ImageItem { ImageSource = "sarochka.png", Description = "Мужчынская сарочка ў беларускай народнай культуры — гэта доўгая кашуля з натуральных матэрыялаў (лён, воўна), упрыгожваная геаметрычнымі або расліннымі ўзорамі на каўняры, рукавах і падоле. Яна насілася пад курткай або кашуляй і сімвалізавала мужчынскую сілу, годнасць і працавітасць." },
                new ImageItem { ImageSource = "sarochka2.png", Description = "Сарочка — асноўны элемент жаночага строю, якая шылася з лёну або бавоўны. Яна упрыгожвалася вышыўкай на каўняры, рукавах і падоле. Вышыўка звычайна была геаметрычная або раслінная, сімвалізуючы жыццё і плоднасць. Пояс ткалі з воўны або льну, упрыгожвалі геаметрычнымі ўзорамі." },
                new ImageItem { ImageSource = "spadnica.png", Description = "Спадніца шылася з воўны або лёну, упрыгожвалася вышыўкай, аплікацыяй або тканымі палосамі. Спадніца насілася з сарочкай і з’яўлялася важным элементам жаночага строю. Яна сімвалізавала родавыя традыцыі і падкрэслівала статус жанчыны ў грамадстве." },
                new ImageItem { ImageSource = "poys.png", Description = "Пояс — важны элемент мужчынскага і жаночага строю. Мужчынскі пояс быў шырокім і моцным, часта скураным. Жаночы пояс быў таннейшым і лёгкім, часам з тканіны. Абодва пояса былі важным дэкарытым элементам і часам упрыгожваліся міткалёўкай ці металічнымі прыцяжкамі."},
                new ImageItem { ImageSource = "boty.png", Description = "Боты шылі са скуры, упрыгожвалі цісненнем або вышыўкай. Яны былі лёгкімі і камфортнымі, ідуць у пары з народным строем. Боты насілі як мужчыны, так і жанчыны, і яны былі важнай часткай культуры."},
                new ImageItem { ImageSource = "bryl.png", Description = "Брыль — традыцыйны мужчынскі галаўны ўбор, які звычайна плялі з саломы. Ён упрыгожваўся кветкамі і стужкамі, што давала яму асаблівую прыгажосць і сакральнае значэнне. Кветкі сімвалізавалі прыгажосць і плоднасць, а стужкі — весялосць і радасць."},
                new ImageItem { ImageSource = "venok.png", Description = "Дзяўчаты насілі вянкі з жывых або штучных кветак, упрыгожаныя стужкамі і пацеркамі. Вянок сімвалізаваў чысціню, прыгажосць і моладзь. Стужкі на вянку часам вышытыя геаметрычнымі ўзорамі, што дазваляла вылучаць асаблівасці рэгіёна."},
                new ImageItem { ImageSource = "busy.png", Description = "Пацеркі рабілі са шкла, каменя або дрэва. Яны насіліся вакол шыі і мелі розныя фарбы і памеры. Пацеркі маглі быць з драўніны, косткі, шкла або камення. Яны служылі не толькі дэкарацыяй, але і мелі сакральнае значэнне, сімвалізуючы плоднасць і ахову."},
                new ImageItem { ImageSource = "lylka.png", Description = "Лялька-дзяўчынка — гэта традыцыйная беларуская лялька, якая прадстаўляла жаночы касцюм. Такая лялька апраналася ў традыцыйную спадніцу, сарочку, хустку і бусы. Лялька была сімвалам дамашняга ладу і прадугледжвала плоннасць і багацце.Лялькі насілі на сабе традыцыйныя строі, якія ўвасаблялі гаспадарку і багацце. Яны сімвалізавалі родавыя традыцыі і служылі абярэгам ад злых духаў."},
                new ImageItem { ImageSource = "boy.png", Description = "Лялька-хлопчык апраналася ў мужчынскі касцюм, уключаючы брыль, сарочку і пояс. Лялька сімвалізавала мужчынскую сілу і здольнасць да працы. Лялькі насілі на сабе традыцыйныя строі, якія ўвасаблялі гаспадарку і багацце. Яны сімвалізавалі родавыя традыцыі і служылі абярэгам ад злых духаў."},
                new ImageItem { ImageSource = "girl.png", Description = "Беларускі народны строй — не проста адзенне, гэта выраз нашага народа, яго гісторыі і традыцый. Кожны элемент строю мае сваё значэнне і упрыгожваецца традыцыйнымі арнаментамі, якія сімвалізуюць жыццё, плоднасць і ахову. Народны строй з’яўляецца важным складнікам беларускай культуры і гонарнай спадчынай нашых продкаў. Давайце ж азнаёмімся з арнаментамі."
                }
            };
            currentIndex = 0;
            LoadCurrentImage();
        }

        private void LoadCurrentImage()
        {
            if (currentIndex < imageItems.Count)
            {
                wardrobeImage.Source = imageItems[currentIndex].ImageSource;
                imageDescription.Text = imageItems[currentIndex].Description;
                nextButton.IsVisible = currentIndex == imageItems.Count - 1;
                nextImgButton.IsVisible = currentIndex < imageItems.Count - 1;
                previousButton.IsVisible = currentIndex != imageItems.Count - 1;
                if (currentIndex == imageItems.Count - 1)
                {
                    PlayAudioForLastImage("wardrobe.mp3");
                }
            }
        }

        private void PlayAudioForLastImage(string audioFile)
        {
            audioPlayer.Load(audioFile);
            audioPlayer.Play();
        }

        private void StopAudio()
        {
            audioPlayer.Stop();
        }

        private void OnNextClicked(object sender, EventArgs e)
        {
            StopAudio();
            Navigation.PushAsync(new OrnamentPage());
        }
        private void NextClicked(object sender, EventArgs e)
        {
            if (currentIndex + 1 < imageItems.Count)
            {
                currentIndex++;
                LoadCurrentImage();
            }
        }
        private void OnPreviousClicked(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                LoadCurrentImage();
            }
        }
        public class ImageItem
        {
            public string ImageSource { get; set; }
            public string Description { get; set; }
        }

    }
}