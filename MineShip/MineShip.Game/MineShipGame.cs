using System.Threading.Tasks;
using SiliconStudio.Core.Mathematics;
using SiliconStudio.Paradox;
using SiliconStudio.Paradox.Effects;
using SiliconStudio.Paradox.Graphics;
using MineShip.Screens;
using MineShip.Draw;
using MineShip.World;
using SiliconStudio.Core.Serialization.Assets;
using SiliconStudio.Paradox.Games;
using SiliconStudio.Paradox.UI.Controls;
using SiliconStudio.Paradox.UI;
using System;
using SiliconStudio.Paradox.Input;

namespace MineShip
{
    public class MineShipGame : Game
    {
  

        protected static readonly Vector3 GameVirtualResolution = new Vector3(800, 600, 10f);

        protected SpriteBatch spriteBatch;

        private ContentDecorator uiContainer;

        protected MineShipWorld _mineShipWorld;
        protected MainMenuScreen _mainMenuScreen;
        protected InSpaceScreen _inSpaceScreen;
        protected AbstractScreen _currentActiveScreen;

        protected Boolean _inGame = false;

        public MineShipGame()
        {
            // Target 9.1 profile by default
            GraphicsDeviceManager.PreferredGraphicsProfile = new[] { GraphicsProfile.Level_9_1 };
            GraphicsDeviceManager.PreferredBackBufferWidth = (int)GameVirtualResolution.X;
            GraphicsDeviceManager.PreferredBackBufferHeight = (int)GameVirtualResolution.Y;
        }

      
        public AssetManager getAssetManager()
        {
            return this.Asset;
        }

        public SpriteBatch getSpriteBatch()
        {
            return this.spriteBatch;
        }

        public InputManager getInput()
        {
            return this.Input;
        }

        protected override async Task LoadContent()
        {
            await base.LoadContent();

            spriteBatch = new SpriteBatch(GraphicsDevice) { VirtualResolution = VirtualResolution };

            CreatePipeline();
            VirtualResolution = GameVirtualResolution;

            // Enable visual of mouse in the game
            Window.IsMouseVisible = true;

            // Disable multi-touch input for the game, since there is no need
            Input.MultiTouchEnabled = false;   

            uiContainer = new ContentDecorator();
            UI.RootElement = uiContainer;

            _mainMenuScreen = new MainMenuScreen(this);
            _inSpaceScreen = new InSpaceScreen(this);
            ShowMainMenuScreen();          

            Script.Add(Update);

        }

        public void ShowMainMenuScreen()
        {
            _mainMenuScreen.ShowScreen();
            _currentActiveScreen = _mainMenuScreen;
        }

        public void ShowInSpaceScreen()
        {
            _inSpaceScreen.ShowScreen();
            _currentActiveScreen = _inSpaceScreen;
         //   uiContainer.Content = _inSpaceScreen.ScreenRoot;
        }

        protected Vector2 _screenSize = new Vector2();

        public Vector2 getScreenSize()
        {
         /*   if (_currentActiveScreen.ScreenRoot != null)
            {
                _screenSize.X = _currentActiveScreen.ScreenRoot.ActualWidth;
                _screenSize.Y = _currentActiveScreen.ScreenRoot.ActualHeight;
            }
            else
            {*/
            _screenSize.X = this.GraphicsDevice.Viewport.Width * this.GraphicsDevice.Viewport.AspectRatio * this.GraphicsDevice.Viewport.AspectRatio;
            _screenSize.Y = this.GraphicsDevice.Viewport.Height * this.GraphicsDevice.Viewport.AspectRatio * this.GraphicsDevice.Viewport.AspectRatio;
        //    }
            return _screenSize;
        }

        public void StartNewGame()
        {
            _inGame = true;
            _mineShipWorld = new MineShipWorld(this);
            _mineShipWorld.LoadContent();

            // todo async, add loading screen then wait..

            ShowInSpaceScreen();
        }


        private void CreatePipeline()
        {
            // Create the RenderTarget setter. This clears and sets the render targets.
            var renderTargetSetter = new RenderTargetSetter(Services) { ClearColor = Color.Black };

            // Create a DelegateRenderer to render custom sprites manually.
          //  var delegateBackgroundRenderer = new DelegateRenderer(Services);
          //  delegateBackgroundRenderer.Render += delegate { Draw(DrawTime); };

            // Create a Sprite Renderer to render SpriteComponents.
            var spriteRenderer = new SpriteRenderer(Services);
            
            // Create UI Renderer
            var uiRenderer = new UIRenderer(Services);

            // Add renderers into the pipeline. Note that the order matters. 
            // The renderers are called in the same order they are included into the pipeline.
            RenderSystem.Pipeline.Renderers.Add(renderTargetSetter);
        //    RenderSystem.Pipeline.Renderers.Add(delegateBackgroundRenderer);
            RenderSystem.Pipeline.Renderers.Add(spriteRenderer);
            RenderSystem.Pipeline.Renderers.Add(uiRenderer);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            if(_inGame)
                this._mineShipWorld.Draw(spriteBatch, gameTime);
        }
        

        private async Task Update()
        {
           // double last = UpdateTime.Elapsed.TotalSeconds;
            while (IsRunning)
            {

                await Script.NextFrame();
             //   double delta = UpdateTime.Elapsed.TotalSeconds - last;

                if(_inGame)
                    this._mineShipWorld.Update(UpdateTime.Elapsed.TotalSeconds);

                AbstractScreen.UpdateCurrentScene(UpdateTime.Elapsed.TotalSeconds);




             //   last = UpdateTime.Elapsed.TotalSeconds;
            }
        }

    }
}
