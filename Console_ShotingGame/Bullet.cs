using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shooting_game
{
    internal class Bullet
    {
        public int bulletX { get; set; }
        public int bulletY { get; set; }

        public bool IsAlive = true;
        int count = 0;
        //총알의 위치 변화
        public void Update()
        {
            if (IsAlive == false)
                return;

          bulletY--;
            if (bulletY<0)
            {
                IsAlive = false;
            }
        }
        public void Render()
        {
            if (IsAlive == false)
                return;

            Console.SetCursorPosition(bulletX, bulletY);
            Console.Write("B");
        }
    }
}
