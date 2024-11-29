namespace ConsoleApp1
{
    class UI
    {
        private static List<(int key, int highscore, string value)> _results = new List<(int, int, string)>(); //huipputulos tulostus
        private static readonly string _path = Directory.GetCurrentDirectory() + @"\highscores.txt";//huipputulokset 

        internal static List<(int key, int highscore, string value)> Results => _results; //huipputulos tulostus

        internal static void GameLoop()
        {   //nollaus
            Console.Clear();
            Characters.CharacterList.Clear();
            Users.UserList.Clear();
            Levels.Points = 0;
            GameStart();

            Timer.SetTimer(Characters.CharacterList[0].Difficulty);
            for (int levelNumber = 1; levelNumber <= 5; levelNumber++)
            {
                Timer.PrintRemainingTime();

                switch (levelNumber)
                {
                    case 1:
                        Level1.Print(Characters.CharacterList[0]);
                        break;
                    case 2:
                        Level2.Print(Characters.CharacterList[0]);
                        break;
                    case 3:
                        Level3.Print(Characters.CharacterList[0]);
                        break;
                    case 4:
                        Level4.Print(Characters.CharacterList[0]);
                        break;
                    case 5:
                        Level5.Print(Characters.CharacterList[0]);
                        break;
                }

                if (Timer.GetRemainingTimeInSeconds() <= 0)
                {
                    GameOver(Users.UserList[0], Characters.CharacterList[0]);
                    return;
                }
            }
            GameWinner(Users.UserList[0], Characters.CharacterList[0]);
        }//pelin pyöritys
        internal static void GameStart()
        {
            Input.UserInput = Input.GetUserInput("", $"{Color.Apply("Et painanut oikein, paina 1-4.", Color.Red)}", 1);
            Console.Clear();

            switch (Input.UserInput)
            {
                case '1':
                    Console.Clear();
                    Users user = Users.UserNames();
                    Users.UserList.Add(user);
                    ConsoleBackground();//värit tausta
                    Characters.CharacterChoose(user);//hahmon valinta
                    break;
                case '2':
                    GameExit();
                    break;
                case '3':
                    Results.Clear();
                    HighscoreGet(false);
                    Console.WriteLine("\n");
                    EnterCheck();
                    GameLoop();
                    break;
                case '4':
                    Users.GetUser();
                    Console.WriteLine("\n");
                    break;
                default:
                    Console.WriteLine("UserInput() ei toimi.");
                    break;
            }
        }//aloitus ruutu
        protected static void GameStartInfo(Users user, Characters character)
        {
            Console.WriteLine("*********************************************************************************************************");
            Console.WriteLine("*********************************************************************************************************");
            Console.WriteLine();
            Console.WriteLine(Color.Apply("PELI ALKAA\n", Color.Blue));
            Console.WriteLine();
            Console.WriteLine($"Pelaaja: {user.Name,-10}");
            Console.WriteLine($"Hahmo: {Color.Apply(character.Character, Color.Blue),-20}");
            Console.WriteLine($"Aloitusase: {Color.Apply(character.Inventory[1], Color.Red),-20}");
            Console.WriteLine($"Vaikeustaso: {Color.Apply(character.Difficulty, Color.Green),-20}");
            Console.WriteLine($"Vahinko: {Color.Apply(character.Damage, Color.Red),-20}");
            Console.WriteLine($"Elämäpisteet: {Color.Apply(character.Health, Color.Green),-20}");

            Console.WriteLine("\n");
            Results.Clear();
            HighscoreGet(true); ;
            Console.WriteLine("\n");
            Console.WriteLine("*********************************************************************************************************");
            Console.WriteLine("*********************************************************************************************************\n");
            Thread ignoreInputThread = new Thread(() => IgnoreUserInput());
            ignoreInputThread.Start();
            Thread.Sleep(5000);
            EnterCheck();
        }//kooste ennen peliä
        static void GameWinner(Users user, Characters character)
        {
            Console.Clear();
            Timer.StopTimer();

            Timer.RemainingTime = Timer.GetRemainingTimeInSeconds();//mitä jäi jäljelle
            Timer.TimeSpan = TimeSpan.FromSeconds(Timer.RemainingTime);//mitä jäi jäljelle
            Timer.PlayingTimeSeconds = Timer.TotalTime - Timer.RemainingTime;//peliaika
            Timer.TimeSpanGame = TimeSpan.FromSeconds(Timer.PlayingTimeSeconds);//peliaka

            Timer.FormattedPlayingTime = $"{(int)Timer.TimeSpanGame.TotalMinutes}:{Timer.TimeSpanGame.Seconds:00}";//peli aika
            Timer.FormattedTime = $"{(int)Timer.TimeSpan.TotalMinutes}:{Timer.TimeSpan.Seconds:00}";//paljonko jäi aikaa jäljelle

            Levels.PointCounter(Timer.RemainingTime, Items.TrinketItems(character.Collectables));

            HighScoreSet(user, character);

            Input.UserInput = Input.GetUserInput("", $"{Color.Apply("Et painanut oikein, paina 1-3.", Color.Red)}", 9);
            character.Inventory.Clear();
            character.Collectables.Clear();
            Items.DeletedWeapons.Clear();
            Items.DeletedSpells.Clear();

            switch (Input.UserInput)
            {
                case '1':
                    GameLoop();
                    break;
                case '2':
                    GameExit();
                    break;
                case '3':
                    Results.Clear();
                    HighscoreGet(false);
                    Console.WriteLine("\n");
                    EnterCheck();
                    GameLoop();
                    break;
                default:
                    Console.WriteLine("UserInput() ei toimi.");
                    break;
            }
            Console.Clear();
            //todo onnittelut
        }//voitto ruutu
        internal static void GameOver(Users user, Characters character)
        {
            Console.Clear();
            Timer.StopTimer();
            Timer.RemainingTime = Timer.GetRemainingTimeInSeconds();
            Timer.TimeSpan = TimeSpan.FromSeconds(Timer.RemainingTime);
            Timer.FormattedTime = $"{(int)Timer.TimeSpan.TotalMinutes}:{Timer.TimeSpan.Seconds:00}";

            Levels.PointCounter(Timer.RemainingTime, Items.TrinketItems(character.Collectables));
            character.Inventory.Clear();
            character.Collectables.Clear();

            Input.UserInput = Input.GetUserInput("", $"{Color.Apply("Et painanut oikein, paina 1-3.", Color.Red)}", 10);

            switch (Input.UserInput)
            {
                case '1':
                    GameLoop();
                    break;
                case '2':
                    GameExit();
                    break;
                case '3':
                    Results.Clear();
                    HighscoreGet(false);
                    Console.WriteLine("\n");
                    EnterCheck();
                    GameLoop();
                    break;
                default:
                    Console.WriteLine("UserInput() ei toimi.");
                    break;
            }
            Console.Clear();
        }//häviö ruutu
        internal static void GameExit()
        {
            Console.Clear();
            Input.UserInput = Input.GetUserInput("", "\r", 7);

            switch (Input.UserInput)
            {
                case '\r':
                    Console.WriteLine("Poistuit pelistä..");
                    Environment.Exit(0);
                    break; ;
                case '\x1B':
                    Console.Clear();
                    GameStart();
                    break;
                default:
                    Console.WriteLine("UserInput() ei toimi.");
                    break;
            }
        }//poistumis ruutu
        static void HighscoreGet(bool ingame)
        {
            Console.WriteLine("HUIPPUTULOKSET\n");
            int highscore;
            int key;
            if (ingame)//kertaus ennen pelin alkua
            {

                if (!File.Exists(_path) || File.ReadAllLines(_path).Length == 0)
                {
                    Console.WriteLine("Huipputuloksia ei ole vielä...");
                    return;
                }
                else
                {
                    using (StreamReader sr = File.OpenText(_path))
                    {
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] myArray = line.Trim().Split(";");
                            try
                            {
                                key = int.Parse(myArray[0]);
                                highscore = int.Parse(myArray[6]);
                                string value = $"{myArray[1]} | {myArray[2]} | Pisteet: {highscore}";
                                Results.Add((key, highscore, value));
                            }
                            catch (FileNotFoundException)
                            {
                                Console.WriteLine("Virhe tuloksia hakiessa");
                                break;
                            }
                        }
                    }
                    var topResults = Results.OrderByDescending(entry => entry.highscore).Take(5);

                    //top 5
                    foreach (var result in topResults)
                    {
                        Console.WriteLine(result.value);
                    }
                }
            }
            if (!ingame)
            {
                Console.Clear();

                if (!File.Exists(_path) || File.ReadAllLines(_path).Length == 0)
                {
                    Console.WriteLine("Huipputuloksia ei ole vielä...");
                }
                
                else
                {
                    using (StreamReader sr = File.OpenText(_path))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] myArray = line.Split(";");
                            try
                            {
                                key = int.Parse(myArray[0]);
                                highscore = int.Parse(myArray[6]);
                                string value = $"{myArray[1]} | {myArray[2]} | Hahmo: {myArray[3]} | Vaikeustaso: {myArray[4]} | Aika: {myArray[5]} | Pisteet: {highscore}";
                                Results.Add((key, highscore, value));
                            }
                            catch (FileNotFoundException)
                            {
                                Console.WriteLine("Virhe tuloksia hakiessa");
                                break;
                            }
                        }
                    }
                    var topResults = Results.OrderByDescending(entry => entry.highscore).Take(5);

                    //top 5
                    foreach (var result in topResults)
                    {
                        Console.WriteLine(result.value);
                    }
                }
            }
        }//huipputuloslista r
        static void HighScoreSet(Users user, Characters character)
        {
            int highscore = Levels.Points;
            int rowCount = 0;

            try
            {
                using (StreamReader sr = File.OpenText(_path))
                {
                    while (sr.ReadLine() != null)
                    {
                        rowCount++;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }

            using (StreamWriter sw = File.AppendText(_path))
            {
                sw.Write($"{rowCount};{user.Abbreviation};{user.Name};{character.Character};{character.Difficulty};{Timer.FormattedPlayingTime};{highscore}\n");
            }
        }//huipputuloslista w
        static void ConsoleBackground()
        {
            //käyttöliittymän taustaväri
            while (true)
            {
                Input.UserInput = Input.GetUserInput("", $"{Color.Apply("Et painanut oikein, paina A-G.", Color.Red)}", 0);

                ConsoleColor color = Input.UserInput switch
                {
                    'A' or 'a' => ConsoleColor.Yellow,
                    'B' or 'b' => ConsoleColor.Green,
                    'C' or 'c' => ConsoleColor.Red,
                    'D' or 'd' => ConsoleColor.White,
                    'E' or 'e' => ConsoleColor.DarkGray,
                    'F' or 'f' => ConsoleColor.Gray,
                    'G' or 'g' => ConsoleColor.Black,
                    _ => throw new InvalidOperationException("UserInput() ei toimi")
                };
                Console.BackgroundColor = color;

                switch (color)
                {
                    case ConsoleColor.Red:
                    case ConsoleColor.DarkGray:
                    case ConsoleColor.Black:
                        Console.ForegroundColor = ConsoleColor.White;
                        Color.Def = "\u001b[37m";    //d == defaultColor, tulostus
                        break;
                    case ConsoleColor.White:
                    case ConsoleColor.Yellow:
                    case ConsoleColor.Gray:
                    case ConsoleColor.Green:
                        Console.ForegroundColor = ConsoleColor.Black;
                        Color.Def = "\u001b[30m";   //d == defaultColor, tulostus
                        break;
                    default:
                        break;

                }
                Console.Clear();
                Console.WriteLine(Color.Apply("ESIMERKKI TULOSTUS 12345", Color.Red));
                Console.WriteLine(Color.Apply("ESIMERKKI TULOSTUS 12345", Color.Yellow));
                Console.WriteLine(Color.Apply("ESIMERKKI TULOSTUS 12345", Color.Blue));
                Console.WriteLine(Color.Apply("ESIMERKKI TULOSTUS 12345", Color.Green));
                Console.WriteLine(Color.Apply("ESIMERKKI TULOSTUS 12345", Color.Purple));
                Console.WriteLine("\n");

                Input.UserInput = Input.GetUserInput($"Pidetäänkö väri? (Y/n)", $"{Color.Apply("Et painanut oikein", Color.Red)}, paina (Y/n).", 3);

                switch (Input.UserInput)
                {
                    case 'Y':
                    case 'y':
                        Console.Clear();
                        return;
                    case 'N':
                    case 'n':
                        Console.Clear();
                        continue;
                    default:
                        Console.WriteLine("UserInput() ei toimi.");
                        break;
                }
            }
        }//taustaväri ruutu
        internal static void EnterCheck()
        {
            char UserInput = Input.GetUserInput("Paina ENTER jatkaaksesi: ", $"{Color.Apply("Et painanut ENTER näppäintä, yritä uudestaan.", Color.Red)}", 2);

            switch (UserInput)
            {
                case '\r':
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("EnterCheck() ei toimi.");
                    Console.Clear();
                    break;
            }
        }//enter syöte check
        internal static void IgnoreUserInput(int durationMilliseconds = 5000)
        {
            DateTime endTime = DateTime.Now.AddMilliseconds(durationMilliseconds);

            while (DateTime.Now < endTime)
            {
                if (Console.KeyAvailable)
                {
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }
                }
            }
        }//siirtymät
    }
}