
namespace ConsoleApp1
{
    abstract class Fights
    {   //viholliset
        private static BigRat? _enemy1;
        private static Goblin? _enemy2;
        private static HumanSourceress? _enemy3;
        private static HalfEatenSkeleton? _enemy4;
        private static RottenZombie? _enemy5;

        public static Random random = new Random();

        internal readonly static double critAmount = 1.5;
        internal readonly static double critChance = 25;
        internal static void FullFight(Characters character, int difficulty)
        {
            int? health;

            switch (difficulty)
            {
                case 1:
                    _enemy1 = new BigRat(50, 20);
                    _enemy2 = new Goblin(50, 20);
                    _enemy3 = new HumanSourceress(50, 20);
                    _enemy4 = new HalfEatenSkeleton(50, 20);
                    _enemy5 = new RottenZombie(100, 20);
                    Fight1.Print(_enemy1, character);
                    Fight2.Print(_enemy2, character);
                    Fight3.Print(_enemy3, character);
                    Fight4.Print(_enemy4, character);
                    Fight5.Print(_enemy5, character);
                    break;
                case 2:
                    _enemy1 = new BigRat(60, 20);
                    _enemy2 = new Goblin(60, 20);
                    _enemy3 = new HumanSourceress(60, 20);
                    _enemy4 = new HalfEatenSkeleton(60, 20);
                    _enemy5 = new RottenZombie(110, 20);
                    Fight1.Print(_enemy1, character);
                    Fight2.Print(_enemy2, character);
                    Fight3.Print(_enemy3, character);
                    Fight4.Print(_enemy4, character);
                    Fight5.Print(_enemy5, character);
                    break;
                case 3:
                    _enemy1 = new BigRat(70, 30);
                    _enemy2 = new Goblin(70, 30);
                    _enemy3 = new HumanSourceress(70, 30);
                    _enemy4 = new HalfEatenSkeleton(70, 30);
                    _enemy5 = new RottenZombie(120, 30);
                    Fight1.Print(_enemy1, character);
                    Fight2.Print(_enemy2, character);
                    Fight3.Print(_enemy3, character);
                    Fight4.Print(_enemy4, character);
                    Fight5.Print(_enemy5, character);
                    break;
                case 4:
                    _enemy1 = new BigRat(80, 30);
                    _enemy2 = new Goblin(80, 30);
                    _enemy3 = new HumanSourceress(80, 30);
                    _enemy4 = new HalfEatenSkeleton(80, 30);
                    _enemy5 = new RottenZombie(130, 30);
                    Fight1.Print(_enemy1, character);
                    Fight2.Print(_enemy2, character);
                    Fight3.Print(_enemy3, character);
                    Fight4.Print(_enemy4, character);
                    Fight5.Print(_enemy5, character);
                    break;
                case 5:
                    _enemy1 = new BigRat(90, 30);
                    _enemy2 = new Goblin(90, 30);
                    _enemy3 = new HumanSourceress(90, 30);
                    _enemy4 = new HalfEatenSkeleton(90, 30);
                    _enemy5 = new RottenZombie(140, 30);
                    Fight1.Print(_enemy1, character);
                    Fight2.Print(_enemy2, character);
                    Fight3.Print(_enemy3, character);
                    Fight4.Print(_enemy4, character);
                    Fight5.Print(_enemy5, character);
                    break;
                default:
                    break;
            }

            health = character.Health;//tarkistetaan hahmon elämäpisteet, jos on saanut itemistä lisää
            character.Health = health; //annetaan elämäpisteet takaisin oikeassa määrässä.
        }//kaikki taistelut lvl2
        protected static bool Alive(Characters character)
        {
            if (character.Health < 0)
            {
                Console.WriteLine("Olet kuollut.\n");
                UI.EnterCheck();
                return false;
            }
            return true;
        }//hahmon elämäpiste check

        protected static bool Alive(Enemies enemy)
        {
            if (enemy.Health < 0)
            {
                return false;
            }
            return true;
        }//vihollisten elämäpiste check
        protected static bool Alive(RottenZombie zombie)
        {
            if (zombie.Health < -50)
            {
                return false;
            }
            return true;
        }//zombien elämäpiste check
        protected static bool CriticalStrike()
        {
            double randomNum = random.NextDouble();
            if (randomNum <= critChance / 100.0) return true;
            else return false;
        }//crit check
    }
}
