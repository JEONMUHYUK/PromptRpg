using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptRpg
{
    public class Orc : BaseMonster
    {
        // _gameOver.RunGameOver 함수를 실행해야 하기 때문에 객체생성.

        GameOver _gameOver;
        Player _player;
        Random random = new Random();
        public int OrcPosY { get; private set; }
        public int OrcPosX { get; private set; }

        private int MonsterHP;
        private int _size;

        public void Initialize(int _size, Player _player, GameOver _gameOver)
        {
            this._size = _size;
            this._player = _player;
            this._gameOver = _gameOver;

            OrcPosY = _size - 1;
            OrcPosX = _size - 1;

            MonsterHP = 100;

        }
        public override void Monster()
        {
            string prompt = $@"

                                                     -=[ Cyclops ]=-
                                                       ( {MonsterHP}/100 )
                                                       _......._
                                                   .-'.'.'.'.'.'.`-.
                                                 .'.'.'.'.'.'.'.'.'.`.
                                                /.'.'               '.\
                                                |.'    _.--...--._     |
                                                \    `._.-.....-._.'   /
                                                |     _..- .-. -.._   |
                                             .-.'    `.   ((@))  .'   '.-.
                                            ( ^ \      `--.   .-'     / ^ )
                                             \  /         .   .       \  /
                                             /          .'     '.  .-    \
                                            ( _.\    \ (_`-._.-'_)    /._\)
                                             `-' \   ' .--.          / `-'
                                                 |  / /|_| `-._.'\   |
                                                 |   |       |_| |   /-.._
                                             _..-\   `.--.______.'  |
                                                  \       .....     |
                                                   `.  .'      `.  /
                                                     \           .'
                                                      `-..___..-`
 
                                              A wild Cyclops has appeared! 
                                              Player HP >> {_player.HP}/100 <<
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
                MonsterHP -= 25;
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
                _player.Gold += 40;
                MonsterHP = 100;
            }
        }

        public override void EvenNumber()
        {
            if (random.Next(0, 100) % 2 == 0)
            {
                MonsterHP -= 25;
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
                _player.Gold += 40;
                MonsterHP = 100;
            }
        }

        public override void Escape()
        {
            if (random.Next(0, 100) < 20)
            {
                MonsterHP = 100;
            }
            else
            {
                Console.Beep();
                _player.HP -= 10;
                Monster();
            }
        }
    }
}
