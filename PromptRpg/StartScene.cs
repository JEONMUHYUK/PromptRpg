using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptRpg
{
    internal class StartScene
    {

        public string PlayerName { get; private set; }                       // 플레이어 이름을 전달하기 위해 Public
        public int MapSize { get; private set; }                             // 맵 사이즈를 전달하기 위해 Public


        public void Start()
        {
            MapSize = 10;
            Console.Title = "Prompt RPG";
            RunMainMenu();


        }

        private void RunMainMenu()                                              // 호출로 쓰는 함수는 private
        {
            string prompt = @"


                      ____                                       _     ____    ____     ____ 
                     |  _ \   _ __    ___    _ __ ___    _ __   | |_  |  _ \  |  _ \   / ___|
                     | |_) | | '__|  / _ \  | '_ ` _ \  | '_ \  | __| | |_) | | |_) | | |  _ 
                     |  __/  | |    | (_) | | | | | | | | |_) | | |_  |  _ <  |  __/  | |_| |
                     |_|     |_|     \___/  |_| |_| |_| | .__/   \__| |_| \_\ |_|      \____|
                                                        |_|                                  
                                 
                    Use the W,S keys to cycle through options and pressed enter to select an option.



";            // 프롬프트 값
            string[] options = { "Play", "About", "Exit" };                     // options 배열 값
            Menu mainMenu = new Menu(prompt, options);                          // mainMenu 파라미터에 전달
            int selectedIndex = mainMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    RunFirstChoice();
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
            Console.WriteLine("\nPressed any Key to exit....");
            Console.ReadKey(true);
            Environment.Exit(0);                                // 환경 종료 메서드
        }

        private void DisplayAboutInfo()
        {
            Console.WriteLine("Hello");
            Console.ReadKey(true);              //키를 입력받으면
            RunMainMenu();
        }

        private void RunFirstChoice()
        {
            TypingMapSizeAndName();
        }

        private void TypingMapSizeAndName()
        {
            Console.Clear();
            Console.WriteLine(@"

 __    __   _               _                                                                             ___ 
/ / /\ \ \ | |__     __ _  | |_      _   _    ___    _   _   _ __      _ __     __ _   _ __ ___     ___  / _ \
\ \/  \/ / | '_ \   / _` | | __|    | | | |  / _ \  | | | | | '__|    | '_ \   / _` | | '_ ` _ \   / _ \ \// /
 \  /\  /  | | | | | (_| | | |_     | |_| | | (_) | | |_| | | |       | | | | | (_| | | | | | | | |  __/   \/ 
  \/  \/   |_| |_|  \__,_|  \__|     \__, |  \___/   \__,_| |_|       |_| |_|  \__,_| |_| |_| |_|  \___|   () 
                                     |___/                                                                    
");
            Console.Write(">> ");
            PlayerName = Console.ReadLine();                        // 플레이어 이름을 전달 받는다.
            Console.Clear();
        }
    }
}
