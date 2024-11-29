
namespace ConsoleApp1
{
    static class Maze
    {
        private static readonly string _path = Directory.GetCurrentDirectory() + @"\mazes.txt";//labyrintit
        internal static List<Structure> MazeReader()
        {
            //0 = wall
            //1 = path
            //2 = destination

            List<Structure> mazes = new List<Structure>();

            using (StreamReader sr = File.OpenText(_path))
            {
                while (!sr.EndOfStream)
                {
                    Structure m = new Structure();
                    int rows = int.Parse(sr.ReadLine() ?? "0"); //ongelma
                    m.Maze = new int[rows][];

                    for (int i = 0; i < rows; i++)
                    {
                        string line = sr.ReadLine() ?? "0";
                        m.Maze[i] = line.Split(", ").Select(int.Parse).ToArray();
                    }

                    int startPosY = int.Parse(sr.ReadLine() ?? "0");
                    int startPosX = int.Parse(sr.ReadLine() ?? "0");
                    m.Start = new Position(startPosY, startPosX);

                    sr.ReadLine(); //- poisto

                    mazes.Add(m);
                }
            }
            return mazes;
        }//tiedoston lukija
        internal static void MazeStart(Structure m)
        {
            if (m.Start == null)
            {
                m.Start = new Position(0, 0);
            }
            Position p = m.Start;
            m.Path.AddFirst(p);

            Console.WriteLine("Voit liikkua ylös, alas, oikealle tai vasemmalle");
            Console.WriteLine("Anna liikkumis komento nuolilla");

            if (m.Maze == null)
            {
                m.Maze = new int[0][];
            }

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                int y = m.Path.First().Y;
                int x = m.Path.First().X;

                //ylös
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (isValid(y - 1, x, m))
                    {
                        if (m.Maze[y - 1][x] == 2)
                        {
                            Console.WriteLine("Liikuit ylös");
                            Console.WriteLine($"{Color.Apply("Voitit", Color.Green)}, löysit {Color.Apply("aarteen!", Color.Yellow)}" );
                            UI.EnterCheck();
                            break;
                        }
                        else if (m.Maze[y - 1][x] == 1)
                        {
                            Console.WriteLine("Liikuit ylös");
                            m.Path.AddFirst(new Position(y - 1, x));
                            m.Maze[y - 1][x] = 1;
                            continue;
                        }
                    }

                }
                //alas
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (isValid(y + 1, x, m))
                    {
                        if (m.Maze[y + 1][x] == 2)
                        {
                            Console.WriteLine("Liikuit alas");
                            Console.WriteLine($"{Color.Apply("Voitit", Color.Green)}, löysit {Color.Apply("aarteen!", Color.Yellow)}");
                            UI.EnterCheck();
                            break;

                        }
                        else if (m.Maze[y + 1][x] == 1)
                        {
                            Console.WriteLine("Liikuit alas");
                            m.Path.AddFirst(new Position(y + 1, x));
                            m.Maze[y + 1][x] = 1;
                            continue;

                        }

                    }
                }
                //vasen
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    if (isValid(y, x - 1, m))
                    {
                        if (m.Maze[y][x - 1] == 2)
                        {
                            Console.WriteLine("Liikuit vasemmalle");
                            Console.WriteLine($"{Color.Apply("Voitit", Color.Green)}, löysit {Color.Apply("aarteen!", Color.Yellow)}");
                            UI.EnterCheck();
                            break;

                        }
                        else if (m.Maze[y][x - 1] == 1)
                        {
                            Console.WriteLine("Liikuit vasemmalle");
                            m.Path.AddFirst(new Position(y, x - 1));
                            m.Maze[y][x - 1] = 1;
                            continue;
                        }

                    }

                }
                //oikea
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    if (isValid(y, x + 1, m))
                    {
                        if (m.Maze[y][x + 1] == 2)
                        {
                            Console.WriteLine("Liikuit oikealle");
                            Console.WriteLine($"{Color.Apply("Voitit", Color.Green)}, löysit {Color.Apply("aarteen!", Color.Yellow)}");
                            UI.EnterCheck();
                            break;
                        }
                        else if (m.Maze[y][x + 1] == 1)
                        {
                            Console.WriteLine("Liikuit oikealle");
                            m.Path.AddFirst(new Position(y, x + 1));
                            m.Maze[y][x + 1] = 1;
                            continue;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Et painanut nuoli näppäimiä, paina mitä vain jatkaaksesi..");
                    Console.ReadKey();
                    continue;
                }
            }
        }//peli
        internal static bool isValid(int y, int x, Structure m)
        {
            if (m.Maze == null)
            {
                m.Maze = new int[0][];
            }

            if (y < 0 || y >= m.Maze.Length ||
               x < 0 || x >= m.Maze[y].Length)
            {
                return false;
            }
            return true;
        }//onko seinä vai ei
    }
    class Position
    {
        internal int X { get; set; }
        internal int Y { get; set; }

        internal Position(int y, int x)
        {
            this.Y = y;
            this.X = x;
        }
    }//pelaajan sijainti
    class Structure
    {
        internal int[][]? Maze { get; set; }
        internal LinkedList<Position> Path = new LinkedList<Position>();
        internal Position? Start { get; set; }
    }//labyrintin rakenne
}
