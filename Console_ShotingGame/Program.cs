using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace shooting_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameLoop gl = new GameLoop();

            gl.Awake();
            gl.Start();

            while(true)
            {
                gl.Update();
                gl.Render();
                Thread.Sleep(100);
            }    


        }
    }
}
