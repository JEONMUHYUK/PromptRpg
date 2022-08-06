using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptRpg
{
    internal class Store
    {
        Player _player;

        Random rand = new Random();

        #region Variable
        // 변수 선언
        private int _size;
        public int Store0PosY { get; private set; }                       
        public int Store0PosX { get; private set; }                       
        public int Store1PosY { get; private set; }                      
        public int Store1PosX { get; private set; }                       
        public int Store2PosY { get; private set; }                       
        public int Store2PosX { get; private set; }                      
        public int Store3PosY { get; private set; }                       
        public int Store3PosX { get; private set; }
        #endregion

        #region Initialize
        public void Initialize(int _size, Player player)
        {
            this._size = _size;
            _player = player;

            // 스토어 위치값
            Store0PosY = rand.Next(1, (_size / 2) - 1);
            Store0PosX = rand.Next(1, (_size / 2) - 1);
            Store1PosY = rand.Next(0, (_size / 2) - 1);
            Store1PosX = rand.Next(_size / 2, _size - 1);
            Store2PosY = rand.Next(_size / 2, _size - 1);
            Store2PosX = rand.Next(0, (_size / 2) - 1);
            Store3PosY = rand.Next(_size / 2, _size - 1);
            Store3PosX = rand.Next(_size / 2, _size - 1);
        }
        #endregion

        public void StoreInfo()
        {
            Console.Clear();

            RunStore();
            
        
        }

        private void RunStore()
        {

            string prompt = $@"


                               ▄████████     ███      ▄██████▄     ▄████████    ▄████████ 
                              ███    ███ ▀█████████▄ ███    ███   ███    ███   ███    ███ 
                              ███    █▀     ▀███▀▀██ ███    ███   ███    ███   ███    █▀  
                              ███            ███   ▀ ███    ███  ▄███▄▄▄▄██▀  ▄███▄▄▄     
                            ▀███████████     ███     ███    ███ ▀▀███▀▀▀▀▀   ▀▀███▀▀▀     
                                     ███     ███     ███    ███ ▀███████████   ███    █▄  
                               ▄█    ███     ███     ███    ███   ███    ███   ███    ███ 
                             ▄████████▀     ▄████▀    ▀██████▀    ███    ███   ██████████ 
                                                                  ███    ███              

                                                                                                                          
                     Use the W,S keys to cycle through options and pressed enter to select an option.

                                Player Gold >> {_player.Gold} <<     Player Potion >> {_player.Potion} <<

";            // 프롬프트 값
            string[] options = { "Buy Potion", "About", "Exit" };                     // options 배열 값
            Menu mainMenu = new Menu(prompt, options);                          // mainMenu 파라미터에 전달
            int selectedIndex = mainMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    BuyPotion();
                    break;
                case 1:
                    DisplayAboutInfo();
                    break;
                case 2:
                    ExitGame();
                    break;
            }
        }

        private void ExitGame()
        {

        }

        private void DisplayAboutInfo()
        {
            Console.WriteLine("Welcome To the Store!! Please Enjoy");
            Console.ReadKey(true);              //키를 입력받으면
            RunStore();
        }

        private void BuyPotion()
        {
            if (_player.Gold > 9)               // 플레이어 골드가 9 이상이면 플레이어 골드를 10감소시키고
            {
                _player.Gold -= 10;             // 포션을 1 증가한다.
                _player.Potion += 1;
                RunStore();
            }
            else RunStore();

        }
    }






    
}
