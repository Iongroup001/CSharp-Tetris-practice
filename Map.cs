using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    internal class Map : IDraw
    {
        public static int leftEdge = 2;
        public static int rightEdge = 42;
        public static int topEdge = 1;
        public static int bottomEdge = 20;

        public Map()
        {
            for (int i = leftEdge - 2; i <= rightEdge; i += 2)
            {
                wall.Add(new DrawObject(new Position(i, bottomEdge + 1), E_DrawObjectType.Wall));
            }
            for (int i = topEdge; i <= bottomEdge; i++)
            {
                wall.Add(new DrawObject(new Position(leftEdge - 2, i), E_DrawObjectType.Wall));
                wall.Add(new DrawObject(new Position(rightEdge, i), E_DrawObjectType.Wall));
            }
        }

        //地图周围的墙壁
        private List<DrawObject> wall = new List<DrawObject>();
        //地图中已经固定的方块
        private List<DrawObject> fixedBlocks = new List<DrawObject>();

        public void Draw()
        {
            foreach (var item in wall)
            {
                item.Draw();
            }
            foreach (var item in fixedBlocks)
            {
                item.Draw();
            }
        }

        // 当方块固定后，将其添加到固定方块列表中
        public void AddFixedBlock(DrawObject block)
        {
            fixedBlocks.Add(block);
        }
    }
}
