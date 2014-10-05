using MineShip.Draw;
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
       // public float Scale { get; set; }
        public float Angle { get; set; }
        public Vector2 PositionOrigin { get; set; }
        public Vector2 RotationOrigin { get; set; }
        private MineShipWorld _world;
        private Texture _allTextures;
        private int _maxX, _minX, _maxY, _minY;

        private static readonly int SCALE_1_BLOCK_SIZE = 16;
        private static readonly float DEFAULT_SCALE = 1;
        private static readonly float DEFAULT_ANGLE = 0;


        public BlocksHolder(MineShipWorld world)
        {
            this._world = world;
            this.Position = new Vector2(0, 0);
     //       this.Scale = DEFAULT_SCALE;
            this.Angle = DEFAULT_ANGLE;
            this._blocks = new Dictionary<Vector2, AbstractBlock>();
            this._maxX = this._maxY = this._minX = this._minY = 0;
        }

        Vector2 _realBlockPosition = new Vector2();

        public void addBlocks(Dictionary<Vector2, AbstractBlock> blocksToAdd)
        {
            foreach (Vector2 v in blocksToAdd.Keys)
            {
                if (this._blocks.ContainsKey(v))
                {
                    this._blocks[v] = blocksToAdd[v];
                }
                else
                {
                    this._blocks.Add(v, blocksToAdd[v]);
                }

                if (v.X > _maxX)
                    _maxX = (int)v.X;
                if (v.X < _minX)
                    _minX = (int)v.X;
                if (v.Y > _maxY)
                    _maxY = (int)v.Y;
                if (v.Y < _minY)
                    _minY = (int)v.Y;
            }


            this._allTextures =
                     Texture2D.New(
               this._world.getGame().GraphicsDevice,
               (int)(SCALE_1_BLOCK_SIZE * 1 * ((_maxX - _minX) + 1)),
               (int)(SCALE_1_BLOCK_SIZE * 1 * ((_maxY - _minY) + 1)),
               PixelFormat.BC1_UNorm, TextureFlags.ShaderResource);


            foreach (Vector2 v in this._blocks.Keys)
            {
                _realBlockPosition.X = v.X - _minX;
                _realBlockPosition.Y = v.Y - _minY;

                Texture toDraw = this._blocks[v].getTexture(this._world.getGame().Asset);
                toDraw.Height = SCALE_1_BLOCK_SIZE;
                toDraw.Width = SCALE_1_BLOCK_SIZE;
             //   Color toColor = (Color)this._blocks[v].getColor();

                
                Color[] imageData = new Color[(toDraw.Width * toDraw.Height) / (sizeof(PixelFormat) * 2)];
                toDraw.GetData<Color>(imageData);
                _allTextures.SetData<Color>(
                    this._world.getGame().GraphicsDevice,
                    imageData, 0, 0, 
                        new ResourceRegion(
                        (int)(SCALE_1_BLOCK_SIZE * _realBlockPosition.X)
                        ,(int)(SCALE_1_BLOCK_SIZE * _realBlockPosition.Y),
                        0, (int)(SCALE_1_BLOCK_SIZE * (_realBlockPosition.X + 1))
                        , (int)(SCALE_1_BLOCK_SIZE * (_realBlockPosition.Y +1)), 1));

            }


        }

        Vector2 _realPosition = new Vector2();

        public void Draw(SpriteBatch spriteBatch, Vector2 worldPositionOffset, float scale)
        {
            _realPosition.X = (this.Position.X - ((this.PositionOrigin.X - _minX) * SCALE_1_BLOCK_SIZE)) + worldPositionOffset.X;
            _realPosition.Y = (this.Position.Y - ((this.PositionOrigin.Y - _minY) * SCALE_1_BLOCK_SIZE)) + worldPositionOffset.Y;


            spriteBatch.Draw(this._allTextures, this._realPosition, Color.White, this.Angle, this.RotationOrigin,
               scale: scale);
        }
    }
}
