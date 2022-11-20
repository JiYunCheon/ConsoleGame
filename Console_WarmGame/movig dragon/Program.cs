using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movig_dragon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameLoop gl = new GameLoop();

            // 0.생성단계
            gl.Awake();
            // 1.초기화
            gl.Start();

            while (true)
            {
                gl.Update();
                gl.Render();
            }
        }
    }
}