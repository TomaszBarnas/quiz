using System;
using System.Collections.Generic;
using System.IO;
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

namespace quiz_tworzenie
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// wykonał Kamil Rojek, razem z Tomaszem Barnasiem
    public partial class MainWindow : Window
    {
        bool x1 = false;
        bool x2 = false;
        bool x3 = false;
        bool x4 = false;
        List<Question> tab = new List <Question>();
        public MainWindow()
        {
            InitializeComponent();
            string[] files = Directory.GetFiles($@"C:/Users/kamil/Desktop/quiz_tworzenie/Quizy");

            for (int i = 0; i < files.Length; i++)
            {
                files[i] = files[i].Remove(0, 44); //musisz to spersonalizować sobie tak, żeby w combo box było tylko "nazwa.txt"
                combo.Items.Add(files[i]);
            }
        }

        private void button_Dodaj_Click(object sender, RoutedEventArgs e)
        {
            bool error = false;
            String pytanie = textBox_pytanie.Text;
            String odp1 = textBox_odp1.Text;
            String odp2 = textBox_odp2.Text;
            String odp3 = textBox_odp3.Text;
            String odp4 = textBox_odp4.Text;
            Button btn = (Button)sender;
            string content = btn.Content + "";


            //Save k = new Save();
            //k.read();
            
            


            if (textBox_odp1.Text == ""|| textBox_odp2.Text == ""|| textBox_odp3.Text == ""|| textBox_odp4.Text == ""|| textBox_pytanie.Text == "")
            {
                error = true;
            }
            if (error) { MessageBox.Show("Nie wypełniłeś wszystkich pól!"); }
            if (!error)
            {
                Answer a = new Answer(textBox_odp1.Text, textBox_odp2.Text, textBox_odp3.Text, textBox_odp4.Text, x1, x2, x3, x4);
                Question quest = new Question(textBox_pytanie.Text, a);
                if (content == "Dodaj")
                {
                    tab.Add(quest);
                    listbox_pytania.Items.Add(quest);
                    MessageBox.Show("Poprawnie dodano pytanie!");
                    reset();
                }
                if (content == "Edytuj")
                {
                    if (listbox_pytania.SelectedIndex != -1)
                    {
                        int x = listbox_pytania.SelectedIndex;
                        tab[x].question = pytanie;
                        tab[x].O1 = odp1;
                        tab[x].O2 = odp2;
                        tab[x].O3 = odp3;
                        tab[x].O4 = odp4;
                        listbox_pytania.Items[x] = quest;
                        MessageBox.Show("Poprawnie edytowano pytanie!");
                        reset();
                    }
                    else
                    {
                        MessageBox.Show("Zaznacz Pole!");
                    }
                }
            }
        }

        private void button_Usun_Click(object sender, RoutedEventArgs e)
        {
            var x = listbox_pytania.SelectedItem;
            var y = listbox_pytania.SelectedIndex;
            if (listbox_pytania.SelectedIndex != -1)
            {
                listbox_pytania.Items.Remove(x);
                for (int i = y; i < tab.Count - 1; i++)
                {
                    tab[i] = tab[i + 1];
                }
                tab.RemoveAt(tab.Count - 1);
            }
            else
            {
                MessageBox.Show("Nie zaznaczyłeś elementu!");
            }
        }

        private void button_Edytuj_Click(object sender, RoutedEventArgs e)
        {
            var person = listbox_pytania.SelectedItem;
          
        }
        private void button_Zapisz_Click(object sender, RoutedEventArgs e)
        {
            if (QuizName.Text != "")
            {
                Interface1 obj = new Cezar();
                Quiz quiz = new Quiz(tab, QuizName.Text);

                List<string> lines = new List<string>();
                lines.Add(quiz.nazwa.ToString());
                foreach (Question quest in quiz.quiz)
                {
                    lines.Add(quest.question.ToString());
                    lines.Add(quest.O1.ToString());
                    lines.Add(quest.O2.ToString());
                    lines.Add(quest.O3.ToString());
                    lines.Add(quest.O4.ToString());
                    lines.Add($"{quest.first};{quest.second};{quest.third};{quest.fourth}");
                }
                Save.save(quiz,obj.szyfr(lines,9));
                reset();
                QuizName.Text = string.Empty;
                listbox_pytania.Items.Clear();
                tab.Clear();
            }
            else { MessageBox.Show("Podaj nazwę Quizu!"); }
            combo.Items.Clear();
            string[] files = Directory.GetFiles($@"C:/Users/kamil/Desktop/quiz_tworzenie/Quizy");

            for (int i = 0; i < files.Length; i++)
            {
                files[i] = files[i].Remove(0, 44);
                combo.Items.Add(files[i]);
            }
        }
        private void button_wczytaj_Click(object sender, RoutedEventArgs e)
        {
            if (combo.Text != string.Empty)
            {
                Interface1 obj = new Cezar();
                string filepath = $@"C:/Users/kamil/Desktop/quiz_tworzenie/Quizy/{combo.Text}";
                List<string> lines = File.ReadAllLines(filepath).ToList();
                List<Question> lista = Read.converter(obj.szyfr(lines, -9));

                for (int i = 0; i < lista.Count; i++)
                {
                    tab.Add(lista[i]);
                    listbox_pytania.Items.Add(lista[i]);

                }
                MessageBox.Show(lista[0].question);
            }
            else
            {
                MessageBox.Show("Zaznacz plik do wczytania!");
            }

            
        }
        
            private void reset()
        {
            textBox_pytanie.Text = string.Empty;
            textBox_odp1.Text    = string.Empty;
            textBox_odp2.Text    = string.Empty;
            textBox_odp3.Text    = string.Empty;
            textBox_odp4.Text    = string.Empty;
            checkbox_odp1.IsChecked = false;
            checkbox_odp2.IsChecked = false;
            checkbox_odp3.IsChecked = false;
            checkbox_odp4.IsChecked = false;  
        }
        

        private void ch1(object sender, RoutedEventArgs e)
        {
            if (checkbox_odp1.IsChecked == true)
                x1 = true;
            else
                x1= false;
        }
        private void ch2(object sender, RoutedEventArgs e)
        {
            if (checkbox_odp2.IsChecked == true)
                x2 = true;
            else
                x2 = false;
        }
        private void ch3(object sender, RoutedEventArgs e)
        {
            if (checkbox_odp3.IsChecked == true)
                x3 = true;
            else
                x3 = false;
        }
        private void ch4(object sender, RoutedEventArgs e)
        {
            if (checkbox_odp4.IsChecked == true)
                x4 = true;
            else
                x4 = false;
        }

    }
}

