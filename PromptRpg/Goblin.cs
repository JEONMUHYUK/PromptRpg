using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptRpg
{
    public class Goblin : BaseMonster
    {
        // _gameOver.RunGameOver 함수를 실행해야 하기 때문에 객체생성.

        GameOver _gameOver;
        Player _player;
        Random random = new Random();
        public int GoblinPosY { get; private set; }
        public int GoblinPosX { get; private set; }

        private int MonsterHP;
        private int _size;


        public void Initialize(int _size, Player _player, GameOver _gameOver)
        {

            this._size = _size;
            this._player = _player;
            this._gameOver = _gameOver;

            GoblinPosY = _size - 1;
            GoblinPosX = _size - 1;

            MonsterHP = 100;

        }
        public override void Monster()
        {
            string prompt = $@"

                                                  -=[ goblins ]=-
                                                    ( {MonsterHP}/100 )
                                                     ,      ,
                                                    /(.-""-.)\
                                                |\  \/      \/  /|
                                                | \ / =.  .= \ / |
                                                \( \   o\/o   / )/
                                                 \_, '-/  \-' ,_/
                                                   /   \__/   \
                                                   \ \__/\__/ /
                                                 ___\ \|--|/ /___
                                               /`    \      /    `\
                                              /       '----'       \

                                            A wild goblin has appeared!                                                                                                                           
                                              Player HP >> {this._player.HP}/100 <<
";            // 프롬프트 값
            string[] options = { "Odd Number", "Even Number", "Escape" };                     // options 배열 값
            Menu mainMenu = new Menu(prompt, options);                          // mainMenu 파라미터에 전달
            int selectedIndex = mainMenu.Run();
            switch (selectedIndex)
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

        public override void OddNumber()
        {
            if (random.Next(0, 100) % 2 != 0)
            {
                MonsterHP -= 50;
            }
            else
            {
                if (_player.HP > 10)
                {
                    Console.Beep();
                    _player.HP -= 10;
                }
                else _gameOver.RunGameOver();
            }

            if (MonsterHP > 0)
            {

                Monster();
            }
            else
            {
                _player.Gold += 20;
                MonsterHP = 100;
            }
        }

        public override void EvenNumber()
        {
            if (random.Next(0, 100) % 2 == 0)
            {
                MonsterHP -= 50;
            }
            else
            {
                if (_player.HP > 10)
                {
                    Console.Beep();
                    _player.HP -= 10;
                }
                else _gameOver.RunGameOver();
            }

            if (MonsterHP > 0)
            {

                Monster();
            }
            else
            {
                _player.Gold += 20;
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
