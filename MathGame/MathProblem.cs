using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{

    //a class to handle the generation of math problems and verify user answers.
    public class MathProblem
    {


        private static Random random = new Random();
        public string Question { get; private set; }
        public int CorrectAnswer { get; private set; }
        public MathProblem(string operation)
        {

            GenerateProblem(operation);
                
        }

        private void GenerateProblem(string operation)
        {
            int num1, num2;
            switch (operation.ToLower())
            {
                case "addition":
                    num1 = random.Next(1, 101);
                    num2 = random.Next(1, 101);
                    CorrectAnswer = num1 + num2;
                    Question = $"{num1} + {num2}";
                    break;
                    // Implement other cases (subtraction, multiplication, division)
            }
        }

        public bool CheckAnswer(int userAnswer)
        {
            return userAnswer == CorrectAnswer;
        }



    }
}
