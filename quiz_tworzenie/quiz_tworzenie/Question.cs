using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz_tworzenie
{
    class Question : Answer
    {
        public string question;
        string o1;
        string o2;
        string o3;
        string o4;
        bool First;
        bool Second;
        bool Third;
        bool Fourth;

        public Question(string question,Answer odp) : base(odp.O1, odp.O2, odp.O3, odp.O4, odp.first, odp.second, odp.third, odp.fourth) // tablica instead of this shit
        {
            this.question = question;
            this.o1 = O1;
            this.o2 = O2;
            this.o3 = O3;
            this.o4 = O4;
            this.First = first;
            this.Second = second;
            this.Third = third;
            this.Fourth = fourth;

        }
        public override string ToString()
        {
            return $"Pytanie:{question}\nOdpowiedzi:{o1},{o2},{o3},{o4}\nTrue/False: 1.{First} 2.{Second} 3.{Third} 4.{Fourth}";
        }

    }
}
