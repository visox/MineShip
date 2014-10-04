using Android.App;
using Android.OS;

using SiliconStudio.Paradox.Starter;

namespace MineShip
{
    [Activity(MainLauncher = true, 
              Icon = "@drawable/icon", 
              ScreenOrientation = Android.Content.PM.ScreenOrientation.ReverseLandscape,
              ConfigurationChanges = Android.Content.PM.ConfigChanges.UiMode)]
    public class MineShipActivity : AndroidParadoxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Profiler.EnableAll();
            Game = new MineShipGame();
            Game.Run(GameContext);
        }

        protected override void OnDestroy()
        {
            Game.Dispose();

            base.OnDestroy();
        }
    }
}
