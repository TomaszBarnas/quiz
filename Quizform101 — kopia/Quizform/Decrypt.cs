using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizForm
{
	public static class Decrypt
	{

		
		public static string Decipher(string input, int key)
		{
            string line = "";
            var alf = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var x = input.Split(' ');
            foreach (string p in x)
            {

                char[] word = p.ToCharArray();
                for (int j = 0; j < word.Length; j++)
                {

                    if (alf.Contains(word[j]))
                    {
                        var c = (alf.IndexOf(word[j]) + key) % alf.Length;
                        if (c < 0)
                        { word[j] = alf[alf.Length + c]; }
                        else
                            word[j] = alf[c];

                    }
                }
                string w = new string(word);
                line += w + " ";

            }
            return line;
		}
	}
}
