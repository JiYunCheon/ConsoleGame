using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace find_mine
{
    internal class Map
    {
        GameLoop gl=new GameLoop();
       
        public int count = 1; //지뢰개수를 세어줄 변수

        //맵의 크기와 지뢰의 개수를 저장 할 변수
        public int arrX = 0;
        public int N_bomb = 0;

        //깃발의 개수를 제한할 변수
        public int Limit = 0;

        //플레이어 위치
        public int pos_x;
        public int pos_y;
        
        //맵의 값을 저장 할 배열
        public int[,] save = new int[50, 50];

        //지뢰의 최대 개수
        public int[] boomX = new int[100];
        public int[] boomY = new int[100];

        //맵 설정
        public void Start()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("맵의 최대 크기는 25입니다.") ;
            Console.Write("맵의 크기를 입력하세요 : ");
            arrX = int.Parse(Console.ReadLine()); //맵 사이즈 받기
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A키는 깃발 설치,S키는 깃발 삭제입니다");
            Console.WriteLine("깃발은 지뢰 개수 만큼 사용 가능합니다.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("맵크기보다 지뢰의 개수를 적게 입력해 주세요");
            Console.WriteLine("지뢰의 최대 개수는 100개입니다.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("지뢰 개수를 입력하세요 : ");
            N_bomb = int.Parse(Console.ReadLine());//지뢰의 개수를 받음

            Random random = new Random();
            //맵사이즈 중 랜덤 으로 x,y값을 입력받은 개수만큼 받기
            for (int i = 0; i < N_bomb; i++)
            {
                boomX[i] = random.Next(1, arrX - 1); //테두리는 지뢰가 생성 안됨
            }//x값
            for (int i = 0; i < N_bomb; i++)
            {
                boomY[i] = random.Next(1, arrX - 1);
            }//y값
            //깃발의 개수는 지뢰 개수 만큼 
            Limit = N_bomb-1; 
        }
        //플레이어 시작위치
        public void StartP()
        {
            pos_x = arrX/2;
            pos_y = arrX/2;
        }

        //입력받은 맵의 크기와 지뢰들을 출력
        public void Render()
        {
            //맵 테두리를 생성하기 위해 입력된 값 보다 더 크게 배열크기를 선언
            int[,] MapSize = new int[arrX + 2, arrX + 2];

            //입력된 숫자만큼 랜덤한 지뢰를 배열에 넣음 
            //지뢰는 9로 정함
            for (int i = 0; i < N_bomb; i++)
            {
                MapSize[boomX[i], boomY[i]] = 9;
            }

            //주변 수 저장
            //주변에 지뢰가 있으면 카운트가 1씩 오름
            for (int i = 0; i < arrX + 1; i++)
            {
                for (int j = 0; j < arrX; j++)
                {
                    //지뢰 주변에 지뢰가 있으면 지뢰에도 카운트가 오르기 때문에 
                    //지뢰 카운트가 10이 될 경우엔 지뢰를 9로 초기화
                    if (MapSize[i, j] == 9)
                    {
                        #region
                        MapSize[i - 1, j - 1] += count;

                        MapSize[i - 1, j] += count;

                        MapSize[i - 1, j + 1] += count;

                        MapSize[i, j - 1] += count;

                        MapSize[i, j + 1] += count;

                        MapSize[i + 1, j - 1] += count;

                        MapSize[i + 1, j] += count;

                        MapSize[i + 1, j + 1] += count;

                        if (MapSize[i - 1, j - 1] == 10)
                            MapSize[i - 1, j - 1] -= count;

                        if (MapSize[i - 1, j] == 10)
                            MapSize[i - 1, j] -= count;

                        if (MapSize[i - 1, j + 1] == 10)
                            MapSize[i - 1, j + 1] -= count;

                        if (MapSize[i, j - 1] == 10)
                            MapSize[i, j - 1] -= count;

                        if (MapSize[i, j + 1] == 10)
                            MapSize[i, j + 1] -= count;

                        if (MapSize[i + 1, j - 1] == 10)
                            MapSize[i + 1, j - 1] -= count;

                        if (MapSize[i + 1, j] == 10)
                            MapSize[i + 1, j] -= count;

                        if (MapSize[i + 1, j + 1] == 10)
                            MapSize[i + 1, j + 1] -= count;
                        #endregion
                    }
                }
            }

            //Save 배열에 값을 저장 
            for (int i = 0; i < arrX + 1; i++)
            {
                for (int j = 0; j < arrX + 1; j++)
                {
                    save[i, j] = MapSize[i, j];
                }
            }
        }
           
        
        public void mapRender()
        {
            //0과9를 □ 로 출력
            for (int i = 0; i < arrX+2; i++)
            {
                for (int j = 0; j < arrX+2; j++)
                {
                    //맵 테두리의 값을 1로 초기 후 ■로 출력함
                    if (i == arrX + 1 || j == arrX + 1 || i == 0 || j == 0)
                    {
                        save[i, j] = 1;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("■");
                    }
                    //플레이어 위치일 때 ■ 출력
                    else if (i == pos_y && j == pos_x)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("■");
                    }
                    //처음 맵이 열리지 않았을 때 □ 출력
                    else if (100 > save[i, j])
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("□");
                    }
                    //스페이스바로 맵이 열릴 때 가지고 있는 숫자를 표시 
                    //맵이열리고, 깃발이 꽂히지 않았을때
                    else if (save[i, j] >= 100 && save[i,j]<10000)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        #region
                        if (save[i, j]%100==0)
                        {
                            Console.Write("  ");
                        }
                        if(save[i, j]%100 == 1)
                        {
                            Console.Write("①");
                        }
                        if (save[i, j]%100 == 2)
                        {
                            Console.Write("②");
                        }
                        if (save[i, j]%100 == 3)
                        {
                            Console.Write("③");
                        }
                        if (save[i, j]%100 == 4)
                        {
                            Console.Write("④");
                        }
                        if (save[i, j] % 100 == 5)
                        {
                            Console.Write("⑤");
                        }
                        if (save[i, j] % 100 == 6)
                        {
                            Console.Write("⑥");
                        }
                        if (save[i, j] % 100 == 7)
                        {
                            Console.Write("⑦");
                        }
                        if (save[i, j] % 100 == 8)
                        {
                            Console.Write("⑧");
                        }
                        if (save[i, j] % 100 == 9)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("□");
                        }
                        #endregion
                    }
                    //깃 발이 꽂힐 때 ★을 출력 
                    else if (save[i, j] >= 10000)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("★");
                    }
                }
                Console.WriteLine();
            }
        }
        public void PlayerMove()
        {
            //플레이어 위치 이동 
            ConsoleKeyInfo K = Console.ReadKey();
            switch (K.Key)
            {
                case ConsoleKey.RightArrow:
                    Right();
                    break;
                case ConsoleKey.LeftArrow:
                    Left();
                    break;
                case ConsoleKey.UpArrow:
                    Up();
                    break;
                case ConsoleKey.DownArrow:
                    Down();
                    break;
                case ConsoleKey.Spacebar:
                    Spacebar();
                    break;
                case ConsoleKey.A:
                    flag();
                    break;
                case ConsoleKey.S:
                    flagdelet();
                    break;
            }
        }

        //플레이어 이동 및 스페이스바, 깃발 꽂기 
        public void Right()
        {
            pos_x ++;
            if (pos_x == arrX+1)
            {
                pos_x = arrX;
            }
        }
        public void Left()
        {
            pos_x --;
            if (pos_x <= 1)
            {
                pos_x = 1;
            }
        }
        public void Up()
        {
            pos_y--;
            if (pos_y <= 0)
            {
                pos_y = 1;
            }
        }
        public void Down()
        {
            pos_y++;
            if (pos_y >= arrX+1)
            {
                pos_y = arrX;
            }
        }
        public void flag()
        {
            if (Limit>=0)
            {
                //깃발이 꽂히면 자리값에 10000을 더해줌 
                save[pos_y, pos_x] += 10000;
                //두 번 누를 경우 10000으로 초기화
                if(save[pos_y, pos_x]>20000)
                {
                    save[pos_y, pos_x] -= 10000;
                }
                //깃발의 개수가 차감됨 
                Limit--;
            }
        }//깃발 생성
        public void flagdelet()
        {
            //깃발이 꽂혔을 때 
            if (save[pos_y, pos_x]>=10000)
            {
                //그 자리에 10000을 빼주고
                save[pos_y, pos_x] -= 10000;
                //깃 발 개수를 복구
                Limit++;
            }
           
        }//깃발 삭제
        public void Spacebar()
        {
            //누른 자리에 100을 더해줌
            save[pos_y, pos_x] += 100;
            //두 번 누를경우 100을 빼줌 
            if (save[pos_y, pos_x] >= 200)
            {
                save[pos_y, pos_x] -= 100;
            }
            //누른 곳이 0일 경우 함수 실행 
            if (save[pos_y, pos_x] == 100)
                Spread(pos_y, pos_x);


        }//칸 없애기 

        //퍼지는 함수
        public void Spread(int player_x, int player_y)
        {
            //스페이스바를 누른 위치에서 주위 칸들을 검사
            for (int x = -1; x <=1 ; x++)
            {
                for (int y = -1; y <=1 ; y++)
                {
                    //스페이스바를 누른 위치라면 컨티뉴 
                    if (player_x == player_x - x && player_y == player_y - y)
                        continue;
                    //주변 값에 100을 더해준 후
                    save[player_x - x, player_y - y] += 100;
                    //주변 값이 100일 경우 (0일 경우입니다)
                    if (save[player_x - x, player_y - y] == 100)
                    {
                        //재귀함수 호출 
                        Spread(player_x - x, player_y - y);
                    }
                    //100을 더한 값이 109(지뢰일 경우) 100을 빼준다 
                    if (save[player_x - x, player_y - y] == 109)
                    {
                        save[player_x - x, player_y - y] -= 100;
                    }

                }
            }
            
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (player_x == player_x - x && player_y == player_y - y)
                        continue;
                   //숫자를 만나면 리턴 
                    else if (save[player_x - x, player_y - y] > 100) return;
                }
            }
            


        }

    }
}
