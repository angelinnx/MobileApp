using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Ethnic_Style_of_Belarus.WardrobePage;

namespace Ethnic_Style_of_Belarus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrnamentPage : ContentPage
    {
        private List<ImageItem> imageItems;
        private int currentIndex;
        private ISimpleAudioPlayer audioPlayer;

        public OrnamentPage()
        {
            InitializeComponent();
            audioPlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            imageItems = new List<ImageItem>
            {
                new ImageItem { ImageSource = "maladost.png", Description = "Маладосць — вечная свежасць, энергія і патрэба ў руху. Маладзёжныя арнаменты маюць яркую колеравую гамму, рухомыя лініі, кветкі." },
                new ImageItem { ImageSource = "family.png", Description = "Сям'я — найважнейшая каштоўнасць для беларусаў. Узоры сям'і ўключаюць вобразы дамоў, жанчын з дзецьмі, плады, якія сімвалізуюць плоднасць і клопат аб будынку."},
                new ImageItem { ImageSource = "nasanne.png", Description = "Насенне — надзея на будучае, прыбытак, плоднасць. Насенне сімвалізуе новым этапам, што будзе адраджацца, а таму яна падкрэсліваецца ў арнаментальных узорах."},
                new ImageItem { ImageSource = "yradgai.png", Description = "Ураджай — плод жадання, працы і натхнення. Узоры ўраджаю паказваюць на прадукты сельскагаспадарчай дзейнасці, якія служаць знакавым сімвалам поспеху."},
                new ImageItem { ImageSource = "raskvit.png", Description = "Расквіт — дасягнутая сталасць, поўная расцвітанасць. Расквітныя арнаменты — гэта разнастайныя кветкі, зеляніна, часам буйныя элементы, што пазначаюць велізарнае багацце і энергію."},
                new ImageItem { ImageSource = "clear.png", Description = "Чысціня — маральная высакароднасць, чысціня і яснасць думак. Чыстае сэрца і разум азначаюцца праз узоры з белымі лініямі, светлым тонам."},
                new ImageItem { ImageSource = "anargi.png", Description = "Энергия — магутнасць, сіла і здольнасць рухацца наперад. Энергія праяўляецца праз рухомыя, моцныя лініі, крутыя завіткі, хуткае паскарэнне форм." },
                new ImageItem { ImageSource = "baba.png", Description = "Жытняя баба — сімвал земляробства, дабрабыту і родавога ладу. Гэты вобраз асацыіруецца з багатым ураджаем і дастаткам."},
                new ImageItem { ImageSource = "dysha.png", Description = "Душа — найвышэйшая каштоўнасць чалавека, яго сутнасць. Душэўная тэматыка можа быць пададзена праз узоры з элементамі неба, сонца, але і асобныя, больш тонкія лініі, што нагадваюць летучых птушак."},
                new ImageItem { ImageSource = "bagate.png", Description = "Багацце — сімвал дасягненняў, дабрабыту і матэрыяльнага стану. Узоры багатага арнаменту часцей за ўсё ўключаюць элементы жыта, злакаў, а таксама жывёл, што пазначаюць паспяховае развіццё і ўрадлівасць."},
                new ImageItem { ImageSource = "person.png", Description = "Зорка як сімвал чалавека — сувязь з вышэйшай сілай, звышнатуральнай энергетыкай. Зорка сімвалізуе высокія намеры, душэўную свядомасць."},
                new ImageItem { ImageSource = "fire.png", Description = "Агонь — ахоўнік дома, пераможца цішыні і цемры. Агонь часцей за ўсё сустракаецца ў геаметрычных арнаментах, звязаны з рытмам і энергетыкай."},
                new ImageItem { ImageSource = "love.png", Description = "Голуб і галубка (Каханне) — сімвал сяброўства, любоўных адносін, гармоніі паміж двума істотамі. Голуб і галубка, калі яны ў пары, звычайна пазначаюць усё лепшае ў каханні." },
                new ImageItem { ImageSource = "loveb.png", Description = "Каханне без уззаемнасці - калі голуб і галубка паказаны асобна ці раз'яднана, адсутнасць гармоніі і сувязі.  "},
                new ImageItem { ImageSource = "lovep.png", Description = "Каханне пачынаецца - калі пара галубоў паказана разам, гэта сімвалізуе ўзнікненне кахання, гармонію і сувязь паміж двума істотамі."},
                new ImageItem { ImageSource = "praca.png", Description = "Праца - сімвалізуе важкасць і годнасць працоўнай дзейнасці, усхваленне труду і пладоўнасці. Ён падкрэслівае значэнне працы ў жыцці чалавека, іхнюю важную ролю ў развіцці грамадства і садзейнічанню матэрыяльнаму і духоўнаму багаццю. " },
                new ImageItem { ImageSource = "priroda.png", Description = "Вясна — адраджэнне прыроды, надыход новага жыцця. Вясновая сімволіка часта ўключае кветкі, раслінныя ўзоры, першае прачынанне прыроды." },
                new ImageItem { ImageSource = "rain.png", Description = "Узоры дажджу — вільготныя ўзоры, штрыхавыя лініі, якія намаляваны, каб перадаць атмасферу дажджу.  " },
                new ImageItem { ImageSource = "life.png", Description = "Жыццё — самы фундаментальны сімвал. Жыццёвая сімволіка прысутнічае амаль ва ўсіх арнаментах, паколькі сама культура народная апісвае жыццёвы рух розных стадый і эмацыянальных аспектаў."},
                new ImageItem { ImageSource = "ground.png", Description = "Зямля — крыніца жыцця, пашыраная метафара ўрадлівай зямлі, якая дае ўрад. Арнамэнт, звязаны з зямлёй, можа ўключаць фігуры дрэў, каранёў, раслін, а таксама характэрныя геаметрычныя формы."},
                new ImageItem { ImageSource = "song.png", Description = "Песенная творчасць — важная частка беларускага фальклору. Арнаменты, звязаныя з песняй, могуць уключаць музычныя інструменты, выявы людзей, што спяваюць, або элементы, якія сімвалізуюць мелодыю і музыкальную энергію."},
                new ImageItem { ImageSource = "rusalka.png", Description = "Узоры русалак — гэта магчымыя выявы міфалагічных істотаў, звязаных з вадаёмамі. Русалка ў беларускай культуры лічылася духам, што абараняе водныя крыніцы і лясы. Узоры могуць мець рысы жаночых фігур са стылізаванымі валасамі, рыбіным хвастом або каралеўшымі венцамі."},
                new ImageItem { ImageSource = "prodki.png", Description = "Продкі — старажытныя традыцыі, злучэнне мінулага і будучага. Сімволіка продкаў у арнаментах выяўляецца праз старадаўнія узоры, звілістыя лініі, геаметрычныя фігуры, якія адлюстроўваюць сапраўдную мудрасць нашых продкаў."},
                new ImageItem { ImageSource = "sun.png", Description = "Сонца — дарожка да Бога, вечнае святло, якое з'яўляецца крыніцай жыцця. Сонца часта малюецца ў выглядзе круга, ромбу, крыжа."},
                new ImageItem { ImageSource = "hleb.png", Description = "Хлеб — важны элемент беларускай культуры, які сімвалізуе пладоўнасць, багацце і жыццё. Узоры хлеба могуць быць выкананы ў выглядзе каласоў збожжа, завіткоў і розных гарызантальных палосак, якія нагадваюць прасла хлеба."},
                new ImageItem { ImageSource = "yryla.png", Description = "Ярыла — старажытны славянскі бог вясны, плоднасці і сонца. Выява Ярылы на кане сімвалізуе прыход вясны, жыватворную сілу і новую жыццёвую энергію. Часцей за ўсё Ярылу малююць верхам на кані, што рухаецца па полі або лесе." },
                new ImageItem { ImageSource = "girl.png", Description = "Малайчына, цяпер вы ўсе ведаеце пра сімвалы беларускага арнаменту. Зараз я прапаную вам пагуляць у гульню, паспрабаваць адгадаць, які арнамент намаляваны на кашулі."
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
                    PlayAudioForLastImage("arnament.mp3");
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
            Navigation.PushAsync(new TestPage());
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