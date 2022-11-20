using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movig_dragon
{
    internal class PlayerBase
    {
        public bool isAlive = true;
        public int count = 0; // 늘어난 꼬리의 갯수

        public int[] arrX = new int[10];
        public int[] arrY = new int[10];

        public int GetPosX() { return arrX[0]; }
        public int GetPosY() { return arrY[0]; }

        public int dir = 0; // 0 오른쪽, 1 위쪽, 2 왼쪽, 3 아래쪽

        public void Start(int m)
        {
            arrX[0] = GameLoop.BOARD_WIDTH / m;
            arrY[0] = GameLoop.BOARD_HEIGHT / m;
        }

        public void Update() // 플레이어의 '좌표값'만 변경
        {
            //LastTale();

            Reset(); // 꼬리들의 좌표값 변경

            switch (dir) // 이동처리
            {
                case 0://오른쪽
                    arrX[0] += 2;
                    if (arrX[0] >= GameLoop.BOARD_WIDTH)
                    {
                        arrX[0] = GameLoop.BOARD_WIDTH - 1;
                        isAlive = false;
                    }
                    break;

                case 1://위쪽
                    arrY[0]--;
                    if (arrY[0] < 0)
                    {
                        arrY[0] = 0;
                        isAlive = false;
                    }
                    break;

                case 2://왼쪽
                    arrX[0] -= 2;
                    if (arrX[0] < 0)
                    {
                        arrX[0] = 0;
                        isAlive = false;
                    }
                    break;

                case 3://아래쪽
                    arrY[0]++;
                    if (arrY[0] >= GameLoop.BOARD_HEIGHT)
                    {
                        arrY[0] = GameLoop.BOARD_HEIGHT - 1;
                        isAlive = false;
                    }
                    break;
            } // 머리의 좌표값 변경
        }
        public void LastTale() // 이동 전에 마지막 꼬리위치를 기억(꼬리 증가시 필요)
        {
            arrX[count + 1] = arrX[count]; // 안 쓰는 arrX[count+1] 자리를 임시로 사용
            arrY[count + 1] = arrY[count];
        }

        public void Reset() // 머리 좌표 변경 전에, 뒷꼬리들부터 하나씩 좌표값을 갱신
        {
            for (int i = 0; i < count; i++)
            {
                arrX[count - i] = arrX[count - i - 1];
                arrY[count - i] = arrY[count - i - 1];
            }
        }

        // 키 입력을 토대로 실행시키는 함수들(방향만 변경)
        public void move_Right()
        {
            dir = 0;
        }
        public void move_Left()
        {
            dir = 2;
        }
        public void move_Up()
        {
            dir = 1;
        }
        public void move_Down()
        {
            dir = 3;
        }



    }

}
