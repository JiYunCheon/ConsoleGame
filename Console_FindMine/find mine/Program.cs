using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace find_mine
{
    internal class Program
    {
        static void Main(string[] args)
        {

            GameLoop gl = new GameLoop();

            gl.Awake();
            gl.start();
            while(true)
            {
                gl.Update();
                gl.Render();
                Thread.Sleep(200);
            }
            

          
            
            
            





        }
    }
}
