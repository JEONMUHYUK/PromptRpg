using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptRpg
{
    public class Devil : BaseMonster
    {
        
        GameOver _gameOver;                                             // _gameOver.RunGameOver 함수를 실행해야 하기 때문에 인자로 받아온다.
        Player _player;                                                 // 플레이어의 hp와 골드, 포션값을 가져오기 떄문에 인자로 받아온다.

        Random random = new Random();
        public int DevilPosY { get; private set; }                      // 데빌 위치 값 읽기전용
        public int DevilPosX { get; private set; }

        private int MonsterHP;                                          // 몬스터 hp값
        private int _size;

        public void Initialize(int _size, Player _player, GameOver _gameOver)
        {
            this._size = _size;
            this._player = _player;                                     //객체가 넘어오면 같은 주소값을 공유한다.
            this._gameOver = _gameOver;

            DevilPosY = _size - 1;
            DevilPosX = _size - 1;

            MonsterHP = 100;

        }
        public override void Monster()
        {
            string prompt = $@"
                                                
                                                   -=[ Devil ]=-
                                                   ( {MonsterHP}/100 )
                                           , ,, ,                              
                                           | || |    ,/  _____  \.             
                                           \_||_/    ||_/     \_||             
                                             ||       \_| . . |_/              
                                             ||         |  L  |                
                                            ,||         |`==='|                
                                            |>|      ___`>  -<'___             
                                            |>|\    /             \            
                                            \>| \  /  ,    .    .  |           
                                             ||  \/  /| .  |  . |  |           
                                             ||\  ` / | ___|___ |  |     (     
                                          (( || `--'  | _______ |  |     ))  ( 
                                        (  )\|| (  )\ | - --- - | -| (  ( \  ))
                                        (\/  || ))/ ( | -- - -- |  | )) )  \(( 
                                         ( ()||((( ())|         |  |( (( () )
 
                                            A wild Cyclops has appeared! 
                                            Player HP >> {_player.HP}/100 <<
";            // 프롬프트 값
            string[] options = { "Odd Number", "Even Number", "Escape" };                       // options 배열 값
            Menu mainMenu = new Menu(prompt, options);                                          // mainMenu 파라미터에 전달
            int selectedIndex = mainMenu.Run();                                                 // 메인메뉴 Run함수가  인덱스를 return해준다.

            switch (selectedIndex)                                                              // 인덱스 값에 맞는 함수 실행 
            {
                case 0:
                    OddNumber();
                    break;
                case 1:
                    EvenNumber();
                    break;
                case 2:
                    Escape();
                    break;
            }
        }

        public override void OddNumber()                    // 홀 함수
        {
            if (random.Next(0, 100) % 2 != 0)               // 랜덤값이 짝이 아니면 몬스터HP는 감소한다.
            {
                MonsterHP -= 50;
            }
            else
            {
                if (_player.HP > 20)                        //홀이 아니고 플레이어 Hp가 20이상이면 hp 20감소한다.
                {
                    Console.Beep();
                    _player.HP -= 20;
                }
                else _gameOver.RunGameOver();               // 아니라면 gameover 함수 실행
            }

            if (MonsterHP > 0)                              // 몬스터 HP가 0 이상이라면 
            {

                Monster();                                  // 몬스터 함수 실행
            }
            else                                           
            {
                _player.Gold += 60;                         // 몬스터 HP가 0이하 라면 플레이어 골드 증가, 몬스터 Hp도 100으로 다시 초기화.
                MonsterHP = 100;
            }
        }

        public override void EvenNumber()                   // 짝 함수
        {
            if (random.Next(0, 100) % 2 == 0)               // 랜덤값이 짝이면 몬스터HP는 감소한다.
            {
                MonsterHP -= 50;
            }
            else
            {
                if (_player.HP > 20)                        // 플레이어 HP가 20보다 크다면
                {
                    Console.Beep();
                    _player.HP -= 20;                       // 플레이어 HP를 20으로 감소한다.
                }
                else _gameOver.RunGameOver();               //아니라면 gameover 함수 실행
            }

            if (MonsterHP > 0)                              // 몬스터 HP가 0 이상이라면 
            {

                Monster();                                  // 몬스터 함수 실행
            }
            else
            {
                _player.Gold += 40;                         // 몬스터 HP가 0이하 라면 플레이어 골드 증가, 몬스터 Hp도 100으로 다시 초기화.
                MonsterHP = 100;
            }
        }

        public override void Escape()
        {
            if (random.Next(0, 100) < 20)                   // 20% 확률로 Monster에게서 도망
            {
                MonsterHP = 100;                            // 몬스터 체력 초기화
            }
            else
            {
                Console.Beep();
                _player.HP -= 10;                           // 도망 실패시 체력 -10
                Monster();                                  // 몬스터 함수 실행
            }
        }
    }
}
