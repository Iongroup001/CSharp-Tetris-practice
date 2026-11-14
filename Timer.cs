using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace 俄罗斯方块
{
    internal static class Timer
    {
        private static Stopwatch stopwatch = new Stopwatch();
        public static void Start()
        {
            stopwatch.Start();
        }
        public static void Stop()
        {
            stopwatch.Stop();
        }
        public static void Reset()
        {
            stopwatch.Reset();
        }
        public static long ElapsedMilliseconds
        {
            get { return stopwatch.ElapsedMilliseconds; }
        }
    }
}
