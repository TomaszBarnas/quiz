using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuizForm
{
    public static class Odczyt
    {
        public static List<Pytania> Load(String path, int key)
        {
            List<Pytania> questions = new List<Pytania>();

            if (File.Exists(path))
            {
                string question = String.Empty;
                string[] answers = new string[5];
                string correctAnswer = "";
                string[] dane = File.ReadAllLines(path);

                int i = 0;
                int j = 0;
                foreach (string line in dane)
                {

                    string line1 = Decrypt.Decipher(line,key);
                    if (i == 1)
                    {
                        answers = new string[5];
                        question = line1;
                    }
                    else if (i == 2)
                    {
                        answers[j] = line1;
                        j++;


                    }
                    else if (i == 3)
                    {
                        answers[j] = line1;
                        j++;
                    }
                    else if (i == 4)
                    {
                        answers[j] = line1;
                        j++;
                    }
                    else if (i == 5)
                    {
                        answers[j] = line1;
                        j++;
                    }
                    else if (i == 6)
                    {
                        int x = 0;
                        bool flag = false;
                        foreach (String a in line1.Split(';'))
                        {
                            if (a != "False" && a!="FalSe" && flag==false)
                            {
                                flag = true;
                                correctAnswer= answers[x];
                                var temp = new Pytania(question, answers, correctAnswer);
                                questions.Add(temp);
                            }
                            x++;
                        }
                        j = 0;
                        i = 0;

                    }
                    i++;
 
                }
            }
            else
            {
                MessageBox.Show("Plik z danymi nie istnieje!");
            }

            return questions;
        }
    }
}
