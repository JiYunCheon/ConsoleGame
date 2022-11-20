using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shooting_game
{
    internal class Score
    {
        int score = 0;
        public void addScore(int add)
        {
            score += add;
        }

        public void Render()
        {
            Console.SetCursorPosition(0,0);
            Console.Write("Score : {0}", score);

        }
    }
}
