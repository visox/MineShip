
namespace MineShip
{
    class MineShipApp
    {
        static void Main(string[] args)
        {
            // Profiler.EnableAll();
            using (var game = new MineShipGame())
            {
                game.Run();
            }
        }
    }
}
