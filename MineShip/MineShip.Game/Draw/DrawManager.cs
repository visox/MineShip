using SiliconStudio.Core.Mathematics;
using SiliconStudio.Paradox.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineShip.Draw
{
    class DrawManager
    {


        List<ISpaceWorldDrawable> _toDraw;

        public DrawManager(List<ISpaceWorldDrawable> toDraw)
        {
            _toDraw = toDraw;
        }


        public void Draw(SpriteBatch spriteBatch, Vector2 worldPositionOffset, float scale)
        {
            spriteBatch.Begin();
            foreach (var td in _toDraw)
            {
                td.Draw(spriteBatch, worldPositionOffset, scale);
            }
            spriteBatch.End();
        }

    }
}
