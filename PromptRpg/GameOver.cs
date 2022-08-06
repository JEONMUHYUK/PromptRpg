﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptRpg
{
    public class GameOver
    {

        public void Initialize()
        {

        }

        // 함수가 실행되면 게임오버
        public void RunGameOver()
        {
            string prompt = @"


    :'######:::::::::'###:::::::'##::::'##::::'########::::::::'#######:::::'##::::'##::::'########::::'########::
    '##... ##:::::::'## ##:::::: ###::'###:::: ##.....::::::::'##.... ##:::: ##:::: ##:::: ##.....::::: ##.... ##:
     ##:::..:::::::'##:. ##::::: ####'####:::: ##::::::::::::: ##:::: ##:::: ##:::: ##:::: ##:::::::::: ##:::: ##:
     ##::'####::::'##:::. ##:::: ## ### ##:::: ######::::::::: ##:::: ##:::: ##:::: ##:::: ######:::::: ########::
     ##::: ##::::: #########:::: ##. #: ##:::: ##...:::::::::: ##:::: ##::::. ##:: ##::::: ##...::::::: ##.. ##:::
     ##::: ##::::: ##.... ##:::: ##:.:: ##:::: ##::::::::::::: ##:::: ##:::::. ## ##:::::: ##:::::::::: ##::. ##::
    . ######:::::: ##:::: ##:::: ##:::: ##:::: ########:::::::. #######:::::::. ###::::::: ########:::: ##:::. ##:
    :......:::::::..:::::..:::::..:::::..:::::........:::::::::.......:::::::::...::::::::........:::::..:::::..::
                                                                                                              


";            // 프롬프트 값
            string[] options = {  "Exit" };                                     // options 배열 값
            Menu mainMenu = new Menu(prompt, options);                          // mainMenu 파라미터에 전달
            int selectedIndex = mainMenu.Run();
            switch (selectedIndex)                                              // 메뉴클래스에서 받아온 selectIndex값 전달
            {
                case 0:
                    ExitGame();
                    break;
            }
        }

        // 접근제한자가 Public인 RunGameOver에서 함수를 호출하기 때문에 private가 가능하다.
        private void ExitGame()
        {
            Environment.Exit(0);                                                // 환경 종료 메서드
        }




    }
    
}
