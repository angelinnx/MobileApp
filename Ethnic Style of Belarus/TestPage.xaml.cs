using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ethnic_Style_of_Belarus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        private List<Question> questions = new List<Question>();
        private int currentIndex = 0;
        public ICommand AnswerCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }

        public TestPage()
        {
            InitializeComponent();
            AnswerCommand = new Command<string>(OnAnswerClicked);
            ExitCommand = new Command(OnExitClicked);
            BindingContext = this;
            LoadQuestions();
            DisplayCurrentQuestion();
        }
        private class Question
        {
            public string Image { get; set; }
            public string Answer1 { get; set; }
            public string Answer2 { get; set; }
            public string Answer3 { get; set; }
            public int CorrectAnswer { get; set; }
        }

        private void LoadQuestions()
        {
            questions.Add(new Question
            {
                Image = "kashuly1.png",
                Answer1 = "1) энергія, багацце, агонь",
                Answer2 = "2) насенне, расквіт, дождж",
                Answer3 = "3) ярыла, энергія, чысціня",
                CorrectAnswer = 1
            });

            questions.Add(new Question
            {
                Image = "kashuly2.png",
                Answer1 = "1) русалка, маладосць, песня",
                Answer2 = "2) каханне, чалавек, энергія",
                Answer3 = "3) чалавек, энергія, ураджай",
                CorrectAnswer = 3
            });

            questions.Add(new Question
            {
                Image = "kashuly3.png",
                Answer1 = "1) каханне, расквіт, дождж",
                Answer2 = "2) хлеб, чысціня, песня",
                Answer3 = "3) праца, сонца, чысціня",
                CorrectAnswer = 2
            });

            questions.Add(new Question
            {
                Image = "kashuly4.png",
                Answer1 = "1) багацце, агонь, жыццё",
                Answer2 = "2) маладосць, зямля, жыццё",
                Answer3 = "3) расквіт, дождж, ярыла",
                CorrectAnswer = 2
            });

            questions.Add(new Question
            {
                Image = "kashuly5.png",
                Answer1 = "1) душа, праца, сонца",
                Answer2 = "2) расквіт, маладосць, песня",
                Answer3 = "3) ураджай, сонца, энергія",
                CorrectAnswer = 1
            });

            questions.Add(new Question
            {
                Image = "kashuly6.png",
                Answer1 = "1) праца,чысціня, душа",
                Answer2 = "2) душа, ураджай, насенне",
                Answer3 = "3) насенне, расквіт, дождж",
                CorrectAnswer = 3
            });

            questions.Add(new Question
            {
                Image = "kashuly7.png",
                Answer1 = "1) чалавек, энергія, ураджай",
                Answer2 = "2) продкі, душа, ураджай",
                Answer3 = "3) душа, чысціня, хлеб",
                CorrectAnswer = 2
            });

            questions.Add(new Question
            {
                Image = "kashuly8.png",
                Answer1 = "1) маладосць, зямля, жыццё",
                Answer2 = "2) каханне, чалавек, энергія",
                Answer3 = "3) праца, сонца, ураджай",
                CorrectAnswer = 2
            });

            questions.Add(new Question
            {
                Image = "kashuly9.png",
                Answer1 = "1) ярыла, праца,чысціня",
                Answer2 = "2)энергія, багацце, агонь",
                Answer3 = "3) песня,  каханне, маладосць",
                CorrectAnswer = 1
            });

            questions.Add(new Question
            {
                Image = "kashuly10.png",
                Answer1 = "1) хлеб, чысціня, песня",
                Answer2 = "2) энергія, праца, продкі",
                Answer3 = "3) русалка, маладосць, песня",
                CorrectAnswer = 3
            });
        }
        private async void DisplayCurrentQuestion()
        {
            if (currentIndex >= questions.Count)
            {
                await Navigation.PushAsync(new InfoPage3());
            }
            else
            {
                var question = questions[currentIndex];
                QuestionImage.Source = ImageSource.FromFile(question.Image);
                Answer1.Text = question.Answer1;
                Answer2.Text = question.Answer2;
                Answer3.Text = question.Answer3;
                MessageLabel.Text = "";
            }
        }

        private async void OnAnswerClicked(string parameter)
        {
            try
            {
                int answer = int.Parse(parameter);
                var question = questions[currentIndex];

                if (answer == question.CorrectAnswer)
                {
                    MessageLabel.Text = "Правільна! Малайчына!";
                    await Task.Delay(1500);
                    currentIndex++;
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        DisplayCurrentQuestion();
                    });
                }
                else
                {
                    MessageLabel.Text = "Няправільна, паспрабуйце зноў!";
                    await Task.Delay(3000);
                    MessageLabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageLabel.Text = " ";
            }
        }
        private void OnExitClicked()
        {
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }
    }
}
