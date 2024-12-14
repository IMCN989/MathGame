using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    public class GameHistory
    {

        private List<string> history = new List<string>();

        public void AddResult(string result)
        {
            history.Add(result);
        }

        public void DisplayHistory()
        {
            Console.WriteLine("\\n=== Game History ===");
            if (history.Count == 0)
            {
                Console.WriteLine("No games played yet.");
                return;
            }

            for (int i = 0; i < history.Count; i++)
            {
                Console.WriteLine($"Game {i + 1}: {history[i]}");
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
