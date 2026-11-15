using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    public enum E_DrawObjectType
    {
        Wall,
        FixedBlock,
        Block,
        Line,
        Square,
        TShape,
        LShape,
        JShape,
        SShape,
        ZShape
    }

    internal class DrawObject : IDraw
    {
        Position pos;
        E_DrawObjectType type;

        public DrawObject(Position position, E_DrawObjectType drawObjectType)
        {
            pos = position;
            type = drawObjectType;
        }

        public void Draw()
        {
            // 根据类型绘制不同的图形
            switch (type)
            {
                case E_DrawObjectType.Wall:
                    // Draw Wall
                    Console.SetCursorPosition(pos.X, pos.Y);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("■");
                    break;
                case E_DrawObjectType.FixedBlock:
                    // Draw FixedBlock
                    break;
                case E_DrawObjectType.Block:
                    // Draw Block
                    break;
                case E_DrawObjectType.Line:
                    // Draw Line
                    break;
                case E_DrawObjectType.Square:
                    // Draw Square
                    break;
                case E_DrawObjectType.TShape:
                    // Draw TShape
                    break;
                case E_DrawObjectType.LShape:
                    // Draw LShape
                    break;
                case E_DrawObjectType.JShape:
                    // Draw JShape
                    break;
                case E_DrawObjectType.SShape:
                    // Draw SShape
                    break;
                case E_DrawObjectType.ZShape:
                    // Draw ZShape
                    break;
            }
        }

        // 方块类型的改变方法
        public void ChangeType(E_DrawObjectType newType)
        {
            type = newType;
        }
    }
}
