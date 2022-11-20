using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace racing_game
{
    internal class ObjectBase
    {

        public int PosX { get; set; }
        public int PosY { get; set; }

        public void Render(string drawing)
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.Write("■");
        }


    }
}
