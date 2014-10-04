using MineShip.World;
using SiliconStudio.Core.Mathematics;
using SiliconStudio.Paradox.Graphics;
using SiliconStudio.Paradox.UI;
using SiliconStudio.Paradox.UI.Controls;
using SiliconStudio.Paradox.UI.Panels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineShip.Blocks
{
    public class BlocksHolder
    {
        Dictionary<Vector2, AbstractBlock> _blocks;
        public Vector2 Position { get; set; }
        public float Scale { get; set; }
        public float Angle { get; set; }
        public Vector2 PositionOrigin { get; set; }
        public Vector2 RotationOrigin { get; set; }
        private MineShipWorld _world;
        private Sprite _allTexture;
        

        private static const float SCALE_1_BLOCK_SIZE = 20;
        private static const float DEFAULT_SCALE = 1;
        private static const float DEFAULT_ANGLE = 0;


        public BlocksHolder(MineShipWorld world)
        {
            this._world = world;
            this.Position = new Vector2(0, 0);
            this.Scale = DEFAULT_SCALE;
            this.Angle = DEFAULT_ANGLE;
            this._blocks = new Dictionary<Vector2, AbstractBlock>();

            this._allTexture = Texture2D.New(
                this._world.getGame().GraphicsDevice, 
                (int)SCALE_1_BLOCK_SIZE,
                (int)SCALE_1_BLOCK_SIZE, PixelFormat.R8G8B8A8_UNorm, TextureFlags.ShaderResource).ToRenderTarget();

               // test
            ImageElement i = new ImageElement();
            i.Source = new UIImage((this._world.getGame().getAssetManager().Load<Texture2D>("Blocks/Textures/metal1_block")));
            this._allTexture.Texture..Children.Add(i);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this._allTexture., this.Position);
        }
    }
}
