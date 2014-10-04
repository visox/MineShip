using MineShip.Blocks;
using MineShip.Draw;
using MineShip.WorldEntities;
using MineShip.WorldEntities.Ships;
using SiliconStudio.Core;
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

        MineShipGame _game;

        List<AbstractWorldEntity> _entities;

        public MineShipWorld(MineShipGame game) 
        {
            _game = game;            

            _entities = new List<AbstractWorldEntity>();

            PlayerShip ps = new PlayerShip(this);

            _entities.Add(ps);

            _drawManager = new DrawManager(_entities.ToList<MineShip.Draw.IDrawable>());
        }

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
            _drawManager.Draw(spriteBatch);
        }

        public void Update(double delta)
        {
            //      _drawManager.Draw();
        }
    }
}
