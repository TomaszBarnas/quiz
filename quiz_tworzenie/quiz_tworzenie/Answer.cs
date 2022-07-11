using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz_tworzenie
{
    class Answer
    {
        public string O1 { get; set; }
        public string O2 { get; set; }
        public string O3 { get; set; }
        public string O4 { get; set; }

        public bool first { get; set; }
        public bool second { get; set; }
        public bool third { get; set; }
        public bool fourth { get; set; }
        
        //public int Prawidlowa { get; set; }
        public Answer(string odpowiedz1, string odpowiedz2, string odpowiedz3, string odpowiedz4, bool First, bool Second, bool Third, bool Fourth/* int prawidlowa*/)
        {
            O1 = odpowiedz1;
            O2 = odpowiedz2;
            O3 = odpowiedz3;
            O4 = odpowiedz4;
            first = First;
            second = Second;
            third = Third;
            fourth = Fourth;
            
            //Prawidlowa = prawidlowa;
        }

        public override string ToString()
        {
            return $"Odpowiedz1: {O1}, Odpowiedz2: {O2}, Odpowiedz3: {O3}, Odpowiedz4: {O4}";
        }
    }
}
