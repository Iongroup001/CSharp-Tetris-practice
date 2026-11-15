using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    internal class BlockInfo
    {
        //方块方向及坐标信息容器
        private List<Position[]> dir;
        public int dirCount = 4;

        public BlockInfo(E_DrawObjectType type)
        {
            dir = new List<Position[]>();

            // 根据类型初始化方块坐标信息
            // 每种类型先定义一个原点位置，然后根据原点位置计算其他方块的相对位置
            switch (type)
            {
                case E_DrawObjectType.Line:
                    dir.Add(new Position[3] { new Position(0, -1), new Position(0, 1), new Position(0, 2) });
                    dir.Add(new Position[3] { new Position(-4, 0), new Position(-2, 0), new Position(2, 0) });
                    dir.Add(new Position[3] { new Position(0, -2), new Position(0, -1), new Position(0, 1) });
                    dir.Add(new Position[3] { new Position(-2, 0), new Position(2, 0), new Position(4, 0) });
                    break;
                case E_DrawObjectType.Square:
                    dir.Add(new Position[3] { new Position(0, 1), new Position(2, 0), new Position(2, 1) });
                    dir.Add(new Position[3] { new Position(0, 1), new Position(2, 0), new Position(2, 1) });
                    dir.Add(new Position[3] { new Position(0, 1), new Position(2, 0), new Position(2, 1) });
                    dir.Add(new Position[3] { new Position(0, 1), new Position(2, 0), new Position(2, 1) });
                    break;
                case E_DrawObjectType.TShape:
                    dir.Add(new Position[3] { new Position(-2, 0), new Position(2, 0), new Position(0, 1) });
                    dir.Add(new Position[3] { new Position(0, -1), new Position(0, 1), new Position(-2, 0) });
                    dir.Add(new Position[3] { new Position(-2, 0), new Position(2, 0), new Position(0, -1) });
                    dir.Add(new Position[3] { new Position(0, -1), new Position(0, 1), new Position(2, 0) });
                    break;
                case E_DrawObjectType.LShape:
                    dir.Add(new Position[3] { new Position(0, -1), new Position(0, 1), new Position(2, 1) });
                    dir.Add(new Position[3] { new Position(-2, 0), new Position(-2, 1), new Position(2, 0) });
                    dir.Add(new Position[3] { new Position(0, -1), new Position(0, 1), new Position(-2, -1) });
                    dir.Add(new Position[3] { new Position(-2, 0), new Position(2, 0), new Position(2, -1) });
                    break;
                case E_DrawObjectType.JShape:
                    dir.Add(new Position[3] { new Position(0, -1), new Position(0, 1), new Position(-2, 1) });
                    dir.Add(new Position[3] { new Position(-2, 0), new Position(2, 0), new Position(-2, -1) });
                    dir.Add(new Position[3] { new Position(0, -1), new Position(0, 1), new Position(2, -1) });
                    dir.Add(new Position[3] { new Position(-2, 0), new Position(2, 0), new Position(2, 1) });
                    break;
                case E_DrawObjectType.SShape:
                    dir.Add(new Position[3] { new Position(2, 0), new Position(0, 1), new Position(-2, 1) });
                    dir.Add(new Position[3] { new Position(0, -1), new Position(2, 0), new Position(2, 1) });
                    dir.Add(new Position[3] { new Position(2, 0), new Position(0, 1), new Position(-2, 1) });
                    dir.Add(new Position[3] { new Position(0, -1), new Position(2, 0), new Position(2, 1) });
                    break;
                case E_DrawObjectType.ZShape:
                    dir.Add(new Position[3] { new Position(-2, 0), new Position(0, 1), new Position(2, 1) });
                    dir.Add(new Position[3] { new Position(0, -1), new Position(-2, 0), new Position(-2, 1) });
                    dir.Add(new Position[3] { new Position(-2, 0), new Position(0, 1), new Position(2, 1) });
                    dir.Add(new Position[3] { new Position(0, -1), new Position(-2, 0), new Position(-2, 1) });
                    break;
            }
        }

        // 索引器获取指定方向的坐标信息
        public Position[] this[int index]
        {
            get
            {
                return dir[index];
            }
        }
    }
}