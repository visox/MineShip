using SiliconStudio.Core.Mathematics;
using SiliconStudio.Paradox.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineShip.Draw
{
    interface ISpaceWorldDrawable
    {
        void Draw(SpriteBatch spriteBatch, Vector2 worldPositionOffset, float scale);
    }
}
