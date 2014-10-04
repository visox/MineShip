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


        List<IDrawable> _toDraw;

        public DrawManager(List<IDrawable> toDraw)
        {
            _toDraw = toDraw;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            foreach (var td in _toDraw)
            {
                td.Draw(spriteBatch);
            }
            spriteBatch.End();
        }

    }
}
