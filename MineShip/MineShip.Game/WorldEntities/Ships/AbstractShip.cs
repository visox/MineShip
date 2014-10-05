﻿using SiliconStudio.Core.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineShip.WorldEntities.Ships
{
    abstract class AbstractShip : AbstractWorldEntity
    {

        public AbstractShip(World.MineShipWorld world, Vector2 worldPosition)
            : base(world, worldPosition)
        {
           
        }

    }
}
