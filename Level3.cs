
namespace ConsoleApp1
{
    class Level3 : Levels
    
    {
        public static void Print(Characters character)
        {
            Console.WriteLine("Kauan sitten vuorten käytköissä, on läbyrintti nimeltä Minotauruksen silmukka.");
            Console.WriteLine("Vain harvat ovat pystyneet menemään sen läpi. Elävänä.");
            Console.WriteLine("Onko teistä navigoimaan koko läbyrintin läpi? Tämä vaatii hieman muistia.Varokaa ettette eksy!");
            Console.WriteLine("Teidän tulee päästä labyrintti läpi jotta pääsisitte eteenpäin tai olette läbyrintin vankeja ikuisesti!!\n");
            //viive
            Thread ignoreInputThread = new Thread(() => UI.IgnoreUserInput());//voi kommentoida debuggauksessa
            ignoreInputThread.Start();
            Thread.Sleep(5000);

            UI.EnterCheck();
            Console.WriteLine("LEVEL 3\n");
            Console.WriteLine($"Olet {Color.Apply("labyrintissa", Color.Green)}, sinun pitää löytää reitti {Color.Apply("aarteelle", Color.Yellow)}");

            List<Structure> mazes = Maze.MazeReader();//labyrintit
            //tasot vaikeustason mukaan
            switch (character.Difficulty)
            {
                case 1:
                    Console.WriteLine($"Aloitat vasemmasta yläkulmasta, {Color.Apply("labyrintti", Color.Green)} on 4x4");
                    Maze.MazeStart(mazes[0]);
                    break;
                case 2:
                    Console.WriteLine($"Aloitat vasemmasta yläkulmasta, {Color.Apply("labyrintti", Color.Green)} on 5x5");
                    Maze.MazeStart(mazes[1]);
                    break;
                case 3:
                    Console.WriteLine($"Aloitat vasemmasta yläkulmasta, {Color.Apply("labyrintti", Color.Green)} on 6x6");
                    Maze.MazeStart(mazes[2]);
                    break;
                case 4:
                    Console.WriteLine($"Aloitat vasemmasta yläkulmasta, {Color.Apply("labyrintti", Color.Green)} on 6x6");
                    Maze.MazeStart(mazes[3]);
                    break;
                case 5:
                    Console.WriteLine($"Aloitat vasemmasta yläkulmasta, {Color.Apply("labyrintti", Color.Green)} on 7x7");
                    Maze.MazeStart(mazes[4]);
                    break;
                default:
                    break;
            }

            Console.WriteLine($"{Color.Apply("Labyrintti", Color.Green)} on suoritettu");
            Console.WriteLine($"Pisteesi ovat: {Levels.PointCounter(character.Multiplier)}");
            Items.ItemRandomizer(character);
            UI.EnterCheck();
        }
    }
}
