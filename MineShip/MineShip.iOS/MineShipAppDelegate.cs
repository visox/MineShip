using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SiliconStudio.Paradox.Starter;

namespace MineShip
{
    [Register("MineShipAppDelegate")]
    public class MineShipAppDelegate : ParadoxApplicationDelegate
    {
        /// This method is invoked when the application has loaded and is ready to run the gane.
        // In this method you should instantiate the game and perform additional setup here.
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // Instantiate the game
            Game = new MineShipGame();

            return base.FinishedLaunching(app, options);
        }

        static void Main(string[] args)
        {
            UIApplication.Main(args, null, "MineShipAppDelegate");
        }

        public override void WillTerminate(UIApplication application)
        {
            Game.Dispose();
        }
    }
}
