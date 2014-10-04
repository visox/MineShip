using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiliconStudio.Core;
using SiliconStudio.Core.Mathematics;
using SiliconStudio.Paradox.Graphics;
using SiliconStudio.Paradox.UI;
using SiliconStudio.Paradox.UI.Controls;
using SiliconStudio.Paradox.UI.Panels;
using SiliconStudio.Paradox.Games;

namespace MineShip.Screens
{ 
    public class InSpaceScreen: AbstractScreen
    {
        public InSpaceScreen(MineShipGame game)
            : base(game)
        {
            CreateScene();
        }


        protected override void LoadScene()
        {
            var mainMenuCanvas = new Canvas();
        }

        protected override void UpdateScene(double delta)
        {
            base.UpdateScene(delta);
        }
        
    }
}
