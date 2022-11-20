using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movig_dragon
{
    internal class GameLoop 
    {
        Player player1;
        Player player2;
        item item;
        Score score;

        // 수정 하기 편하도록 
        public const int BOARD_WIDTH = 60;
        public const int BOARD_HEIGHT = 30;
        int oldtime = 0;
        //게임 오버
        bool gameover = false; 
        
        public void Awake()
        {
            Console.BufferWidth = Console.WindowWidth = BOARD_WIDTH;
            Console.BufferHeight = Console.WindowHeight = BOARD_HEIGHT;
            Console.CursorVisible = false;

            player1 = new Player();
            player2 = new Player();
            player2.drawing = "◎";
            player2.playerName = "2P";
            item = new item();
            score = new Score();
          

        } // 사전 준비 작업


        public void Start()
        {
            player1.Start(2);
            player2.Start(3);

            item.refreshPos(); // 처음 아이템 시작 위치
        } // 시작 작업


        public void Update()
        {
            if (gameover == true) return; // 게임오버 시 업데이트 생략(Render 실행)


            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo K = Console.ReadKey(true);
                switch (K.Key)
                {
                    case ConsoleKey.RightArrow:
                        player1.move_Right();
                        break;
                    case ConsoleKey.LeftArrow:
                        player1.move_Left();
                        break;
                    case ConsoleKey.UpArrow:
                        player1.move_Up();
                        break;
                    case ConsoleKey.DownArrow:
                        player1.move_Down();
                        break;
                    case ConsoleKey.D:
                        player2.move_Right();
                        break;
                    case ConsoleKey.A:
                        player2.move_Left();
                        break;
                    case ConsoleKey.W:
                        player2.move_Up();
                        break;
                    case ConsoleKey.S:
                        player2.move_Down();
                        break;
                }
            } // 키 입력에 맞춰 플레이어에 명령


            int coolTime = 200; // 업데이트 반복 주기
            int curTime = Environment.TickCount & Int32.MaxValue;
            if (curTime - oldtime > coolTime)
            {

                Console.Clear();
                player1.Update(); // 플레이어1 이동 처리
                player2.Update(); // 플레이어2 이동 처리

                oldtime = curTime;
            }

            if (player1.isAlive == false)
            {
                gameover = true;
                return;
            } // 벽에 닿으면 게임 오버
            if (player2.isAlive == false)
            {
                gameover = true;
                return;
            } // 벽에 닿으면 게임 오버

            //플레이어들이 겹칠때 게임 오버
            if (player1.GetPosX() == player2.GetPosX() &&
              player1.GetPosY() == player2.GetPosY())
            {
                gameover = true;
                return;
            }

            //1p가 2p의 꼬리와 만날 때
            for (int i = 0; i < player2.count; i++)
            {
                if (player1.GetPosX() == player2.arrX[player2.count - i] &&
    player1.GetPosY() == player2.arrY[player2.count - i])
                {
                    gameover = true;
                    return;
                }
            }

            //2p가 1p의 꼬리와 만날 때
            for (int i = 0; i < player1.count; i++)
            {
                if (player2.GetPosX() == player1.arrX[player1.count - i] &&
    player2.GetPosY() == player1.arrY[player1.count - i])
                {
                    gameover = true;
                    return;
                }
            }

            // 이때 아이템과 겹친다면?
            if (player1.GetPosX() == item.GetPoX() && player1.GetPosY() == item.GetPoY())
            {
                item.refreshPos(); // 공통 아이템 리셋
                score.AddScore(100); // 플레이어1의 점수 증가
                player1.count++; // 플레이어1의 꼬리수 증가
            }

            if (player2.GetPosX() == item.GetPoX() && player2.GetPosY() == item.GetPoY())
            {
                item.refreshPos(); // 공통 아이템 리셋
                score.AddScore1(100); // 플레이어2의 점수 증가
                player2.count++; // 플레이어2의 꼬리수 증가
            }
        }


        public void Render()
        {
            
            if (gameover == true)
            {
                if(score.score>score.score1)
                {
                    Console.SetCursorPosition(GameLoop.BOARD_WIDTH / 2, GameLoop.BOARD_HEIGHT / 2);
                    Console.Write("Player 1 WIN");
                }
                else if (score.score1>score.score)
                {
                    Console.SetCursorPosition(GameLoop.BOARD_WIDTH / 2, GameLoop.BOARD_HEIGHT / 2);
                    Console.Write("Player 2 WIN");
                }
                else
                {
                    Console.SetCursorPosition(GameLoop.BOARD_WIDTH / 2, GameLoop.BOARD_HEIGHT / 2);
                    Console.Write("GAME OVER!!!");
                }
               
            } // 게임오버 출력

            player1.Render();
            player2.Render();
            item.Render();
            score.Render();
        }
    }
}
