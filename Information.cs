using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    public static class Information
    {
        public static long lastTime;
        public static int score = 0;
        public static int min = 0;
        public static int sec = 0;
        public static void ScoreUpdate()
        {
            Console.SetCursorPosition(28, 25);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"分数：{score}");
        }
        public static void timeUpdate()
        {
            if (sec == 59)
            {
                sec = 0;
                min++;
            }
            else
                sec++;
            Console.SetCursorPosition(6, 25);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("游戏时间：");
            Console.SetCursorPosition(16, 25);
            Console.WriteLine($"{min:D2}:{sec:D2}");
        }
    }
}
