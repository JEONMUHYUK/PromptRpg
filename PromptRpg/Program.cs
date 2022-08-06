using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptRpg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataManager dataManager = new DataManager();            // DataManager 생성자

            dataManager.RunRpg();                                   // DataManager클래스의 RunRpg를 실행한다.
        }
    }
}
