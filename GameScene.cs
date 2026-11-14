using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    internal class GameScene : ISceneUpdate
    {
        public GameScene()
        {
            Timer.Reset();
            Timer.Start();
            Information.lastTime = Timer.ElapsedMilliseconds;
            Console.Clear();
        }
        public void Update()
        {

        }
    }
}
