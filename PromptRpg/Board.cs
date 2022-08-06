using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptRpg
{
    class Board
    {

        public TileType[,] Tile { get; private set; }                                                                   
                                                                   
        Random _random = new Random();
 
        char BLOCK = '■';                                                                 

        #region paramVariable
        private int _size;

        private int _playerPosY;
        private int _playerPosX;

        private int _escapeZonePosY;
        private int _escapeZonePosX;

        private int _goblinPosY;
        private int _goblinPosX;

        private int _orcPosY;
        private int _orcPosX;

        private int _devilPosY;
        private int _devilPosX;

        private int _storePos0Y;
        private int _storePos1Y;
        private int _storePos2Y;
        private int _storePos3Y;

        private int _storePos0X;
        private int _storePos1X;
        private int _storePos2X;
        private int _storePos3X;
        #endregion

        public enum TileType // 타일 타입을 정의 
        {
            Empty,   // 갈 수 있는 타일
            //----------------------------
            FlatLand,   // 평지
            Forest,     // 숲
            Swamp,      // 늪
            Store,      // 상점
            EscapeZone, // 탈출

        }

 
        public void Initialize(int _size, int _playerPosY, int _playerPosX, int _escapeZonePosY, int _escapeZonePosX
            , int _goblinPosY, int _goblinPosX, int _storePos0Y, int _storePos0X, int _storePos1Y, int _storePos1X, int _storePos2Y, int _storePos2X,
            int _storePos3Y, int _storePos3X, int _orcPosY, int _orcPosX, int _devilPosY, int _devilPosX)                                 
        {
            #region Initialize
            // 맵 사이즈
            this._size = _size;      
            
            //타일 위치값 
            Tile = new TileType[this._size, this._size];                                                   

            // 플레이어 위치 초기값
            this._playerPosY = _playerPosY;
            this._playerPosX = _playerPosX;

            // 탈출장소 위치 초기값
            this._escapeZonePosY = _escapeZonePosY;
            this._escapeZonePosX = _escapeZonePosX;

            // 고블린 출현 위치 초기값
            this._goblinPosY = _goblinPosY;
            this._goblinPosX = _goblinPosX;

            // 오크 출현 위치 초기값
            this._orcPosY = _orcPosY;
            this._orcPosX = _orcPosX;
            
            // 데빌 출현 위치 초기값
            this._devilPosY = _devilPosY;
            this._devilPosX = _devilPosX;

            // 스토어 위치 초기값 Y
            this._storePos0Y = _storePos0Y;
            this._storePos1Y = _storePos1Y;
            this._storePos2Y = _storePos2Y;
            this._storePos3Y = _storePos3Y;

            // 스토어 위치 초기값 X
            this._storePos0X = _storePos0X;
            this._storePos1X = _storePos1X;
            this._storePos2X = _storePos2X;
            this._storePos3X = _storePos3X;

            #endregion

            #region Board_Tile 초기값
            // 배열에 타일 위치를 미리 넣어서 지정
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    // 스토어 타일위치에 색지정
                    if ((x == _storePos0X && y == _storePos0Y) ||
                        (x == _storePos1X && y == _storePos1Y) ||
                        (x == _storePos2X && y == _storePos2Y) ||
                        (x == _storePos3X && y == _storePos3Y))
                        Tile[y, x] = TileType.Store;

                    // 평지 타일위치에 색지정 (고블린 출현 장소)
                    else if (x == _random.Next(2, _goblinPosX) || y == _random.Next(2, _goblinPosY))
                        Tile[y, x] = TileType.FlatLand;

                    // 숲 타일위치에 색지정 (오크 출현 장소)
                    else if (x == _random.Next(2, _orcPosX) || y == _random.Next(2, _orcPosY))
                        Tile[y, x] = TileType.Forest;

                    // 늪 타일위치에 색지정 (데빌 출현 장소)
                    else if (x == _random.Next(2, _devilPosX) || y == _random.Next(2, _devilPosY))
                        Tile[y, x] = TileType.Swamp;

                    // 탈출 타일위치에 색 지정
                    else if (x == _escapeZonePosX && y == _escapeZonePosY)
                        Tile[y, x] = TileType.EscapeZone;

                    // 나머지 타일의 색 지정
                    else Tile[y, x] = TileType.Empty; 
                }
            }
            #endregion
        }

        // 플레이어의 위치값을 업데이트 한다.
        public void PlayerPosUpdate(int _playerPosY, int _playerPosX)
        {
            this._playerPosY = _playerPosY;
            this._playerPosX = _playerPosX;
        }

        // 게임판, 타일, 플레이어를 그리는 곳
        public void Render()
        {
            ConsoleColor prevColor = Console.ForegroundColor;                                       // color값을 정의하는 함수를 변수로 선언

            for (int y = 0; y < _size; y++)
            {
                Console.Write("                                                 ");
                for (int x = 0; x < _size; x++)
                {

                    // 플레이어 좌표 갖고 와서, 그 좌표랑 현재 y, x 가 일치하면 플레이어 전용 색상인 빨간색으로 표시
                    if (y == _playerPosY && x == _playerPosX)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;     
                    }
                    else
                        Console.ForegroundColor = GetTileColor(Tile[y, x]);
                    Console.Write(BLOCK);  // 블럭 1개 그림
                }
                Console.WriteLine();  // 개행
            }

            Console.ForegroundColor = prevColor;
        }





        ConsoleColor GetTileColor(TileType type)
        {
            // 타일의 색을 지정하는 곳.
            switch (type)
            {
                case TileType.Empty:  // 갈 수 있는 곳이면 초록색 리턴
                    return ConsoleColor.White;
                case TileType.FlatLand:
                    return ConsoleColor.Cyan;
                case TileType.Forest:
                    return ConsoleColor.Green;
                case TileType.Swamp:
                    return ConsoleColor.Blue;
                case TileType.EscapeZone:
                    return ConsoleColor.Yellow;
                case TileType.Store:
                    return ConsoleColor.Magenta;
                default:  // 디폴트는 초록색 리턴
                    return ConsoleColor.White;
            }
        }
    }
}
