using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    internal class BlockWorker : IDraw
    {
        private List<DrawObject> blocks;
        private Dictionary<E_DrawObjectType, BlockInfo> blockInfo;
        private ConsoleColor color;

        public BlockWorker()
        {
            blockInfo = new Dictionary<E_DrawObjectType, BlockInfo>();
            foreach (E_DrawObjectType type in Enum.GetValues(typeof(E_DrawObjectType)))
            {
                blockInfo[type] = new BlockInfo(type);
            }

            GetRandomBlock();
            color = GetRandomColor();
        }

        public void Draw()
        {
            foreach (var block in blocks)
            {
                block.color = color;
                block.Draw();
            }
        }

        // 随机生成一个方块
        public void GetRandomBlock()
        {
            Random random = new Random();
            E_DrawObjectType type = (E_DrawObjectType)random.Next(2, 9);
            blocks = new List<DrawObject>()
            {
                // 生成一个方块对象，该方块的位置为原点位置，类型为随机生成的类型
                new DrawObject(new Position(20, 4), type),

                new DrawObject(type),
                new DrawObject(type),
                new DrawObject(type),
            };

            // 随机选择一个方向，并获取其对应的位置信息
            int index = random.Next(0, blocks.Count);
            BlockInfo nowBlockInfo = blockInfo[type];
            Position[] positions = nowBlockInfo[index];
            for (int i = 0; i < nowBlockInfo[index].Length; i++)
            {
                blocks[i + 1].pos = blocks[0].pos + positions[i];
            }
        }

        // 随机一种颜色
        public ConsoleColor GetRandomColor()
        {
            Random random = new Random();
            ConsoleColor color = (ConsoleColor)random.Next(Enum.GetValues(typeof(ConsoleColor)).Length);
            if (color == ConsoleColor.Black || color == ConsoleColor.Gray ||
                color == ConsoleColor.DarkGray || color == ConsoleColor.White ||
                color == ConsoleColor.DarkMagenta) // 避免这些颜色
            {
                color = ConsoleColor.Red;
            }
            return color;
        }
    }
}
