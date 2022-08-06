using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptRpg
{
    public class Player
    {

        public int              _posY { get; private set; }         // 플레이어 위치 값을 읽기전용으로 설정한다.                 
        public int              _posX { get; private set; }      
        
        public int              HP;                                 // Player Health Point (몬스터 클래스에서 접근할 수 있게 접근제한자는 Public)
        public int              Gold;                               // Player Gold
        public int              Potion;                             // Player Potion

        ConsoleKeyInfo          keys;                               // 키 값을 받는 변수

        private string          _playerName;                        // player의 이름을 startScene클래스에서 가져온다.
        private int             _mapSize;                           // mapSize를 StartScene 클래스에서 가져온다.

        // Initialize(플레이어 초기값, 플레이어 이름, 맵크기) = 클래스 내부 변수들 초기화
        public void Initialize(int _posY, int _posX, string _playerName, int _mapSize)
        {
            
            this._posX =            _posX;                          // 플레이어 위치값을 초기화 한다. 0,0
            this._posY =            _posY;                          

            this._playerName = _playerName;                         // player의 이름을 startScene클래스에서 가져온다.
            this._mapSize = _mapSize;                               // mapSize를 StartScene 클래스에서 가져온다.

            Gold = 100;                                             // Player Gold 초기값은 100
            HP = 100;                                               // Player Health Point 초기값은 100
            Potion = 0;                                             // Player Potion초기값은 0
        }



        #region Player_Pos_Set_And_Player_Tick
        private int MOVE_TICK = 100;                                // 0.1초로 제한하는 값 즉, 0.1 초 마다 움직이게 한다.
        private int _sumTick = 0;                                   // deltaTick을 받아오는 변수.
        public void Update(int deltaTick)                           // deltaTick은 메인 클래스에서 1프레임이 지날때마다 업데이트 되는 값을 받아온다
        {

            // 게임보드랑 유저랑 랜더링 되는 속도가 달라진다.(double buffer)
            _sumTick += deltaTick;                                  // sumTick에 deltaTick을 더해준다.
            if (_sumTick >= MOVE_TICK)                              //만약 sumTIck이 MOVE_TICK보다 커지거나 같아지면
            {
                _sumTick = 0;                                       //_sumTick을 초기화 시켜준다.


                // 여기에다가 0.1초마다 실행될 로직을 넣어 준다. 
                keys = Console.ReadKey();

                switch (keys.Key)
                {
                    case ConsoleKey.W:                              // 상
                        if (_posY - 1 >= 0)
                            _posY = _posY - 1;
                        break;
                    case ConsoleKey.S:                              // 하
                        if (_posY + 1 < _mapSize)
                            _posY = _posY + 1;
                        break;
                    case ConsoleKey.A:                              // 좌
                        if (_posX - 1 >= 0)
                            _posX = _posX - 1;
                        break;
                    case ConsoleKey.D:                              // 우
                        if (_posX + 1 < _mapSize)
                            _posX = _posX + 1;
                        break;
                    case ConsoleKey.Spacebar:                       // 스페이스바(포션사용)
                        if (Potion > 0 && HP < 100)
                        {
                            Potion -= 1;
                            HP += 10;
                        }
                        break;
                }

            }

        }
        #endregion

        #region DrawPlayerInformation
        public void PlayerInfo()
        {

            Console.WriteLine("########################################################################################################################");
            #region Tile_Inforemation
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" >> '■' player   ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" >> '■' Store    ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" >> '■' FlatLand ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" >> '■' Forest   ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" >> '■' Swamp    ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" >> '■' EscapeZone ");
            Console.ResetColor();
            #endregion
            #region Player_Information
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"                                    Player  >> {_playerName} <<");
            Console.WriteLine();
            Console.Write($"                                    PlayerHP >> {HP} <<");
            Console.WriteLine($"           PlayerX,Y >> X : {_posX} Y : {_posY} <<");
            Console.WriteLine();
            Console.Write($"                                    Gold >> {Gold}G <<              ");
            Console.WriteLine($"Potion >> {Potion} <<");
            Console.WriteLine();
            #endregion
            Console.WriteLine("########################################################################################################################");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            

        }
        #endregion
    }
}
