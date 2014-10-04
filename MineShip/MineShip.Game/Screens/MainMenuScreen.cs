using SiliconStudio.Core;
using SiliconStudio.Core.Mathematics;
using SiliconStudio.Paradox.Games;
using SiliconStudio.Paradox.Graphics;
using SiliconStudio.Paradox.UI;
using SiliconStudio.Paradox.UI.Controls;
using SiliconStudio.Paradox.UI.Events;
using SiliconStudio.Paradox.UI.Panels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineShip.Screens
{
    public class MainMenuScreen : AbstractScreen
    {
        public MainMenuScreen(MineShipGame game)
            : base(game)
        {
            CreateScene();
        }

        protected SpriteFont _spriteFont;
        protected UIImage _buttonImage;

        protected override void LoadScene()
        {                       
            _spriteFont = LoadAsset<SpriteFont>("UI/Fonts/Arial16RegularFont");
            _buttonImage = LoadAsset<UIImage>("UI/UI_images/buttonBackground");

            var mainMenuCanvas = new Canvas();

            var StartButton = new Button
            {
                Content = new TextBlock
                {
                    Font = _spriteFont,
                    Text = "Touch to Start",
                    TextColor = Color.Black,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                },
                NotPressedImage = _buttonImage,
                PressedImage = _buttonImage,
                Padding = new Thickness(5, 5, 5, 5),
                MinimumWidth = 250f,
                
            };
            StartButton.Click += (s, e) => this._game.StartNewGame();

            StartButton.SetCanvasPinOrigin(new Vector3(0.5f, 0.5f, 1f));
            StartButton.SetCanvasRelativePosition(new Vector3(0.5f, 0.1f, 0f));

            mainMenuCanvas.Children.Add(StartButton);

            ScreenRoot = new ModalElement
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Content = mainMenuCanvas
            };

           
        }

        protected override void UpdateScene(double delta)
        {
            base.UpdateScene(delta);
        }
    }
}
