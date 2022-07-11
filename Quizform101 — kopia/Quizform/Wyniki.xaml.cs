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

namespace QuizForm
{
    /// <summary>
    /// Interaction logic for ScoreWindow.xaml
    /// </summary>
    public partial class ScoreWindow : Window
    {
        private int score;
        private string[] wrongQuestions;
        public ScoreWindow(int score, int count, string[] wrongQuestions)
        {
            InitializeComponent();
            this.score = score;
            this.wrongQuestions = wrongQuestions;
            Show_Score.Text = score + "/" + count;

            for (int i=0;i<wrongQuestions.Length;i++)
            {
                Wrong_Questions.Items.Add(wrongQuestions[i]);
     
            }
        }

        private void New_Quiz_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mW = new MainWindow();
            mW.Show();
            this.Close();
        }

        private void Reset_Quiz_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mW = new MainWindow();
            mW.Show();
            this.Close();
        }
    }
}
