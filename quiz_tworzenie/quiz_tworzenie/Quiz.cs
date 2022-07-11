using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz_tworzenie
{
    class Quiz 
    {
        public List<Question> quiz;
        public string nazwa;

        public Quiz(List<Question> question, string nazwa)
        {
            this.quiz = question;
            this.nazwa = nazwa;
        }
 
    }
}
