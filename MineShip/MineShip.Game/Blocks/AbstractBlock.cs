using MineShip.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiliconStudio.Paradox.Graphics;
using SiliconStudio.Core.Mathematics;
using SiliconStudio.Core.Serialization.Assets;

namespace MineShip.Blocks
{
    public abstract class AbstractBlock
    {

        protected string _id;
        protected Texture2D _texture;
     //   protected Color4 _color;


        protected AbstractBlock(string id)
        {
            _id = id;
        }

        public virtual Texture getTexture(AssetManager assestManager)
        {
            return BlockDefinitions.getTextureById(this._id, assestManager);
        }

       /* public virtual Color4 getColor()
        {
            return BlockDefinitions.getColorById(this._id);
        }*/

      /*  virtual public void Draw(SpriteBatch spriteBatch, float size)
        {
            spriteBatch.Draw(_texture, new Vector2(20, 20));
        }*/

    }
}
