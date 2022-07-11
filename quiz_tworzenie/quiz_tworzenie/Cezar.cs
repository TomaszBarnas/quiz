using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz_tworzenie
{
    class Cezar : Interface1
    {
        public List<string> szyfr(List<string> quiz, int mov)
        {

            List<string> n = new List<string>();

            for (int i = 0; i < quiz.Count; i++)
            {
                string line = "";
                var alf = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
                var x = quiz[i].Split(' ');
                foreach (string p in x)
                {

                    char[] word = p.ToCharArray();
                    for (int j = 0; j < word.Length; j++)
                    {

                        if (alf.Contains(word[j]))
                        {
                            var c = (alf.IndexOf(word[j]) + mov) % alf.Length;
                            if (c < 0)
                            { word[j] = alf[alf.Length + c]; }
                            else
                                word[j] = alf[c];

                        }
                    }
                    string w = new string(word);
                    line += w + " ";

                }
                n.Add(line);
            }
            return n;
        }
    }
}
