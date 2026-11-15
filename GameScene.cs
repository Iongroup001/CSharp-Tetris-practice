using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    internal class GameScene : ISceneUpdate
    {
        private Map map;
        private BlockWorker blockWorker;

        public GameScene()
        {
            // 初始化计时器
            Timer.Reset();
            Timer.Start();
            Information.lastTime = Timer.ElapsedMilliseconds;
            Console.Clear();

            // 初始化地图
            map = new Map();

            // 初始化方块生成器
            blockWorker = new BlockWorker();
        }
        public void Update()
        {
            map.Draw();
            blockWorker.Draw();
        }
    }
}
