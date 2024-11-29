
namespace ConsoleApp1
{
    class Level2 : Levels
    {
        public static void Print(Characters character)
        {
            Console.WriteLine("Kapteeni Oasis Oaskari Von Boris ja hänen miehistönsä suorittivat kysymykset, mutta se ei riitä Zakumille.");
            Console.WriteLine("Päästäkseen eteenpäin heidän tulisi voittaa planeetan pahimmat vastustajansa, jotka ovat:");
            Console.WriteLine("Iso Rotta, Peikko, Velho, Puoliksi syöty luuranko ja Pahimpana vielä Zombi.");
            Console.WriteLine("Nämä vihamieliset olennot on planeetan kovimmat taistelijat.");
            Console.WriteLine("Kukaan ei ole vielä päihittänyt heitä.");
            Console.WriteLine("\n");
            //viive
            Thread ignoreInputThread = new Thread(() => UI.IgnoreUserInput());//voi kommentoida debuggauksessa
            ignoreInputThread.Start();
            Thread.Sleep(5000);

            UI.EnterCheck();
            Console.WriteLine("LEVEL 2\n");
            //tasot vaikeustason mukaan
            switch (character.Difficulty)
            {
                case 1:
                    Fights.FullFight(character, character.Difficulty);
                    break;
                case 2:
                    Fights.FullFight(character, character.Difficulty);
                    break;
                case 3:
                    Fights.FullFight(character, character.Difficulty);
                    break;
                case 4:
                    Fights.FullFight(character, character.Difficulty);
                    break;
                case 5:
                    Fights.FullFight(character, character.Difficulty);
                    break;
                default:
                    break;
            }

            Console.WriteLine($"kaikki viholliset on {Color.Apply("surmattu", Color.Red)}");
            Console.WriteLine($"Pisteesi ovat: {Levels.PointCounter(character.Multiplier)}");
            Items.ItemRandomizer(character);
            UI.EnterCheck();
        }
    }
}
