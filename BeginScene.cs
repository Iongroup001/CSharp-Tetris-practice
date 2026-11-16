using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    internal class BeginScene : BeginOrEndBaseScene
    {
        public BeginScene()
        {
            Console.Clear();
            strTitle = "俄罗斯方块";
            strOne = "开始游戏";
        }
        protected override void HandleInput()
        {
            switch (selectedIndex)
            {
                case 0:
                    //切换到游戏场景
                    Game.ChangeScene(E_SceneType.GameScene);
                    Game.timeDelay = Game.originTimeDelay;
                    break;
                case 1:
                    //退出游戏
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
