using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace racing_game
{
    internal class Player : ObjectBase
    {
        string drwaing = "■";
        #region 플레이어 위치, 이동
        public void Start()
        {
            PosX = 15;
            PosY = 30;
        }
        public void Right()
        {
            PosX++;
            if (PosX >= 50)
                PosX = 50;
        }
        public void Left()
        {
            PosX--;
            if (PosX <= 0)
                PosX = 0;
        }
        #endregion

        public void Render()
        {
            base.Render(drwaing);
        }

    }
}
