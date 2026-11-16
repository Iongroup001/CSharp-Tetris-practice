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
        private long lastTime;
        private int min;
        private int sec;
        private int score;

        public GameScene()
        {
            Console.Clear();
            Timer.Start();
            lastTime = 0;
            min = 0;
            sec = 0;
            score = 0;

            // 初始化地图
            map = new Map();

            // 初始化方块生成器
            blockWorker = new BlockWorker();

            // 订阅事件
            InputThread.Instance.inputEvent += InputCheckThread;
            InfoThread.Info.infoEvent += TimerThread;
            InfoThread.Info.infoEvent += ScoreThread;
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

        // 计时器
        public void TimerThread()
        {
            lock (this)
            {
                //更新计时器
                if (Timer.ElapsedMilliseconds - lastTime >= 1000)
                {
                    if (sec == 59)
                    {
                        sec = 0;
                        min++;
                    }
                    else
                        sec++;
                    Console.SetCursorPosition(15, 25);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{min:D2}:{sec:D2}");
                    lastTime = Timer.ElapsedMilliseconds;
                }
            }
        }

        // 分数计数
        public void ScoreThread()
        {
            lock(this)
            {
                if (score != map.DelLineCount * 10)
                {
                    score = map.DelLineCount * 10;
                    Console.SetCursorPosition(33, 25);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{score}");
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
                InfoThread.Info.infoEvent -= TimerThread;
                InfoThread.Info.infoEvent -= ScoreThread;
                Game.ChangeScene(E_SceneType.EndScene);
            }

            Thread.Sleep(200);
        }
    }
}
