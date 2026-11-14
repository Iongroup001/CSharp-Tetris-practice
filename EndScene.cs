using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    internal class EndScene : BeginOrEndBaseScene
    {
        public EndScene()
        {
            Timer.Stop();
            Timer.Reset();
            Information.lastTime = Timer.ElapsedMilliseconds;
            Information.sec = 0;
            Information.min = 0;
            Console.Clear();
            strTitle = "游戏结束";
            strOne = "回到开始界面";
        }
        protected override void HandleInput()
        {
            switch (selectedIndex)
            {
                case 0:
                    //切换到开始场景
                    Game.ChangeScene(E_SceneType.StartScene);
                    break;
                case 1:
                    //退出游戏
                    Environment.Exit(0);
                    break;
            }
        }
    }
}