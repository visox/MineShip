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

        protected Texture2D _texture;
        protected Color4 _color;
        protected BlocksHolder _blocksHolder;
        protected string _blockType;
        protected Vector2 _positionInBlocksHolder;
        protected Vector2 _realPosition;

        protected AbstractBlock(Texture2D texture /*string blockType, BlocksHolder blocksHolder, Vector2 positionInBlocksHolder*/)
        {
          /*  this._blockType = blockType;
            this._blocksHolder = blocksHolder;
            this._positionInBlocksHolder = positionInBlocksHolder;
            this._realPosition = new Vector2();

            this.fillByBlockType(blockType);*/

            _texture = texture;
        }

        virtual public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Vector2(20, 20));
        }

        protected void countRealPosition()
        {
            _realPosition.X = 0;
            _realPosition.Y = 0;


        }



        protected static Dictionary<string, Texture2D> _textures;
        protected static Dictionary<string, Color4> _colors;

        public static void LoadContent(AssetManager Asset)
        {
            _textures = new Dictionary<string, Texture2D>();
            _textures.Add("metalSkeleton", Asset.Load<Texture2D>("Blocks/Textures/metal1_block"));

            _colors = new Dictionary<string, Color4>();
        }

        protected void fillByBlockType(string blockType)
        {
            _texture = (Texture2D)_textures[blockType].Clone();
            _color = _colors.ContainsKey(blockType) ? _colors[blockType] : Color4.White;
        }
    }
}
