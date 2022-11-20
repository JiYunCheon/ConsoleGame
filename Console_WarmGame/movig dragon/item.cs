using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movig_dragon
{
    internal class item
    {
        int pos_x, pos_y;
       
        public int GetPoX() { return pos_x; }
        public int GetPoY() { return pos_y; }
        

        //랜덤으로 생성 될 아이템 
        public void refreshPos()
        {
            Random rand = new Random();
     
            pos_x = rand.Next(GameLoop.BOARD_WIDTH);
            pos_y = rand.Next(GameLoop.BOARD_HEIGHT);

            if (pos_x%2==0&&pos_x>2)
            {
                pos_x -= 2;
            }
            else if(pos_x%2==1&&pos_x>0)
            {
                pos_x -= 1;
            }
        }

        public void Render()
        {
            Console.SetCursorPosition(pos_x, pos_y);
            Console.Write("■");
        }
    }
}
