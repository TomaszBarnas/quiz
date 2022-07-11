using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizForm
{
    public class Pytania
    {
        public string question { get; }
        public string[] answers { get; set; }
        private string correctAnswer;


        public Pytania(string question, String[] answers, string correctAnswer)
        {
            this.question = question;
            this.answers = answers;
            this.correctAnswer = correctAnswer;
        }

      

        public override string ToString()
        {
            string q = $"{question} poprawna: {correctAnswer} odpA: {answers[0]} odpB: {answers[1]} odpC: {answers[2]} odpD: {answers[3]}";
            return q;
        }


        public Boolean checkAnswer(String playerAnswer)
        {
            if (playerAnswer == correctAnswer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


}
