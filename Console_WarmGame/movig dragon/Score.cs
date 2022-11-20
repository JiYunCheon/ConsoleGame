using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movig_dragon
{
    internal class Score
    {
        public int score = 0;
        public int score1 = 0;

        public void AddScore(int value)
        {
            score += value;
        }

        public void AddScore1(int value)
        {
            score1 += value;
        }

        public void Render()
        {
            Console.SetCursorPosition(0,0);
            Console.Write("Player 1 Score : {0}", score);
            Console.SetCursorPosition(0, 1);
            Console.Write("Player 2 Score : {0}", score1);
        }
    }
}
