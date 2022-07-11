using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz_tworzenie
{
    class Read
    {
        public static List<Question> converter(List<string> lines)
        {
            String pytanie = "";
            String odp1 = "";
            String odp2 = "";
            String odp3 = "";
            String odp4 = "";
            bool o1 = false;
            bool o2 = false;
            bool o3 = false;
            bool o4 = false;
            string[] spr;
            List<Question> tablica = new List<Question>();
            var x = (lines.Count - 1) / 6; 

            for (int i = 0; i < x; i++)
            {

                for (int j = 1 + i * 6; j < 7 + i * 6; j++)
                {
                    if ((j - i * 6) == 1) { pytanie = lines[j].ToString(); }
                    else if ((j - i * 6) == 2) { odp1 = lines[j].ToString(); }
                    else if ((j - i * 6) == 3) { odp2 = lines[j].ToString(); }
                    else if ((j - i * 6) == 4) { odp3 = lines[j].ToString(); }
                    else if ((j - i * 6) == 5) { odp4 = lines[j].ToString(); }
                    else if ((j - i * 6) == 6)
                    {
                        spr = lines[j].ToString().Split(';');
                        if (spr[0] == "True")
                            o1 = true;
                        else
                            o1 = false;
                        if (spr[1] == "True")
                            o2 = true;
                        else
                            o2 = false;
                        if (spr[2] == "True")
                            o3 = true;
                        else
                            o3 = false;
                        if (spr[3] == "True")
                            o4 = true;
                        else
                            o4 = false;
                    }
                }
                Answer a = new Answer(odp1, odp2, odp3, odp4, o1, o2, o3, o4);
                Question quest = new Question(pytanie, a);
                tablica.Add(quest);
            }

            return tablica;
        }
    }
}
