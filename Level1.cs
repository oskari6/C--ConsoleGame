
namespace ConsoleApp1
{
    class Level1 : Levels
    {
        internal static void Print(Characters character)
        {
            Console.WriteLine("Vuosi 2283, ihminen on laskeutunut avaruudessa Sopheros planeetalle.");
            Console.WriteLine("Kapteeni Oasis Oskari von Boris ohjaa alusta. Yht'äkkiä alus Jäätyy ja näytöllä tulee viesti:");
            Console.WriteLine("\"Tunkeilija havaittu. Aktivoi puolustusjärjestelmät.\"Kapteeni Oasis oskari sydän pomppailee,");
            Console.WriteLine("kun hän yrittää saada aluksen hallintaan.Hetken päästä aluksen ovet aukeavat itsestään ja kun");
            Console.WriteLine("sisään astuu outo, valohohteinen olento, joka esittelee itsensä nimellä \"Zakum\". Hän ei päästä kapteenia");
            Console.WriteLine("eikä hänen miehistöään planeetalle jos he eivät vastaa oikein seuraaviin kysymyksiin: \n");
            //viive
            Thread ignoreInputThread = new Thread(() => UI.IgnoreUserInput());//voi kommentoida debuggauksessa
            ignoreInputThread.Start();
            Thread.Sleep(5000);

            UI.EnterCheck();
            Console.WriteLine("LEVEL 1\n");
            int correct = 0;
            //tasot vaikeustason mukaan
            switch (character.Difficulty)
            {
                case 1:
                    for(int i = 1; i < Questions.Questions1.Count + 1; i++)
                    {
                        Console.WriteLine(Questions.Questions1[i-1]);
                        Console.WriteLine("Vaihtoehdot: ");
                        Dictionary<string, string> currentAnswers = Answers.AllAnswers[i];
                        foreach (var pair in currentAnswers)
                        {
                            Console.WriteLine($"{pair.Key} {pair.Value}");
                        }
                        string rightAnswer = Answers.CorrectAnswers[i-1];

                        Input.UserInput = Input.GetUserInput("", $"{Color.Apply("Et painanut oikein, yritä uudestaan.", Color.Red)}", 8);
                        
                        Console.Clear();

                        string answer = Input.UserInput switch
                        {
                            'A' or 'a' => answer = "A",
                            'B' or 'b' => answer = "B",
                            'C' or 'c' => answer = "C",
                            'D' or 'd' => answer = "D",
                            _ => throw new InvalidOperationException("UserInput() ei toimi.")
                        };
                        if (answer.Equals(rightAnswer))
                        {
                            correct++;
                        }
                    }
                    break;
                case 2:
                    for (int i = 1; i < Questions.Questions2.Count + 1; i++)
                    {
                        Console.WriteLine(Questions.Questions2[i - 1]);
                        Console.WriteLine("Vaihtoehdot: ");
                        Dictionary<string, string> currentAnswers = Answers.AllAnswers[i+7];
                        foreach (var pair in currentAnswers)
                        {
                            Console.WriteLine($"{pair.Key} {pair.Value}");
                        }
                        string rightAnswer = Answers.CorrectAnswers[i - 1];

                        Input.UserInput = Input.GetUserInput("", $"{Color.Apply("Et painanut oikein, yritä uudestaan.", Color.Red)}", 8);
                        Console.Clear();

                        string answer = Input.UserInput switch
                        {
                            'A' or 'a' => answer = "A",
                            'B' or 'b' => answer = "B",
                            'C' or 'c' => answer = "C",
                            'D' or 'd' => answer = "D",
                            _ => throw new InvalidOperationException("UserInput() ei toimi.")
                        };
                        if (answer.Equals(rightAnswer))
                        {
                            correct++;
                        }
                        Console.Clear();
                    }
                    break;
                case 3:
                    for (int i = 1; i < Questions.Questions3.Count + 1; i++)
                    {
                        Console.WriteLine(Questions.Questions3[i - 1]);
                        Console.WriteLine("Vaihtoehdot: ");
                        Dictionary<string, string> currentAnswers = Answers.AllAnswers[i+14];
                        foreach (var pair in currentAnswers)
                        {
                            Console.WriteLine($"{pair.Key} {pair.Value}");
                        }
                        string rightAnswer = Answers.CorrectAnswers[i - 1];

                        Input.UserInput = Input.GetUserInput("", $"{Color.Apply("Et painanut oikein, yritä uudestaan.", Color.Red)}", 8);
                        Console.Clear();

                        string answer = Input.UserInput switch
                        {
                            'A' or 'a' => answer = "A",
                            'B' or 'b' => answer = "B",
                            'C' or 'c' => answer = "C",
                            'D' or 'd' => answer = "D",
                            _ => throw new InvalidOperationException("UserInput() ei toimi.")
                        };
                        if (answer.Equals(rightAnswer))
                        {
                            correct++;
                        }
                        Console.Clear();
                    }
                    break;
                case 4:
                    for (int i = 1; i < Questions.Questions4.Count + 1; i++)
                    {
                        Console.WriteLine(Questions.Questions4[i - 1]);
                        Console.WriteLine("Vaihtoehdot: ");
                        Dictionary<string, string> currentAnswers = Answers.AllAnswers[i+21];
                        foreach (var pair in currentAnswers)
                        {
                            Console.WriteLine($"{pair.Key} {pair.Value}");
                        }
                        string rightAnswer = Answers.CorrectAnswers[i - 1];

                        Input.UserInput = Input.GetUserInput("", $"{Color.Apply("Et painanut oikein, yritä uudestaan.", Color.Red)}", 8);
                        Console.Clear();

                        string answer = Input.UserInput switch
                        {
                            'A' or 'a' => answer = "A",
                            'B' or 'b' => answer = "B",
                            'C' or 'c' => answer = "C",
                            'D' or 'd' => answer = "D",
                            _ => throw new InvalidOperationException("UserInput() ei toimi.")
                        };
                        if (answer.Equals(rightAnswer))
                        {
                            correct++;
                        }
                        Console.Clear();
                    }
                    break;
                case 5:
                    for (int i = 1; i < Questions.Questions5.Count + 1; i++)
                    {
                        Console.WriteLine(Questions.Questions5[i - 1]);
                        Console.WriteLine("Vaihtoehdot: ");
                        Dictionary<string, string> currentAnswers = Answers.AllAnswers[i+28];
                        foreach (var pair in currentAnswers)
                        {
                            Console.WriteLine($"{pair.Key} {pair.Value}");
                        }
                        string rightAnswer = Answers.CorrectAnswers[i - 1];

                        Input.UserInput = Input.GetUserInput("", $"{Color.Apply("Et painanut oikein, yritä uudestaan.", Color.Red)}", 8);
                        Console.Clear();

                        string answer = Input.UserInput switch
                        {
                            'A' or 'a' => answer = "A",
                            'B' or 'b' => answer = "B",
                            'C' or 'c' => answer = "C",
                            'D' or 'd' => answer = "D",
                            _ => throw new InvalidOperationException("UserInput() ei toimi.")
                        };
                        if (answer.Equals(rightAnswer))
                        {
                            correct++;
                        }
                        Console.Clear();
                    }
                    break;
                default:
                    Console.WriteLine("Level 1 ei toiminut!");
                    break;
            }
            Console.Clear();
            Console.WriteLine($"Oikeat vastaukset: {correct}/7");
            Console.WriteLine($"Pisteesi ovat: {Levels.PointCounter(character.Multiplier, correct)}");
            Items.ItemRandomizer(character);
            UI.EnterCheck();
        }
    }
}
