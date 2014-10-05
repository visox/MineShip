using MineShip.Blocks;
using MineShip.Draw;
using MineShip.WorldEntities;
using MineShip.WorldEntities.Ships;
using SiliconStudio.Core;
using SiliconStudio.Core.Mathematics;
using SiliconStudio.Paradox;
using SiliconStudio.Paradox.Games;
using SiliconStudio.Paradox.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineShip.World
{
    public class MineShipWorld
    {

        DrawManager _drawManager;
   //     Vector2 _worldPosition;
        Vector2 _worldPositionOffset;
        float _worldScale;
        MineShipGame _game;
        PlayerShip playerShip;
        List<AbstractWorldEntity> _entities;

        public MineShipWorld(MineShipGame game) 
        {
            _game = game;
          //  _worldPosition = new Vector2(0,0);
            _worldPositionOffset = new Vector2();
            _worldScale = 1f;

            _entities = new List<AbstractWorldEntity>();

            playerShip = new PlayerShip(this, new Vector2(0, 0));
            _entities.Add(playerShip);


            SimpleEnemyShip ses = new SimpleEnemyShip(this, new Vector2(100, 100));
            _entities.Add(ses);
            

            _drawManager = new DrawManager(_entities.ToList<MineShip.Draw.ISpaceWorldDrawable>());
        }

     /*   public void offSetWorldPosition(float x, float y)
        {
            this._worldPosition.X += x;
            this._worldPosition.Y += y;
        }*/

        public MineShipGame getGame()
        {
            return this._game;
        }

        public void LoadContent()
        {
      //      AbstractBlock.LoadContent(Asset);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            _worldPositionOffset.X = -playerShip.WorldPosition.X + (this._game.getScreenSize().X / 2);
            _worldPositionOffset.Y = -playerShip.WorldPosition.Y + (this._game.getScreenSize().Y / 2);

            _drawManager.Draw(spriteBatch, _worldPositionOffset, _worldScale);
        }

        public void Update(double delta)
        {
            foreach (AbstractWorldEntity entity in this._entities)
            {
                entity.Update(delta);
            }
            //      _drawManager.Draw();
        }
    }
}
