
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1
{
    class Level4 : Levels
    {
        public static void Print(Characters character)
        {
            Console.WriteLine("Tämä taso on hankalin. Läbyrintin lopun kammiosta löytyy jonkinlainen pulmapeli.");
            Console.WriteLine("Tutkimisen jälkeen käy ilmi, että pulmaan täytyy kaivertaa oikea sana, jotta aarrekammio avautuisi.");
            Console.WriteLine("Kapteenin on mentävä hirsipuulle ja miehistön on arvattava oikea sana");
            Console.WriteLine("taas jos haluatte eteenpäin tai kapteenista tulee jojon jatke.\n");
            //viive
            Thread ignoreInputThread = new Thread(() => UI.IgnoreUserInput());//voi kommentoida debuggauksessa
            ignoreInputThread.Start();
            Thread.Sleep(5000);

            UI.EnterCheck();
            Console.WriteLine("LEVEL 4\n");
            //tasot vaikeustason mukaan
            switch (character.Difficulty)
            {
                case 1:
                    HangMan.GameStart(1);
                    break;
                case 2:
                    HangMan.GameStart(2);
                    break;
                case 3:
                    HangMan.GameStart(3);
                    break;
                case 4:
                    HangMan.GameStart(4);
                    break;
                case 5:
                    HangMan.GameStart(5);
                    break;
                default:
                    break;
            }

            Console.WriteLine($"Kaikki {Color.Apply("hirsipuut", Color.Red)} ovat suoritettu");
            Console.WriteLine($"Sait oikein {HangMan.Correct} / 5 sanasta.");
            Console.WriteLine($"Pisteesi ovat: {Levels.PointCounter(character.Multiplier, HangMan.Correct)}");
            Items.ItemRandomizer(character);
            UI.EnterCheck();
        }
    }
}
