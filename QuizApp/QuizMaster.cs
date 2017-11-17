using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizApp
{
    class QuizMaster
    {
        private List<QuestionCard> questions;
        private int goodAnswers;
        
        static void Main(string[] args)
        {
            new QuizMaster();
        }

        public QuizMaster()
        {
            questions = new List<QuestionCard>()
            {
                new OpenQuestionCard() {
                Question = "Wat is 1 + 1?",
                Answer = "2",
                Catagorie = "Wiskunde",
                Moeilijkheidsgraad = 1
                },
                new OpenQuestionCard() {
                Question = "Hoeveel punten moet je hebben voor het behalen van een P?",
                Answer = "60",
                Catagorie = "Studie",
                Moeilijkheidsgraad = 2
                },
                new OpenQuestionCard() {
                Question = "In welke profincie ligt Groningen",
                Answer = "Groningen",
                Catagorie = "Topografie",
                Moeilijkheidsgraad = 1
                },
                new OpenQuestionCard() {
                Question = "Waar staat 'PS4' voor?",
                Answer = "Playstation 4",
                Catagorie = "Gaming",
                Moeilijkheidsgraad = 3
                },
                new ChoiceQuestionCard() {
                Question = "In welke programmeertaal is deze app gemaakt?",
                Answer = "C#",
                Choices = new List<string>(){"Java", "C#", "HTML"},
                Catagorie = "ICT",
                Moeilijkheidsgraad = 3
                },
                new ChoiceQuestionCard() {
                Question = "Bij welke difrentiatie ga voornamelijk programeren?",
                Answer = "SE",
                Choices = new List<string>(){"SE", "NSE", "IMS"},
                Catagorie = "Studie",
                Moeilijkheidsgraad = 2
                },
                new ChoiceQuestionCard() {
                Question = "Welke formule hoort bij de wet van Ohm?",
                Answer = "U=I*R",
                Choices = new List<string>(){"P=U*I", "R=U/I", "U=I*R"},
                Catagorie = "Natuurkunde",
                Moeilijkheidsgraad = 2
                }
            };
        
            goodAnswers = 0;
            List<QuestionCard> sortedQuestions = SortQuestions("catagorie", questions);
            DisplayMoeilijkheidsgraadQuestions(1, sortedQuestions);
        }
        
        private List<QuestionCard> SortQuestions(string order, List<QuestionCard> unsortedQuestions)
        {
            switch (order)
            {
                case "moeilijkheidsgraad":
                    var v1 = questions.OrderBy(q => q.Moeilijkheidsgraad).ToList();
                    return v1;
                case "catagorie":
                    var v2 = questions.OrderBy(q => q.Catagorie).ToList();
                    return v2;
            }
            return null;
        }

        private void DisplayMoeilijkheidsgraadQuestions(int moeilijkheidsgraad, List<QuestionCard> questionCards)
        {
            List<QuestionCard> questionsToDisplay = questionCards.Where(q => q.Moeilijkheidsgraad.Equals(moeilijkheidsgraad)).ToList();
            AskQuestions(questionsToDisplay);
        }

        private void DisplayCatagorieQuestions(string catagorie, List<QuestionCard> questionCards)
        {
            List<QuestionCard> questionsToDisplay = questionCards.Where(q => q.Catagorie.Equals(catagorie)).ToList();
            AskQuestions(questionsToDisplay);
        }

        private void AskQuestions(List<QuestionCard> questionCards)
        {
            Console.WriteLine("Hier zijn een aantal vragen. De antwoorden zijn NIET hoofdlettergevoel. Denk wel aan eventuele spaties.");
            foreach (QuestionCard q in questionCards)
            {
                PresentQuestion(q);
            }
            Console.WriteLine(string.Format("Van de {0} vragen heb je er {1} goed.\nEINDE QUIZ\n...Press any key to exit...", questionCards.Count, goodAnswers));
            Console.ReadLine();
            goodAnswers = 0;
        }
        
        public void PresentQuestion(QuestionCard q)
        {
            q.Display();
            Console.WriteLine("Your answer: ");
            string response = Console.ReadLine();
            bool result = q.CheckAnswer(response);
            Console.WriteLine();
            if (result) { goodAnswers++; }
        }
    }
}
