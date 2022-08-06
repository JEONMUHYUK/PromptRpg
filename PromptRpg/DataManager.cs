using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptRpg
{
    internal class DataManager
    {

        public void RunRpg()
        {
            StartScene startScene = new StartScene();

            startScene.Start();

            #region Class 객체 생성
            Player player = new Player();
            Board board = new Board();                                      //Board Class정의

            Random random = new Random();

            Goblin goblin = new Goblin();
            Orc orc = new Orc();
            Devil devil = new Devil();

            EscapeZone escapeZone = new EscapeZone();
            Store store = new Store();

            GameOver gameOver = new GameOver();
            #endregion

            #region Initialize
            // Store 초기화
            store.Initialize(startScene.MapSize, player);
            // escapeZone 초기화
            escapeZone.Initialize(startScene.MapSize);
            // player 초기화
            player.Initialize(0, 0, startScene.PlayerName, startScene.MapSize);

            // monster 값 초기화
            goblin.Initialize(startScene.MapSize, player, gameOver);
            orc.Initialize(startScene.MapSize, player, gameOver);
            devil.Initialize(startScene.MapSize, player, gameOver);

            // board값 초기화
            board.Initialize(startScene.MapSize, player._posY, player._posX, escapeZone.EscapeZonePosY, escapeZone.EscapeZonePosX
                , goblin.GoblinPosY, goblin.GoblinPosX, store.Store0PosY, store.Store0PosX,
                store.Store1PosY, store.Store1PosX, store.Store2PosY, store.Store2PosX, store.Store3PosY, store.Store3PosX
                , orc.OrcPosY, orc.OrcPosX, devil.DevilPosY, devil.DevilPosX);
            #endregion
            Console.CursorVisible = false;

            Console.CursorVisible = false;                                  // 커서를 끈다.

            const int WAIT_TICK = 1000 / 30;                                // const : 값을 변경할 수 없게 한다.

            int lastTick = 0;
            while (true)
            {
                
                #region 프레임 관리
                // 밀리 세컨즈로 나타낸 현재시간.  1초 = 1000 밀리세컨즈
                int currentTick = System.Environment.TickCount;

                // 만약 경과한 시간이 1/30초보다 작다면 아래 모든 부분을 실행하지 않는다.
                // 너무 빠르게 움직이는 반복문을 잠시 넘겨서 그리는 시간을 늦춰준다.
                if (currentTick - lastTick < WAIT_TICK) 
                    continue;

                // 현재시간과 가장 최근에 실행된 currentTick을 빼준 값을 담는다. 
                // 뺀 값이 60fps 기준이면 0.016의 값이 deltaTick에 저장된다.
                int deltaTick = currentTick - lastTick;
                
                // 가장 최근에 실행된 시간을 lastTick에 업데이트 해준다.
                lastTick = currentTick;  
                #endregion
              

                // deltaTick값을 player 클래스의 Update함수에 보내 랜더링 시간을 다르게 한다.
                player.Update(deltaTick);
                // 콘솔창에서 커서 위치를 맨 왼쪽 상단에 세팅한다.
                Console.SetCursorPosition(0, 0);
                
                #region Tile_Event
                //--------------------------------Store--------------------------------------------
                //Store 위치값이 Player 위치값과 동일하다면 store클래스의 StoreInfo()함수를 실행시켜 준다
                if ((store.Store0PosX == player._posX && store.Store0PosY == player._posY) ||
                    (store.Store1PosX == player._posX && store.Store1PosY == player._posY) ||
                    (store.Store2PosX == player._posX && store.Store2PosY == player._posY) ||
                    (store.Store3PosX == player._posX && store.Store3PosY == player._posY))
                {
                    Console.Clear();
                    store.StoreInfo();
                    Console.Clear();
                }
                //-----------------------------------------------------------------------------------

                //---------------------------------Monster-------------------------------------------
                // 각 지형 Tile의 위치값이 Player 위치값과 동일하다면 각 지형을 대표하는 몬스터 클래스의 몬스터 함수를 실행시켜 준다
                // FlatLand Tile
                else if (board.Tile[player._posY, player._posX] == Board.TileType.FlatLand && random.Next(0, 10) <= 5)
                {
                    Console.Clear();
                    goblin.Monster();
                    Console.Clear();
                }
                // Forest Tile
                else if (board.Tile[player._posY, player._posX] == Board.TileType.Forest && random.Next(0, 10) <= 5)
                {
                    Console.Clear();
                    orc.Monster();
                    Console.Clear();
                }
                // Swamp Tile
                else if (board.Tile[player._posY, player._posX] == Board.TileType.Swamp && random.Next(0, 10) <= 5)
                {
                    Console.Clear();
                    devil.Monster();
                    Console.Clear();
                }
                //-----------------------------------------------------------------------------------
                #endregion

                // 플레이어 상태창 출력
                player.PlayerInfo();

                // 플레이어 위치값 업데이트
                board.PlayerPosUpdate(player._posY, player._posX);

                // 보드 랜더링
                board.Render();                                                                         // 게임보드 렌더링


                #region Clear 조건
                //------------------------------Escpae--------------------------------------
                if (escapeZone.EscapeZonePosX == player._posX && escapeZone.EscapeZonePosY == player._posY)
                {
                    Console.Clear();
                    escapeZone.EscapeZoneText();
                    break;
                }
                #endregion
            }



        }
    }
}
