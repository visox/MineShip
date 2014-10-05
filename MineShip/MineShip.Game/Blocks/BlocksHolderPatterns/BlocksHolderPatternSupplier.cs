using MineShip.World;
using SiliconStudio.Core.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineShip.Blocks.BlocksHolderPatterns
{
    static class BlocksHolderPatternSupplier
    {
        public static BlocksHolder getExampleShipPatter(MineShipWorld world)
        {
            BlocksHolder result = new BlocksHolder(world);

            Dictionary<Vector2, AbstractBlock> blocks = new Dictionary<Vector2, AbstractBlock>();

           // blocks.Add(new Vector2(0, 0), new Block("metal1"));
            blocks.Add(new Vector2(0, -2), new Block("metal1"));

            blocks.Add(new Vector2(-1, -1), new Block("metal1"));
            blocks.Add(new Vector2(0, -1), new Block("metal1"));
            blocks.Add(new Vector2(1, -1), new Block("metal1"));

            blocks.Add(new Vector2(-1, 0), new Block("metal1"));
            blocks.Add(new Vector2(0, 0), new Block("metal1"));
            blocks.Add(new Vector2(1, 0), new Block("metal1"));

            blocks.Add(new Vector2(-1, 1), new Block("metal1"));
            blocks.Add(new Vector2(1, 1), new Block("metal1"));

            result.addBlocks(blocks);


            result.PositionOrigin = new Vector2(0.5f, 0);
            result.RotationOrigin = new Vector2(0.5f, 0);

            return result;
        }
    }
}
