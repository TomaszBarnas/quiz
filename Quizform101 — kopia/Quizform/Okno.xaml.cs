using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace QuizForm
{
    /// <summary>
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {
        private int score = 0;
        private int currentQuestion = 0;
        private int temp = 0;
        private string[] WrongQuestions = new string[10];
        private List<Pytania> questions;

        public QuizWindow(List<Pytania> questions)
        {
            DispatcherTimer _timer;
            TimeSpan _time;
            
                InitializeComponent();

                _time = TimeSpan.FromSeconds(0);

                _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
                {
                    timerText.Content = _time.ToString("c");
                    _time = _time.Add(TimeSpan.FromSeconds(1));
                }, Application.Current.Dispatcher);

                _timer.Start();
            
            InitializeComponent();
            //Laduje pierwsze pytanie
            this.questions = questions;
            Question.Text = questions[0].question;
            Button_A.Content = questions[0].answers[0];
            Button_B.Content = questions[0].answers[1];
            Button_C.Content = questions[0].answers[2];
            Button_D.Content = questions[0].answers[3];

        }
        //funkcja odpowiadajaca za wyswietlanie kolejnych pytan
        private void showNextQuestion()
        {
            currentQuestion++;
            if (currentQuestion >= questions.Count)
            {
                ScoreWindow sW = new ScoreWindow(score, questions.Count, WrongQuestions);
                sW.Show();
                this.Close();
            }
            else
            {
                Question.Text = questions[currentQuestion].question;
                Button_A.Content = questions[currentQuestion].answers[0];
                Button_B.Content = questions[currentQuestion].answers[1];
                Button_C.Content = questions[currentQuestion].answers[2];
                Button_D.Content = questions[currentQuestion].answers[3];
            }
        }
        //klikasz odpowiedzi
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button.Name == "Button_A")
            {   //zwraca true/false poprawnej odpowiedzi
                if (questions[currentQuestion].checkAnswer((string)button.Content))
                {
                    score++;
                }
                else {
                    WrongQuestions[temp] = Question.Text;
                    temp++;
                }
            }
            else if (button.Name == "Button_B")
            {
                if (questions[currentQuestion].checkAnswer((string)button.Content))
                {
                    score++;
                }
                else
                {
                    WrongQuestions[temp] = Question.Text;
                    temp++;
                }
            }
            else if (button.Name == "Button_C")
            {
                if (questions[currentQuestion].checkAnswer((string)button.Content))
                {
                    score++;
                }
                else
                {
                    WrongQuestions[temp] = Question.Text;
                    temp++;
                }
            }
            else if (button.Name == "Button_D")
            {
                if (questions[currentQuestion].checkAnswer((string)button.Content))
                {
                    score++;
                }
                else
                {
                    WrongQuestions[temp] = Question.Text;
                    temp++;
                }
            }
            showNextQuestion();
        }
    }
}
