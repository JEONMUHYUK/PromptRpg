using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptRpg
{
    public abstract class BaseMonster
    {
        // monster 부모 클래스

        // //추상클래스의 자식들은 부모에서 abstract로 선언해둔것을 무조건 구현해야함
        public abstract void Monster();
        public abstract void OddNumber();                   // 홀
        public abstract void EvenNumber();                  // 짝
        public abstract void Escape();                      // 탈출

    }
}
