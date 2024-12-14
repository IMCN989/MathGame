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

                //use below for validator class
                //string choice = InputValidator.GetValidatedCommand(
                //"Choose an option (1, 2, 3, 4, 5, q):", new string[] { "1", "2", "3", "4", "5", "q" });


                // Inline validation for menu choices
                string choice = Console.ReadLine()?.Trim().ToLower();
                if (choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5" || choice == "q")
                {
                    switch (choice)
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
                else
                {
                    Console.WriteLine("Invalid choice. Please enter 1, 2, 3, 4, 5, or q.");
                }
            }
        }

        private void DisplayMenu()
        {
            
            Console.WriteLine("\n=== Math Game ===");
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

            //use below for Validator class
            // int userAnswer = InputValidator.GetValidatedNumber(
            //"Enter your answer (a valid number):", int.MinValue, int.MaxValue);
            //int userAnswer = int.Parse(Console.ReadLine());

            int userAnswer;
            while (true)
            {
                Console.Write("Enter your answer: ");
                string input = Console.ReadLine();

                // Inline validation for numeric input
                if (int.TryParse(input, out userAnswer))
                {
                    break; // Valid input, exit the loop
                }
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            
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
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();

        }
    }
}
