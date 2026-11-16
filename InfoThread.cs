using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    internal class InfoThread
    {
        Thread infoThread;

        public event Action infoEvent;

        private static InfoThread info = new InfoThread();

        private InfoThread()
        {
            infoThread = new Thread(InfoUpdate);
            infoThread.IsBackground = true;
            infoThread.Start();
        }

        public static InfoThread Info { get { return info; } }

        private void InfoUpdate()
        {
            while (true)
            {
                infoEvent?.Invoke();
            }
        }
    }
}
