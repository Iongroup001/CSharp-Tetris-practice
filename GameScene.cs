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
                            if (blockWorker.CanRightRotate(map))
                                blockWorker.RightRotate();
                            break;
                        case ConsoleKey.A:
                            if (blockWorker.CanLeftMove(map))
                                blockWorker.LeftMove();
                            break;
                        case ConsoleKey.D:
                            if (blockWorker.CanRightMove(map))
                                blockWorker.RightMove();
                            break;
                        case ConsoleKey.S:
                            if (blockWorker.CanDownMove(map))
                                blockWorker.autoDownMove();
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
                if (blockWorker.CanDownMove(map))
                    blockWorker.autoDownMove();
                else
                {
                    blockWorker.FixBlock(map);
                    blockWorker = new BlockWorker();
                }
                    
            }
            if (map.IsFull())
            {
                InputThread.Instance.inputEvent -= InputCheckThread;
                Game.ChangeScene(E_SceneType.EndScene);
            }

            Thread.Sleep(200);
        }
    }
}
