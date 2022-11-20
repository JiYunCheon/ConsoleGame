using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shooting_game
{
    internal class GameLoop
    {
        Player player;
        Bullet[] bullet= new Bullet[10];
        Score score;
        Enemy enemy;

        int Width = 50;
        int Height = 32;

        public void Awake()
        {
            Console.BufferWidth = Console.WindowWidth = Width;
            Console.BufferHeight = Console.WindowHeight = Height;
            Console.CursorVisible=false;

            player = new Player();
            enemy = new Enemy();
            score = new Score();

            //클래스 각 배열의 선언 
            for (int i = 0; i < bullet.Length; i++)
            {
                bullet[i] = new Bullet();
            }
        }

        //시작 위치
        public void Start()
        {
            player.Start();
            enemy.Start();
            
        }
        //위치 변화
        public void Update()
        {
            for (int i = 0; i < bullet.Length; i++)
            {
                //총알이 살아있을 때 업데이트
                if (bullet[i].IsAlive==true)
                {
                    bullet[i].Update();
                    if (bullet[i].bulletX==enemy.enemyX&&
                        bullet[i].bulletY==enemy.enemyY)
                    {
                        bullet[i].IsAlive = false;

                        enemy.refresh();

                        int add = 100;
                        score.addScore(add);

                    }
                }
            }
            
            if (Console.KeyAvailable)
            {
                //플레이어 이동과 총알생성
                ConsoleKeyInfo K = Console.ReadKey(true);
                switch(K.Key)
                {
                    case ConsoleKey.RightArrow:
                        player.Right();
                        break;
                    case ConsoleKey.LeftArrow:
                        player.Left();
                        break;
                    case ConsoleKey.Spacebar:

                        for (int i = 0; i < bullet.Length; i++)
                        {
                            if (bullet[i].IsAlive==false)
                            {
                                bullet[i].bulletX = player.playerX+1;
                                bullet[i].bulletY = player.playerY-1;
                                bullet[i].IsAlive = true;
                                //한 번 반복 후 브레이크 (총알 여러개 생성)
                                break;
                            }
                        }
                        break;
                }
            }
            
        }

        public void Render()
        {
            Console.Clear();

            player.Render();
            enemy.Render();
            score.Render();

            for (int i = 0; i < bullet.Length; i++)
            {
                //총알이 있을 때 랜더 
                if (bullet[i].IsAlive == true)
                    bullet[i].Render();
            }
           
        }

    }
}
