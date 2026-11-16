using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    internal abstract class BeginOrEndBaseScene : ISceneUpdate
    {
        //当前选中的菜单项索引
        protected int selectedIndex = 0;
        protected string strTitle;
        protected string strOne;

        public void Update()
        {
            Console.Clear();
            //绘制标题
            Console.SetCursorPosition((Game.Width - strTitle.Length) / 2, 5);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(strTitle);
            //绘制菜单项
            Console.SetCursorPosition((Game.Width - strOne.Length) / 2, 8);
            Console.ForegroundColor = selectedIndex == 0 ? ConsoleColor.Red : ConsoleColor.White;
            Console.WriteLine(strOne);
            Console.SetCursorPosition((Game.Width - "退出游戏".Length) / 2, 10);
            Console.ForegroundColor = selectedIndex == 1 ? ConsoleColor.Red : ConsoleColor.White;
            Console.WriteLine("退出游戏");
            //处理输入
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    selectedIndex = 0;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    selectedIndex = 1;
                    break;
                case ConsoleKey.Spacebar:
                    HandleInput();
                    break;
            }
        }

        //处理输入的抽象方法
        protected abstract void HandleInput();
    }
}
