using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movig_dragon
{
    internal class Player :PlayerBase
    {
        public string drawing = "○";
        public string playerName = "1P";


        public void Render() // 최종적으로, 주어진 플레이어의 좌표값대로 그려주기만 함
        {
            Console.SetCursorPosition(arrX[0], arrY[0]);
            Console.Write(playerName);
            for (int i = 1; i <= count; i++)
            {
                Console.SetCursorPosition(arrX[i], arrY[i]);
                Console.Write(drawing); 
            }
        }


    }
}
