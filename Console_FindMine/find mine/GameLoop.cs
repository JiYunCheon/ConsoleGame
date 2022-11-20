using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace find_mine
{
    internal class GameLoop
    {
        Map map;
        //콘솔 창 크기 
        int Width = 63;
        int Height = 32;

        //게임 클리어와 게임오버를 확인 할 변수
        bool gameover = true;
        bool gameclear = true;

        //지뢰에 깃발을 세운 것 을 저장할 변수 
        public int Clear = 0;
       
        //생성 
        public void Awake()
        {
            Console.BufferWidth = Console.WindowWidth = Width;
            Console.BufferHeight = Console.WindowHeight = Height;
            Console.CursorVisible = false;

            map = new Map();
        }

        //처음 플레이어 위치와 맵의 위치
        public void start()
        {
            map.Start();
            map.StartP();
            map.Render();
        }

        //위치 변화
        public void Update()
        {
            //게임 오버가 false가 되면 게임 오버 
            if (gameover == false) return;

            //게임 클리어가 false가 되면 게임 클리어 
            if (gameclear == false) return;

            //클리어 값 초기화 
            Clear = 0;

            //키 입력 시 실행
            if (Console.KeyAvailable)
            {
                //플레이어 이동 
                map.PlayerMove();

                //지뢰에 스페이스바를 누르면 게임오버
                if (map.save[map.pos_y, map.pos_x] == 109)
                {
                    gameover = false;
                }

                //지뢰에 A를 누르면 깃발 생성 후 클리어 값 증가 
                for (int i = 0; i < map.N_bomb; i++)
                {
                    if ((map.save[map.boomX[i], map.boomY[i]])==10009)
                    {
                        Clear++;
                    }
                }

                //클리어 값이 지뢰 생성 개수랑 같을 경우 게임 클리어
                if (Clear == map.N_bomb)
                {
                    gameclear = false;
                }

                
            }

        }

        //출력
        public void Render()
        {
            Console.Clear();
            //키 설정에 따른 문자 출력
            map.mapRender();

            //게임 오버시 출력
            if (gameover== false)
            {
                Console.SetCursorPosition(map.arrX/2+1, map.arrX+2);
                Console.Write("GAME OVER!!");
            }

            //게임 클리어시 출력
            if (gameclear == false)
            {
                Console.SetCursorPosition(map.arrX / 2 + 1, map.arrX + 2);
                Console.Write("GAME CLEAR!!");
            }
            
        }


    }
}
