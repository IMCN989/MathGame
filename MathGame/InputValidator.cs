using System;

namespace MathGame
{
    public static class InputValidator
    {
        // Validates numeric input within a range
        public static int GetValidatedNumber(string prompt, int min, int max)
        {
            int result;
            bool isValid;

            do
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                isValid = int.TryParse(input, out result) && result >= min && result <= max;

                if (!isValid)
                {
                    Console.WriteLine($"Invalid input. Please enter a number between {min} and {max}.");
                }
            } while (!isValid);

            return result;
        }

        // Validates command input from a predefined list
        public static string GetValidatedCommand(string prompt, string[] validCommands)
        {
            string command;

            do
            {
                Console.WriteLine(prompt);
                command = Console.ReadLine()?.Trim().ToLower();

                if (Array.Exists(validCommands, cmd => cmd == command))
                {
                    return command;
                }

                Console.WriteLine("Invalid command. Please try again.");
            } while (true);
        }
    }
}
