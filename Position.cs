using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    internal struct Position
    {
        public int X;
        public int Y;
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Position operator +(Position a, Position b)
        {
            return new Position(a.X + b.X, a.Y + b.Y);
        }

        public static bool operator ==(Position a, Position b)
        {
            if (a.X == b.X && a.Y == b.Y)
                return true;
            return false;
        }

        public static bool operator !=(Position a, Position b)
        {
            return !(a == b);
        }
    }
}
