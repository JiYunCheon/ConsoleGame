using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace racing_game
{
    internal class Item : ObjectBase
    {
        public void Render()
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.Write("♡");
        }

    }
}
