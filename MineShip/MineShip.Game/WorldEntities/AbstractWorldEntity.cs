using MineShip.Blocks;
using MineShip.Draw;
using MineShip.World;
using SiliconStudio.Paradox.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineShip.WorldEntities
{
    abstract class AbstractWorldEntity : IDrawable
    {
        protected BlocksHolder _blocksHolder;
        protected MineShipWorld _world;


        protected AbstractWorldEntity(MineShipWorld world)
        {
            this._world = world;

            this._blocksHolder = new BlocksHolder();
        }

        public abstract void Draw(SpriteBatch spriteBatch);


        protected void DrawBlocks(SpriteBatch spriteBatch)
        {
            this._blocksHolder.Draw(spriteBatch);
        }


    }
}
