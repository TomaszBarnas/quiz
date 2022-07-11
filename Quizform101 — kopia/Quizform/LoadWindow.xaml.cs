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
    /// Interaction logic for LoadWindow.xaml
    /// </summary>
    public partial class LoadWindow : Window
    {
        private String Selected_Quiz;

        public LoadWindow(String Selected_Quiz)
        {
            InitializeComponent();
            this.Selected_Quiz = Selected_Quiz;
            string temp = "";
            for (int i = 0; i < Selected_Quiz.Length; i++)
            {
                temp = Selected_Quiz.Remove(0, 44); //musisz to spersonalizować sobie tak, żeby w combo box było tylko "nazwa.txt"
            }
            Selected_Quiz_Text.Text = temp;
        }

        private void Choose_Button_load_Click(object sender, RoutedEventArgs e)
        {

            if (Coding_methods.SelectedIndex == 0)
            {
                var questions = Odczyt.Load(Selected_Quiz, -9);
                QuizWindow qW = new QuizWindow(questions);
                qW.Show();
                this.Close();
            }
        


        }
    }
}
