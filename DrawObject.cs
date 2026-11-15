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
        public Position pos;
        public E_DrawObjectType type;
        public ConsoleColor color;

        public DrawObject(E_DrawObjectType drawObjectType)
        {
            pos = new Position(0, 0); // 默认位置为 (0, 0)
            type = drawObjectType;
        }
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
                case E_DrawObjectType.Line:
                    // Draw Line
                    Console.SetCursorPosition(pos.X, pos.Y);
                    Console.ForegroundColor = color;
                    Console.Write("■");
                    break;
                case E_DrawObjectType.Square:
                    // Draw Square
                    Console.SetCursorPosition(pos.X, pos.Y);
                    Console.ForegroundColor = color;
                    Console.Write("■");
                    break;
                case E_DrawObjectType.TShape:
                    // Draw TShape
                    Console.SetCursorPosition(pos.X, pos.Y);
                    Console.ForegroundColor = color;
                    Console.Write("■");
                    break;
                case E_DrawObjectType.LShape:
                    // Draw LShape
                    Console.SetCursorPosition(pos.X, pos.Y);
                    Console.ForegroundColor = color;
                    Console.Write("■");
                    break;
                case E_DrawObjectType.JShape:
                    // Draw JShape
                    Console.SetCursorPosition(pos.X, pos.Y);
                    Console.ForegroundColor = color;
                    Console.Write("■");
                    break;
                case E_DrawObjectType.SShape:
                    // Draw SShape
                    Console.SetCursorPosition(pos.X, pos.Y);
                    Console.ForegroundColor = color;
                    Console.Write("■");
                    break;
                case E_DrawObjectType.ZShape:
                    // Draw ZShape
                    Console.SetCursorPosition(pos.X, pos.Y);
                    Console.ForegroundColor = color;
                    Console.Write("■");
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
