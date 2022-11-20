using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shooting_game
{
    internal class Enemy
    {
        public int enemyX;
        public int enemyY;

        public void Start()
        {
            Random random = new Random();

            enemyX = random.Next(0, 50);
            enemyY = 3;
        }
        public void refresh()
        {
            Random random = new Random();
            enemyX = random.Next(0, 50);
            enemyY = 3;
        }

        public void Update()
        {
           
        }

        public void Render()
        {

            Console.SetCursorPosition(enemyX, enemyY);
            Console.Write("E");
        }
    }
}
