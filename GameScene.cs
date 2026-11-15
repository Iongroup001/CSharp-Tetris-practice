using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            // 订阅事件
            InputThread.Instance.inputEvent += InputCheckThread;
        }

        // 输入检测线程
        public void InputCheckThread()
        {
            if (Console.KeyAvailable)
            {
                lock (this)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.Q:
                            if (blockWorker.CanLeftRotate(map))
                                blockWorker.LeftRotate();
                            break;
                        case ConsoleKey.E:
                            if (blockWorker.CanLeftRotate(map))
                                blockWorker.RightRotate();
                            break;
                        case ConsoleKey.A:
                            if (blockWorker.CanLeftMove(map))
                                blockWorker.LeftMove();
                            break;
                        case ConsoleKey.D:
                            if (blockWorker.CanRighttMove(map))
                                blockWorker.RightMove();
                            break;
                    }
                }
            }
        }

        public void Update()
        {
            lock (this)
            {
                map.Draw();
                blockWorker.Draw();
            }

            Thread.Sleep(333);
        }
    }
}
