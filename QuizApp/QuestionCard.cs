using System;
using System.Collections.Generic;

namespace QuizApp
{
    public class QuestionCard
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public List<string> Choices { get; set; }
        public string Catagorie { get; set; }
        public int Moeilijkheidsgraad { get; set; }

        public void Display()
        {
            if (Choices != null)
            {
                Console.WriteLine("Meerkeuzevraag: " + Question + "\nJe keuzes zijn:");
                foreach(string a in Choices)
                {
                    Console.WriteLine(a);
                }
            }
            else
            {
                Console.WriteLine("Openvraag: " + Question);
            }
        }

        public bool CheckAnswer(string response)
        {
            if (string.Equals(Answer, response, StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("Uw antwoord is goed!");
                return true;
            }
            else
            {
                Console.WriteLine("Uw antwoord is fout.");
                return false;
            }
        }
    }
}