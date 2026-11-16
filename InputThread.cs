using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    internal class InputThread
    {
        Thread inputThread;

        // 输入检测事件
        public event Action inputEvent;

        private static InputThread instance = new InputThread();

        private InputThread()
        {
            inputThread = new Thread(InputCheck);
            inputThread.IsBackground = true;
            inputThread.Start();
        }

        public static InputThread Instance { get { return instance; } }

        private void InputCheck()
        {
            while (true)
            {
                inputEvent?.Invoke();
            }
        }
    }
}
