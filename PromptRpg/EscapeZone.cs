using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptRpg
{
    internal class EscapeZone
    {
        public int Size { get; private set; }

        public int EscapeZonePosY { get; private set; }                       //외부에서 위치값을 get으로 읽게만 하고 set을 private함으로 set을 방지한다.
        public int EscapeZonePosX { get; private set; }                       // 즉, 단순 읽기 속성  


        public void Initialize(int size)
        {
            // 위치값 초기화
            EscapeZonePosY = size - 1;
            EscapeZonePosX = 0;
            Size = size;
        }

        // 함수가 실행되면 게임종료
        public void EscapeZoneText()
        {
            Console.WriteLine(@"


                       ____                            _         _       _   _                   _   _ 
                      / ___|___  _ __   __ _ _ __ __ _| |_ _   _| | __ _| |_(_) ___  _ __  ___  | | | |
                     | |   / _ \| '_ \ / _` | '__/ _` | __| | | | |/ _` | __| |/ _ \| '_ \/ __| | | | |
                     | |__| (_) | | | | (_| | | | (_| | |_| |_| | | (_| | |_| | (_) | | | \__ \ |_| |_|
                      \____\___/|_| |_|\__, |_|  \__,_|\__|\__,_|_|\__,_|\__|_|\___/|_| |_|___/ (_) (_)
                                       |___/                                                           


                             _____                        _____ _                   _   _ 
                            |  __ \                      /  __ \ |                 | | | |
                            | |  \/ __ _ _ __ ___   ___  | /  \/ | ___  __ _ _ __  | | | |
                            | | __ / _` | '_ ` _ \ / _ \ | |   | |/ _ \/ _` | '__| | | | |
                            | |_\ \ (_| | | | | | |  __/ | \__/\ |  __/ (_| | |    |_| |_|
                             \____/\__,_|_| |_| |_|\___|  \____/_|\___|\__,_|_|    (_) (_)
                                                              
                                                              
                                                Pressed any key!
");
            Console.ReadKey(true);
        
        
        }

    }
}
