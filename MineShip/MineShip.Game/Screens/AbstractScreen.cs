using SiliconStudio.Core;
using SiliconStudio.Core.Mathematics;
using SiliconStudio.Paradox;
using SiliconStudio.Paradox.Games;
using SiliconStudio.Paradox.Graphics;
using SiliconStudio.Paradox.UI;
using SiliconStudio.Paradox.UI.Controls;
using SiliconStudio.Paradox.UI.Panels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineShip.Screens
{
    public abstract class AbstractScreen : ScriptContext
    {
        protected readonly List<object> LoadedAssets = new List<object>();

        protected MineShipGame _game;

        protected bool SceneCreated;

        public ModalElement ScreenRoot { get; protected set; }
        
      //  public UIElement RootElement { get; protected set; }

        public bool IsRunning { get; set; }

        protected AbstractScreen(MineShipGame game)
            : base(game.Services)
        {
            _game = game;
        }

        protected void CreateScene()
        {
            if(!SceneCreated)
                LoadScene();

            SceneCreated = true;
        }

        public void ShowScreen()
        {
            UI.RootElement = ScreenRoot;
            _currentScreen = this;
        }

        protected T LoadAsset<T>(string assetName) where T : class
        {
            LoadedAssets.Add(Asset.Load<T>(assetName));

            return (T)LoadedAssets[LoadedAssets.Count-1];
        }

        protected abstract void LoadScene();
   
        protected virtual void UpdateScene(double delta)
        {
        }

        private static AbstractScreen _currentScreen;
        public static void UpdateCurrentScene(double delta)
        {
            if (_currentScreen != null)
                _currentScreen.UpdateScene(delta);
        }

        protected override void Destroy()
        {
            base.Destroy();

            SceneCreated = false;
            ScreenRoot = null;

            foreach (var asset in LoadedAssets)
                Asset.Unload(asset);

            LoadedAssets.Clear();
        }
    }
}
