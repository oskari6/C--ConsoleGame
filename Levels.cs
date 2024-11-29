
namespace ConsoleApp1
{
    abstract class Levels
    {
        private static int _points;//pisteet
        internal static int Points
        {
            get => _points;
            set => _points = value;
        }
        internal static int PointCounter(double multiplier, int result = 5)
        {
            switch (result)
            {
                case 1:
                    Points += (int)(100 * multiplier);
                    break;
                case 2:
                    Points += (int)(200 * multiplier);
                    break;
                case 3:
                    Points += (int)(300 * multiplier);
                    break;
                case 4:
                    Points += (int)(300 * multiplier);
                    break;
                case 5:
                    Points += (int)(500 * multiplier);
                    break;
                case 6:
                    Points += (int)(600 * multiplier);
                    break;
                case 7:
                    Points += (int)(700 * multiplier);
                    break;
                default:
                    Console.WriteLine("PointCounter() ei toiminut!");
                    break;
            }
            return Points;
        }//lasku tasojen välissä
        internal static int PointCounter(int seconds, int collectables)
        {
            Points += collectables;

            Points = seconds switch
            {
                < 600 and > 120 => Points += 500,
                < 120 and > 90 => Points += 400,
                < 90 and > 60 => Points += 300,
                < 60 and > 30 => Points += 200,
                < 30 and > 1 => Points += 100,
                _ => Points += 0
            };
            return Points;
        }//keräilyesineiden pisteytys pelin voitto ruudussa
    }
}