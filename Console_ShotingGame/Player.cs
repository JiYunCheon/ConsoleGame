using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shooting_game
{
    internal class Player
    {
        public int playerX;
        public int playerY;

        public void Start()
        {
            playerX = 25;
            playerY = 30;
                
        }

        //플레이어 오른쪽 이동
        public void Right()
        {
            playerX++;
            if(playerX>=50)
            {
                playerX =49;
            }
        }
        public void Left()
        {
            playerX--;
            if (playerX <= 0)
            {
                playerX = 1;
            }
        }
        public void Render()
        {
            Console.SetCursorPosition(playerX, playerY);
            Console.Write("▲");
        }
    }
}
