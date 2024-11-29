using System.Text;
namespace ConsoleApp1
{
    static class HangMan
    {   //arvattavat sanat
        private static string[] _words1 = new string[] { "avaruus", "jupiter", "raketti", "alien", "olio", "matkustaa", "tuhota" };
        private static string[] _words2 = new string[] { "lasersäde", "androidi", "valovuosi", "telekineesi", "telepatia" };
        private static string[] _words3 = new string[] { "tekoäly", "ulottuvuus", "fabrikaatio", "magneettikenttä", "robotti" };
        private static string[] _words4 = new string[] { "penumbra", "quasar", "galaksi", "teleportaatio", "bioteknologia", "nanoteknologia" };
        private static string[] _words5 = new string[] { "kyberneettinen", "kuiperin vyöhyke", "kvanttifysiikka", "supertietokone" };

        private static int _correct = 0;//oikein menneet
        internal static int Correct
        {
            get => _correct;
            set => _correct = value;
        }
        private static Random _random = new Random();
        internal static void GameStart(int difficulty)
        {
            int rotation = 0;

            while (true)
            {
                bool rightWord = false;
                string randomWord;
                int randomNum;

                switch (difficulty)//vaikeustason mukaan sanat
                {
                    case 1:
                        randomNum = _random.Next(_words1.Length);
                        randomWord = _words1[randomNum];
                        _words1 = _words1.Where((source, index) => index != randomNum).ToArray(); //Käytetyn sanan poisto
                        break;
                    case 2:
                        randomNum = _random.Next(_words2.Length);
                        randomWord = _words2[randomNum];
                        _words2 = _words2.Where((source, index) => index != randomNum).ToArray(); //Käytetyn sanan poisto
                        break;
                    case 3:
                        randomNum = _random.Next(_words3.Length);
                        randomWord = _words3[randomNum];
                        _words3 = _words3.Where((source, index) => index != randomNum).ToArray(); //Käytetyn sanan poisto
                        break;
                    case 4:
                        randomNum = _random.Next(_words4.Length);
                        randomWord = _words4[randomNum];
                        _words4 = _words4.Where((source, index) => index != randomNum).ToArray(); //Käytetyn sanan poisto
                        break;
                    case 5:
                        randomNum = _random.Next(_words5.Length);
                        randomWord = _words5[randomNum];
                        _words5 = _words5.Where((source, index) => index != randomNum).ToArray(); //Käytetyn sanan poisto
                        break;
                    default:
                       randomWord = "";
                        break;
                }
                //kierros
                string hiddenWord = "";
                for (int i = 0; i < randomWord.Length; i++)
                {
                    hiddenWord += "_";
                }
                for (int i = 0; i < 13; i++)
                {
                    Console.WriteLine($"Kierros: {rotation + 1}/5");
                    Console.WriteLine($"Sana liittyy aihe alueeseen: {Color.Apply("Scifi", Color.Blue)}");
                    Console.WriteLine($"Vaikeustaso: {Color.Apply(difficulty, Color.Red)}");
                    Console.WriteLine($"Arvattavan sanan pituus: {randomWord.Length}");
                    Console.WriteLine("Sana: " + hiddenWord);
                    Console.WriteLine("Sinulla on " + (13 - i) + " arvausta jäljellä");
                    Console.Write("Yritä arvata sana tai kirjain: ");
                    string guess = Console.ReadLine() ?? "0";

                    if (guess.Length > 1 || guess == "")
                    {
                        if (guess == randomWord)
                        {
                            Console.WriteLine($"Voitit pelin arvasit oikean sanan {Color.Apply(randomWord, Color.Green)}\n");
                            UI.EnterCheck();
                            Correct++;
                            rightWord = true;
                            break;
                        }
                        if (hiddenWord.Equals(randomWord))
                        {
                            Console.WriteLine($"Voitit pelin arvasit oikean sanan {Color.Apply(randomWord, Color.Green)}\n");
                            UI.EnterCheck();
                            Correct++;
                            rightWord = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Arvauksesi oli {Color.Apply("väärin", Color.Red)}\n");
                            UI.EnterCheck();
                            continue;
                        }
                    }
                    else
                    {
                        int count = 0;
                        for (int j = 0; j < randomWord.Length; j++)
                        {
                            char guessChar = char.Parse(guess);
                            int index = randomWord.IndexOf(guess);
                            StringBuilder sb = new StringBuilder(hiddenWord);

                            while (index != -1)
                            {
                                sb[index] = guessChar;
                                index = randomWord.IndexOf(guess, index + 1);
                            }

                            hiddenWord = sb.ToString();
                            count++;
                            i = i - count / randomWord.Length;
                            Console.Clear();
                        }
                        if (hiddenWord == randomWord)
                        {
                            Console.WriteLine($"Voitit pelin arvasit oikean sanan {Color.Apply(randomWord, Color.Green)}\n");
                            UI.EnterCheck();
                            Correct++;
                            rightWord = true;
                            break;
                        }

                        if (!randomWord.Contains(guess))
                        {
                            Console.WriteLine(Color.Apply("Ei sisällä", Color.Red) + "\n");
                            UI.EnterCheck();
                            i++;
                        }
                    }
                }
                if (!rightWord)
                {
                    Console.Clear();
                    Console.WriteLine("Ikävä kyllä et arvannut sanaa etkä saa pisteitä tältä kierrokselta\n");
                    UI.EnterCheck();
                }
                rotation++;

                if(rotation == 5)
                {
                    Console.Clear();
                    break;
                }//poistuminen
            }
        }//peli
    }
}
