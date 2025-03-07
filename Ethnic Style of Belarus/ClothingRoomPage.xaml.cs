using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.SimpleAudioPlayer;
using Ethnic_Style_of_Belarus;


namespace Ethnic_Style_of_Belarus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClothingRoomPage : ContentPage
    {
        private HashSet<string> studiedItems = new HashSet<string>();
        private List<string> allItems = new List<string> { "bryl.png", "busy.png", "boty.png", "boy.png", "spadnica.png", "sarochka.png", "lylka.png", "poys.png", "venok.png" };

        public ClothingRoomPage()
        {
            InitializeComponent();
        }

        private async void OnObjectTapped(object sender, EventArgs e)
        {
            var image = sender as Image;
            if (image == null)
                return;

            string objectInfo = "";
            string imageName = image.Source.ToString().Split('/').Last();

            if (studiedItems.Contains(imageName))
            {
                return;
            }

            string audioFilePath = "";

            if (imageName.Contains("bryl.png"))
            {
                objectInfo = "Брыль-гэта традыцыйны галаўны ўбор мужчын беларусаў, які мае глыбокія культурныя і гістарычныя карані. Ён звычайна вырабляўся з натуральных матэрыялаў, такіх як ільняное або ваўняная палатно, і мог быць розных колераў і формаў.";
                audioFilePath = "bryl.mp3";
            }
            else if (imageName.Contains("busy.png"))
            {
                objectInfo = "Пацеркі — традыцыйнае жаночае ўпрыгожванне, якое насілі на шыі. Пацеркі часта рабіліся з керамікі, дрэва, шкла або костачак. У пацерках можна было бачыць вельмі разнастайныя узоры і фарбы, якія адлюстроўваюць традыцыйную густую і каларыстычную гаму Беларусі. Пацеркі былі важным сімвалам жаночай прыгажосці і статусу.";
                audioFilePath = "busy.mp3";
            }

            else if (imageName.Contains("boty.png"))
            {
                objectInfo = "Боты — традыцыйны абутак для мужчын і жанчын. Яны былі хуткія, гнуткія і лёгкія, часта рабіліся са скуры або валёныя. Боты часцей за ўсё мелі невысокі абцасы і завязваліся шнуркамі або стужкамі. Яны добра падыходзілі для працы ў полі, а таксама для штодзённага нашэння.";
                audioFilePath = "boty.mp3";
            }
            else if (imageName.Contains("spadnica.png"))
            {
                objectInfo = "Спадніца — гэта жаночая спаднявая сукенка. Яна часта бывае вышытая арнаментамі і служыла асновай традыцыйнага жаночага касцюма ў Беларусі. Часцей за ўсё падобную спадніцу насілі замужнія жанчыны, яна мела цёмны колер, часам чорны або шэра-карычневы. Спадніца можа мець розныя фасоны, але адметная рысам — просты крой, што дазваляў  захоўваць сціпласць і грацыёзнасць.";
                audioFilePath = "spadnica.mp3";
            }
            else if (imageName.Contains("lylka.png"))
            {
                objectInfo = "Лялька-дзяўчынка сімвалізуе плоднасць, мацярынства і дамашнюю абарону. Яна апранаецца ў сарафан або спадніцу, часта расшытую арнаментамі, і служыць талісманам для забеспячэння плоднасці, абароны дому і падтрымкі дамашняга ладу.";
                audioFilePath = "lylka.mp3";
            }
            else if (imageName.Contains("poys.png"))
            {
                objectInfo = "Пояс — важная частка традыцыйнага касцюма. Паясамі апраналіся і мужчыны, і жанчыны. Мужчынскія паясы былі шырокімі і цвёрдымі, зробленымі са скураных палотноў, часта упрыгожаны арнаментамі. Жаночыя паясы маглі быць больш тонкімі і лёгкімі, упрыгожанымі вышыванкай або металічнымі накладкамі. Пояс служыў не толькі для утрымлівання вопраткі, але і быў сімвалам годнасці і самастойнасці.";
                audioFilePath = "poys.mp3";
            }
            else if (imageName.Contains("sarochka.png"))
            {
                objectInfo = "Сарочка — жаночая рубашка, якую насілі пад спадніцай. Яна магла быць кароткай або даўжэйшай, распашнай або глухой. Вышывалі сарочку часцей за ўсё па краях рукавоў і вакол шыі. Сарочкі звычайна рабіліся з тонкіх тканін, такіх як лён або канопля. У залежнасці ад таго, хто насіў сарочку, яна магла мець разнастайныя арнаменты і ўзоры.";
                audioFilePath = "sarochka.mp3";
            }
            else if (imageName.Contains("boy.png"))
            {
                objectInfo = "Лялька-хлопчык сімвалізуе моц, працаздольнасць і радавую сілу. Яна часта робіцца з натуральнай тканіны, саломы або драўніны, апранаецца ў простую вопратку і служыць талісманам для абароны дома і падтрымкі мужчынскай энергіі ў сям’і.";
                audioFilePath = "boy.mp3";
            }
            else if (imageName.Contains("venok.png"))
            {
                objectInfo = "Вянок — традыцыйны жаночы галаўны ўбор, папулярны ў Беларусі. Ён сімвалізуе замужні стан і плаццёвую сілу. Дзяўчаты насілі вянкі з ніткамі або стужкамі, а замужнія жанчыны завязвалі вянкі вакол галавы. Вянкі рабіліся з натуральных матэрыялаў і дэкарыраваліся арнаментамі, стужкамі, камяннямі або кветкамі. Яны мелі сакральнае значэнне і ўдзельнічалі ў традыцыйных абрадах.";
                audioFilePath = "venok.mp3";
            }
            if (!string.IsNullOrEmpty(audioFilePath))
            {
                var player = CrossSimpleAudioPlayer.Current;
                player.Load(audioFilePath);
                player.Play();
            }

            studiedItems.Add(imageName);
            await MoveToBasket(image);
            if (studiedItems.Count == allItems.Count)
            {
                string completionInfo = "Малайчына! Вы знайшлі ўсе элементы. Зараз я прапаную вам прайсці ў пакой гардэроба і разглядзець іх бліжэй.";
                string completionAudioFilePath = "completion.mp3";
                await Navigation.PushAsync(new InfoPage2(objectInfo, false));
                await Task.Delay(27000);
                await Navigation.PushAsync(new InfoPage2(completionInfo, true));
                var player = CrossSimpleAudioPlayer.Current;
                player.Load(completionAudioFilePath);
                player.Play();
            }
            else
            {
                await Navigation.PushAsync(new InfoPage2(objectInfo, false));
            }
        }

        private async Task MoveToBasket(Image item)
        {
            double basketX = basketImage.X;
            double basketY = basketImage.Y;
            item.Opacity = 1;
            await item.TranslateTo(basketX, basketY, 500);
            item.IsVisible = false;
        }
    }
}