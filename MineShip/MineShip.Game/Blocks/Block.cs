using SiliconStudio.Core.Mathematics;
using SiliconStudio.Paradox.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineShip.Blocks
{
    class Block : AbstractBlock
    {

        public Block(Texture2D texture)
            :base(texture)
        {
        }
        /*
        public Block(string blockType, BlocksHolder blocksHolder, Vector2 positionInBlocksHolder)
            : base(blockType, blocksHolder, positionInBlocksHolder)
        {
            
        }*/

    }
}
