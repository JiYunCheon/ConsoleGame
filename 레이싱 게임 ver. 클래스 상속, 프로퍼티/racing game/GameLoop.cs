using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace racing_game
{
    internal class GameLoop
    {
        Player player;
        Item[] item;
        Enemy[] enemy;

        //점수
        public int score;
        //목숨
        int LifePoint = 3;

        //게임오버, 게임 클리어
        public bool GameOver = false;
        public bool GameClear = false;

        public void Awake()
        {
            Console.CursorVisible = false;
            Console.BufferWidth = Console.WindowWidth = 51;
            Console.BufferHeight = Console.WindowHeight = 35;

        }

        //처음 플레이어, 적  위치
        public void Start()
        {   
            player = new Player();
            item = new Item[5];
            enemy = new Enemy[20];

            Random random = new Random();
            //클래스 배열의 선언과 값 초기화
            for (int i = 0; i < item.Length; i++)
            {
                item[i] = new Item()
                {
                    PosX = random.Next(51),
                    PosY = random.Next(5)
                };
            }

            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i] = new Enemy()
                {
                    PosX = random.Next(51),
                    PosY = random.Next(5)
                };
            }

            player.Start();
        }

        //위치 변화
        public void Update()
        {
            Random random = new Random();

            //라이프 포인트가 0이되면 게임 오버
            if (LifePoint == 0)
            {
                GameOver = true;
            }

            //스코어가 500점이 되면 게임 클리어
            if(score==500)
            {
                GameClear = true;
            }

            //키를 눌렸을 때 실행
            if (Console.KeyAvailable == true)
            {
                ConsoleKeyInfo K = Console.ReadKey();
                switch (K.Key)
                {
                    case ConsoleKey.RightArrow:
                        player.Right();
                        break;
                    case ConsoleKey.LeftArrow:
                        player.Left();
                        break;
                }
            }

            //적 y값 증가
            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i].PosY++;
            }

            //아이템 y값 증가
            for (int i = 0; i < item.Length; i++)
            {
                item[i].PosY++;
            }

            //적의 y값이 31이 넘어갈 경우 위치 초기화
            for (int i = 0; i < enemy.Length; i++)
            {
                if (enemy[i].PosY >= 31)
                {
                    enemy[i].PosX = random.Next(51);
                    enemy[i].PosY = random.Next(5);
                }
            }

            //아이템의 y값이 31이 넘어갈 경우 위치 초기화
            for (int i = 0; i < item.Length; i++)
            {
                if (item[i].PosY >= 31)
                {
                    item[i].PosX = random.Next(51);
                    item[i].PosY = random.Next(5);
                }
            }

            //아이템의 값이 플레이어랑 같을 경우
            //score에 100점을 더하고 위치 초기화
            for (int i = 0; i < item.Length; i++)
            {
                if (player.PosX == item[i].PosX && player.PosY== item[i].PosY)
                {
                    score += 100;
                    item[i].PosX = random.Next(51);
                    item[i].PosY = random.Next(5);
                }
            }

            //적이 플레이어 위치랑 같을 경우
            //LifePoint 를 깎고 위치 초기화
            for (int i = 0; i < enemy.Length; i++)
            {
                if (enemy[i].PosX == player.PosX && enemy[i].PosY== player.PosY)
                {
                    LifePoint--;
                    enemy[i].PosX = random.Next(51);
                    enemy[i].PosY = random.Next(5);
                }
            }

        }
        
        public void Render()
        {
            Console.Clear();
            //게임오버 출력
            if (GameOver == true)
            {
                Console.SetCursorPosition(20, 20);
                Console.Write("GAME OVER");
                return;
            }

            //게임 클리어 출력
            if (GameClear==true)
            {
                Console.SetCursorPosition(20, 20);
                Console.Write("GAME CLEAR");
                return;
            }
            
            //점수 출력
            Console.SetCursorPosition(1, 1);
            Console.Write("Score : {0} ", score);

            //목숨 출력
            for (int i = 0; i < LifePoint; i++)
            {
                Console.Write("♥");
            }

            //플레이어 출력
            player.Render();

            //적 출력, 아이템 출력
            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i].Render();
            }
            for (int i = 0; i < item.Length; i++)
            {
                item[i].Render();
            }
        }
    }
}
