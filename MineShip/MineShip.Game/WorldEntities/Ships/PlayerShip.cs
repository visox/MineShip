using MineShip.Blocks;
using MineShip.World;
using SiliconStudio.Paradox.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineShip.WorldEntities.Ships
{
    class PlayerShip : AbstractShip
    {
        public PlayerShip(MineShipWorld world)
            : base(world)
        {
            this._blocks.Add(new Block(world.getGame().getAssetManager().Load<Texture2D>("Blocks/Textures/metal1_block")));
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            this.DrawBlocks(spriteBatch);
        }
    }
}
