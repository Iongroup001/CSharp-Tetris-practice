using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    //场景类型枚举
    public enum E_SceneType
    {
        StartScene,
        GameScene,
        EndScene
    }

    internal class Game
    {
        //窗口宽高
        public static int Width = 46;
        public static int Height = 30;
        public const int originTimeDelay = 333; //延时333毫秒
        public static int timeDelay = originTimeDelay;

        //当前选中的场景
        public static ISceneUpdate nowScene;

        public Game()
        {
            //设置窗口大小
            Console.SetWindowSize(Width + 1, Height + 1);
            //设置光标不可见
            Console.CursorVisible = false;
            //设置缓冲区大小
            Console.SetBufferSize(Width + 1, Height + 1);
        }

        //游戏主循环
        public void Start()
        {
            //初始化场景
            nowScene = new BeginScene();

            //游戏主循环
            while (true)
            {
                //更新场景
                if (nowScene != null)
                    nowScene.Update();

                //更新计时器
                /*if (Timer.ElapsedMilliseconds - Information.lastTime >= 1000)
                {
                    Information.timeUpdate();
                    Information.lastTime = Timer.ElapsedMilliseconds;
                }

                Information.ScoreUpdate();*/
            }
        }

        //场景切换方法
        public static void ChangeScene(E_SceneType sceneType)
        {
            switch (sceneType)
            {
                case E_SceneType.StartScene:
                    nowScene = new BeginScene();
                    break;
                case E_SceneType.GameScene:
                    nowScene = new GameScene();
                    break;
                case E_SceneType.EndScene:
                    nowScene = new EndScene();
                    break;
            }
        }
    }
}
