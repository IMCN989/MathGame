using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    public  class MathGame
    {


        private GameHistory history = new GameHistory();

        public void Start()
        {
            bool exit = false;

            while (!exit)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice.ToLower())
                {
                    case "1":
                        PlayGame("addition");
                        break;
                    case "2":
                        PlayGame("subtraction");
                        break;
                    case "3":
                        PlayGame("division");
                        break;
                    case "4":
                        PlayGame("multiplication");
                        break;
                    case "5":
                        history.DisplayHistory();
                        break;
                    case "q":
                        Console.WriteLine("Goodbye!");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("\\n=== Math Game ===");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Division");
            Console.WriteLine("4. Multiplication");
            Console.WriteLine("5. View History");
            Console.WriteLine("q. Quit");
            Console.Write("Choose an option: ");
        }

        private void PlayGame(string operation)
        {
            MathProblem problem = new MathProblem(operation);
            Console.WriteLine($"Solve: {problem.Question}");
            int userAnswer = int.Parse(Console.ReadLine());

            if (problem.CheckAnswer(userAnswer))
            {
                Console.WriteLine("Correct!");
                history.AddResult($"Correct: {problem.Question} = {problem.CorrectAnswer}");
            }
            else
            {
                Console.WriteLine($"Wrong! The correct answer was {problem.CorrectAnswer}.");
                history.AddResult($"Incorrect: {problem.Question} = {problem.CorrectAnswer}");
            }
        }
    }
}
