using MineShip.Blocks;
using MineShip.Draw;
using MineShip.World;
using SiliconStudio.Core.Mathematics;
using SiliconStudio.Paradox.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineShip.WorldEntities
{
    abstract class AbstractWorldEntity : ISpaceWorldDrawable
    {
        protected BlocksHolder _blocksHolder;
        protected MineShipWorld _world;
        private Vector2 _worldPosition;
        public Vector2 WorldPosition
        {
            get {return _worldPosition;}
            set 
            {
                if (value == _worldPosition)
                    return;

                _worldPosition = value;

                if (this._blocksHolder != null)
                    this._blocksHolder.Position = value;
            }
        }

        protected AbstractWorldEntity(MineShipWorld world, Vector2 worldPosition)
        {
            this._world = world;
            this.WorldPosition = worldPosition;
            
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 worldPositionOffset, float scale)
        {
            this._blocksHolder.Draw(spriteBatch, worldPositionOffset, scale);
        }

        public virtual void Update(double delta)
        {
 
        }


    }
}
