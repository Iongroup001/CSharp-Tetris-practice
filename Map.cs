using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace 俄罗斯方块
{
    internal class Map : IDraw
    {
        public static int leftEdge = 2;
        public static int rightEdge = 42;
        public static int topEdge = 1;
        public static int bottomEdge = 20;
        private int[] lineRecord;
        private int delLineCount;

        public Map()
        {
            lineRecord = new int[bottomEdge + 1];
            delLineCount = 0;

            for (int i = leftEdge - 2; i <= rightEdge; i += 2)
            {
                wall.Add(new DrawObject(new Position(i, bottomEdge + 1), E_DrawObjectType.Wall));
            }
            for (int i = topEdge; i <= bottomEdge; i++)
            {
                wall.Add(new DrawObject(new Position(leftEdge - 2, i), E_DrawObjectType.Wall));
                wall.Add(new DrawObject(new Position(rightEdge, i), E_DrawObjectType.Wall));
            }

            // 由于墙壁固定，故在初始化时就创建，节约性能
            foreach (var item in wall)
            {
                item.Draw();
            }

            // 信息输出
            Console.SetCursorPosition(5, 25);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("游戏时间：00:00");
            Console.SetCursorPosition(27, 25);
            Console.Write("分数：0");
        }

        //地图周围的墙壁
        private List<DrawObject> wall = new List<DrawObject>();
        //地图中已经固定的方块
        public List<DrawObject> fixedBlocks = new List<DrawObject>();

        public void Draw()
        {
            foreach (var item in fixedBlocks)
            {
                item.Draw();
            }
        }

        // 当方块固定后，将其添加到固定方块列表中
        public void AddFixedBlock(List<DrawObject> blocks)
        {
            foreach (var block in blocks)
            {
                block.ChangeType(E_DrawObjectType.FixedBlock);
                fixedBlocks.Add(block);

                // 记录每层固定的方块数量
                if (block.pos.Y >= 0)
                    lineRecord[bottomEdge - block.pos.Y]++;
            }

            if (IsRemoveFixedBlock())
            {
                RemoveDraw();
                RemoveFixedBlock();
                Draw();
            }
        }

        // 检测一层是否已满
        public bool IsRemoveFixedBlock()
        {
            for (int i = 0; i < bottomEdge; i++)
            {
                if (lineRecord[i] == (rightEdge - leftEdge) / 2)
                {
                    return true;
                }
            }
            return false;
        }
        public void RemoveFixedBlock()
        {
            // 临时存储待移除方块
            List<DrawObject> delBlocks = new List<DrawObject>();

            for (int i = 0; i < bottomEdge; i++)
            {
                if (lineRecord[i] == (rightEdge - leftEdge) / 2)
                {
                    for (int j = 0; j < fixedBlocks.Count; j++)
                    {
                        if (fixedBlocks[j].pos.Y == bottomEdge - i)
                            delBlocks.Add(fixedBlocks[j]);
                        else if (fixedBlocks[j].pos.Y < bottomEdge - i)
                            fixedBlocks[j].pos.Y++;
                    }

                    // 移除待移除的方块
                    for (int j = 0; j < delBlocks.Count; j++)
                        fixedBlocks.Remove(delBlocks[j]);

                    // 记录数组迁移
                    lineRecord[i] = 0;
                    for (int j = 0; j < lineRecord.Length - 1; j++)
                        lineRecord[j] = lineRecord[j + 1];

                    delLineCount++;

                    // 递归检查是否还有可移除行
                    RemoveFixedBlock();
                    break;
                }
            }
        }

        public void RemoveDraw()
        {
            foreach (DrawObject block in fixedBlocks)
            {
                block.ClearDraw();
            }
        }

        // 检查是否溢出地图
        public bool IsFull()
        {
            if (lineRecord[bottomEdge] > 0)
                return true;
            return false;
        }

        public int DelLineCount
        {
            get { return delLineCount; }
        }
    }
}
