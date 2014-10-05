using MineShip.Blocks.BlocksHolderPatterns;
using MineShip.World;
using SiliconStudio.Core.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineShip.WorldEntities.Ships
{
    class SimpleEnemyShip :AbstractEnemyShip
    {
        public SimpleEnemyShip(MineShipWorld world, Vector2 worldPosition)
            : base(world, worldPosition)
        {
            this._blocksHolder = BlocksHolderPatternSupplier.getExampleShipPatter(this._world);
            this._blocksHolder.Position = new Vector2(this.WorldPosition.X, this.WorldPosition.Y);

        }
    }
}
