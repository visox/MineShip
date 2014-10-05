using MineShip.Blocks;
using MineShip.Blocks.BlocksHolderPatterns;
using MineShip.World;
using SiliconStudio.Core.Mathematics;
using SiliconStudio.Paradox.Graphics;
using SiliconStudio.Paradox.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineShip.WorldEntities.Ships
{
    class PlayerShip : AbstractShip
    {
        public PlayerShip(MineShipWorld world, Vector2 worldPosition)
            : base(world, worldPosition)
        {
            this._blocksHolder = BlocksHolderPatternSupplier.getExampleShipPatter(this._world);
            this._blocksHolder.Position = new Vector2(this.WorldPosition.X, this.WorldPosition.Y);
        }

      /*  public override void Draw(SpriteBatch spriteBatch, Vector2 worldPositionOffset, float scale)
        {
            // worldPositionOffset ignore .. ship in middle
            base.Draw(spriteBatch, worldPositionOffset, scale);
        }*/

        public override void Update(double delta)
        {
            userInputHandle();
        }

         

        private void userInputHandle()
        {
            InputManager input = this._world.getGame().getInput();

            if (input.IsMouseButtonPressed(MouseButton.Left))
            {
                Vector2 pos = input.MousePosition;

                Vector2 realPos = new Vector2(pos.X * this._world.getGame().getScreenSize().X,
                    pos.Y * this._world.getGame().getScreenSize().Y);

                Vector2 offset = new Vector2(realPos.X - (this._world.getGame().getScreenSize().X / 2),
                    realPos.Y - (this._world.getGame().getScreenSize().Y / 2));

                if (offset.Length() > 10)
                {
                    offSetPosition(offset);
                }

            }
        }

        private void offSetPosition(Vector2 offset)
        {
            this.WorldPosition = new Vector2(this.WorldPosition.X + offset.X, this.WorldPosition.Y + offset.Y);
         //   this._world.offSetWorldPosition(offset.X, offset.Y);
        }

    }
}
