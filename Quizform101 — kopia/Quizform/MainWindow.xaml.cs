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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Threading;

namespace QuizForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// Wykonał Tomasz Barnaś z Kamilem Rojkiem
    public partial class MainWindow : Window
    {
        DispatcherTimer _timer;
        TimeSpan _time;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Load_Button_Click(object sender, RoutedEventArgs e)
        {
            //sciezka
            String Selected_path = "C:/Users/kamil/Desktop/quiz_tworzenie/Quizy";
            String[] files = Directory.GetFiles(Selected_path);

            //ładuje quizy do listy
            Load_Quiz.Items.Clear();

            foreach (string file in files)
            {
                string temp = "";
                for (int i = 0; i < file.Length; i++)
                {
                    temp = file.Remove(0, 44); //musisz to spersonalizować sobie tak, żeby w combo box było tylko "nazwa.txt"
                }
                Load_Quiz.Items.Add(temp);
            }

            if (Load_Quiz.Items.Count == 0)
            {
                MessageBox.Show("Brak quizów do rozwiązania!");
            }

        }

        private void Choose_Button_Click(object sender, RoutedEventArgs e)
        {
            String Selected_Quiz;
            if (Load_Quiz.SelectedItem != null)
            {
                Selected_Quiz = "C:/Users/kamil/Desktop/quiz_tworzenie/Quizy/" + Load_Quiz.SelectedItem.ToString();
                LoadWindow lW = new LoadWindow(Selected_Quiz);
                lW.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wybierz quiz!");
            }

        }
    }
}
