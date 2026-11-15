using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    // 变形类型枚举
    public enum E_MoveType
    {
        left,
        right,
    }

    internal class BlockWorker : IDraw
    {
        private List<DrawObject> blocks;
        private Dictionary<E_DrawObjectType, BlockInfo> blockInfo;
        private ConsoleColor color;
        private int currentIndex;

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
            currentIndex = index;
            BlockInfo nowBlockInfo = blockInfo[type];
            Position[] positions = nowBlockInfo[currentIndex];
            for (int i = 0; i < nowBlockInfo[currentIndex].Length; i++)
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

        // 擦除方块
        public void RemoveLastBlock()
        {
            foreach (var block in blocks)
            {
                Console.SetCursorPosition(block.pos.X, block.pos.Y);
                Console.Write("  ");
            }
        }

        // 判断方块是否可以转向
        public bool CanLeftRotate(Map map)
        {
            // 先模拟移动

            E_DrawObjectType type = blocks[0].type;
            BlockInfo nowBlockInfo = blockInfo[type];

            // 计算上一个方向的索引
            int prevIndex = currentIndex - 1 < 0 ? nowBlockInfo.dirCount - 1 : currentIndex - 1;
            // 获取上一个方向的位置信息
            Position[] prevPositions = nowBlockInfo[prevIndex];

            if (blocks[0].pos.X < Map.leftEdge ||
                blocks[0].pos.X >= Map.rightEdge ||
                blocks[0].pos.Y > Map.bottomEdge) return false;
            for (int i = 1; i < prevPositions.Length; i++)
            {
                if ((blocks[0].pos + prevPositions[i]).X < Map.leftEdge ||
                    (blocks[0].pos + prevPositions[i]).X >= Map.rightEdge ||
                    (blocks[0].pos + prevPositions[i]).Y > Map.bottomEdge) return false;
            }
            for (int j = 0; j < map.fixedBlocks.Count; j++)
                if (blocks[0].pos == map.fixedBlocks[j].pos) return false;
            for (int i = 1; i < blocks.Count; i++)
            {
                for (int j = 0; j < map.fixedBlocks.Count; j++)
                {
                    if ((blocks[0].pos + prevPositions[i]) == map.fixedBlocks[j].pos)
                        return false;
                }
            }
            return true;
        }
        public bool CanRightRotate(Map map)
        {
            // 先模拟移动

            E_DrawObjectType type = blocks[0].type;
            BlockInfo nowBlockInfo = blockInfo[type];

            // 计算下一个方向的索引
            int nextIndex = (currentIndex + 1) % nowBlockInfo.dirCount;
            // 获取下一个方向的位置信息
            Position[] nextPositions = nowBlockInfo[nextIndex];

            if (blocks[0].pos.X < Map.leftEdge ||
                blocks[0].pos.X >= Map.rightEdge ||
                blocks[0].pos.Y > Map.bottomEdge) return false;
            for (int i = 1; i < nextPositions.Length; i++)
            {
                if ((blocks[0].pos + nextPositions[i]).X < Map.leftEdge ||
                    (blocks[0].pos + nextPositions[i]).X >= Map.rightEdge ||
                    (blocks[0].pos + nextPositions[i]).Y > Map.bottomEdge) return false;
            }
            for (int j = 0; j < map.fixedBlocks.Count; j++)
                if (blocks[0].pos == map.fixedBlocks[j].pos) return false;
            for (int i = 1; i < blocks.Count; i++)
            {
                for (int j = 0; j < map.fixedBlocks.Count; j++)
                {
                    if ((blocks[0].pos + nextPositions[i]) == map.fixedBlocks[j].pos)
                        return false;
                }
            }
            return true;
        }

        // 判断方块是否可以移动
        public bool CanLeftMove(Map map)
        {
            // 定义向左的单位向量
            Position left = new Position(-2, 0);

            for (int i = 0; i < blocks.Count; i++)
            {
                if ((blocks[i].pos + left).X < Map.leftEdge ||
                    (blocks[i].pos + left).X >= Map.rightEdge ||
                    (blocks[i].pos + left).Y > Map.bottomEdge) return false;
            }
            for (int i = 0; i < blocks.Count; i++)
            {
                for (int j = 0; j < map.fixedBlocks.Count; j++)
                {
                    if ((blocks[i].pos + left) == map.fixedBlocks[j].pos)
                        return false;
                }
            }
            return true;
        }
        public bool CanRighttMove(Map map)
        {
            // 定义向左的单位向量
            Position right = new Position(2, 0);

            for (int i = 0; i < blocks.Count; i++)
            {
                if ((blocks[i].pos + right).X < Map.leftEdge ||
                    (blocks[i].pos + right).X >= Map.rightEdge ||
                    (blocks[i].pos + right).Y > Map.bottomEdge) return false;
            }
            for (int i = 0; i < blocks.Count; i++)
            {
                for (int j = 0; j < map.fixedBlocks.Count; j++)
                {
                    if ((blocks[i].pos + right) == map.fixedBlocks[j].pos)
                        return false;
                }
            }
            return true;
        }

        // 方块向左转向
        public void LeftRotate()
        {
            // 先擦除上一次的方块
            RemoveLastBlock();

            E_DrawObjectType type = blocks[0].type;
            BlockInfo nowBlockInfo = blockInfo[type];

            // 计算上一个方向的索引
            int prevIndex = currentIndex - 1 < 0 ? nowBlockInfo.dirCount - 1 : currentIndex - 1;
            currentIndex = prevIndex;
            // 获取上一个方向的位置信息
            Position[] prevPositions = nowBlockInfo[prevIndex];
            // 更新方块的位置
            for (int i = 0; i < prevPositions.Length; i++)
            {
                blocks[i + 1].pos = blocks[0].pos + prevPositions[i];
            }

            // 重新绘制方块
            Draw();
        }

        // 方块向右转向
        public void RightRotate()
        {
            // 先擦除上一次的方块
            RemoveLastBlock();

            E_DrawObjectType type = blocks[0].type;
            BlockInfo nowBlockInfo = blockInfo[type];

            // 计算下一个方向的索引
            int nextIndex = (currentIndex + 1) % nowBlockInfo.dirCount;
            currentIndex = nextIndex;
            // 获取下一个方向的位置信息
            Position[] nextPositions = nowBlockInfo[nextIndex];
            // 更新方块的位置
            for (int i = 0; i < nextPositions.Length; i++)
            {
                blocks[i + 1].pos = blocks[0].pos + nextPositions[i];
            }

            // 重新绘制方块
            Draw();
        }

        // 方块向左移动
        public void LeftMove()
        {
            // 先擦除上一次的方块
            RemoveLastBlock();

            // 定义向左的单位向量
            Position left = new Position(-2, 0);
            // 更新方块的位置
            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i].pos += left;
            }

            // 重新绘制方块
            Draw();
        }

        // 方块向右移动
        public void RightMove()
        {
            // 先擦除上一次的方块
            RemoveLastBlock();

            // 定义向右的单位向量
            Position right = new Position(2, 0);
            // 更新方块的位置
            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i].pos += right;
            }

            // 重新绘制方块
            Draw();
        }
    }
}
