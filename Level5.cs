
namespace ConsoleApp1
{
    class Level5 : Levels
    {
        private static DragonBoss? _enemy6;
        internal static void Print(Characters character)
        {
            Console.WriteLine("Syvällä metsässä jonne harvat uskaltavat astua, on legendaarinen luola, jota kutsutaan lohikäärmeen Luolaksi.");
            Console.WriteLine("Tarinat kertoivat, että luolassa on valtava lohikäärme joka vartioi kultaista aarretta ja levittää tuhoa");
            Console.WriteLine("jokaiselle joka uskaltavat yrittää päästä sen aarrevarastoon...\n");
            //viive
            Thread ignoreInputThread = new Thread(() => UI.IgnoreUserInput());//voi kommentoida debuggauksessa
            ignoreInputThread.Start();
            Thread.Sleep(5000);

            UI.EnterCheck();
            Console.WriteLine("LEVEL 5\n");
            //tasot vaikeustason mukaan
            switch (character.Difficulty)
            {
                case 1:
                    _enemy6 = new DragonBoss(250, 30);
                    FightBoss.Print(_enemy6, character);
                    break;
                case 2:
                    _enemy6 = new DragonBoss(260, 30);
                    FightBoss.Print(_enemy6, character);
                    break;
                case 3:
                    _enemy6 = new DragonBoss(270, 30);
                    FightBoss.Print(_enemy6, character);
                    break;
                case 4:
                    _enemy6 = new DragonBoss(280, 30);
                    FightBoss.Print(_enemy6, character);
                    break;
                case 5:
                    _enemy6 = new DragonBoss(290, 30);
                    FightBoss.Print(_enemy6, character);
                    break;
                default:
                    break;
            }
            Console.WriteLine($"Kovan taistelun jälkeen olet {Color.Apply("surmannut", Color.Red)} {Color.Apply("Lohikäärmen", Color.Red)}!");
            Console.WriteLine("Te olitte ensimmäiset, jotka suorittivat tämän haasteen. Lohikäärmeen kultainen aarre on nyt teidän! Onnittelut!\n");
            Console.WriteLine($"Pisteesi ovat: {Levels.PointCounter(character.Multiplier, 5)}");
            Console.WriteLine(Color.Apply("Olet päässyt pelin loppuun!", Color.Purple) + "\n");
            UI.EnterCheck();
        }
    }
}
