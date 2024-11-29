
namespace ConsoleApp1
{
    static class Input
    {
        private static char _userInput;//käyttäjä syöte
        internal static char UserInput
        {
            get => _userInput;
            set => _userInput = value;
        }
        internal static char GetUserInput(string prompt, string errorMessage, int version) //syöte check
        {
            switch (version)
            {
                case 0://värit
                    Console.WriteLine(Color.Apply("VALITSE TAUSTAVÄRI\n", Color.Yellow));
                    Console.WriteLine("Tekstin väri muuttuu automaattisesti.\n");
                    Console.WriteLine($"A: {Color.Apply("keltainen", "\u001b[33m"),-45}");
                    Console.WriteLine($"B: {Color.Apply("vihreä", "\u001b[32m"),-45}");
                    Console.WriteLine($"C: {Color.Apply("punainen", "\u001b[31m"),-45}");
                    Console.WriteLine($"D: {Color.Apply("valkoinen", "\u001b[37m"),-45}");
                    Console.WriteLine($"E: {Color.Apply("tumman harmaa", "\u001b[90m"),-45}");
                    Console.WriteLine($"F: {Color.Apply("harmaa", "\u001b[37m"),-45}");
                    Console.WriteLine($"G. {Color.Apply("musta", "\u001b[37m"),-45}\n");
                    Console.Write("Valitse väri: ");

                    while (true)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey();

                        if (keyInfo.KeyChar >= 'A' && keyInfo.KeyChar <= 'G' ||
                            keyInfo.KeyChar >= 'a' && keyInfo.KeyChar <= 'g')
                        {
                            return keyInfo.KeyChar;
                        }
                        else
                        {
                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.WriteLine(errorMessage);
                        }
                    }//värit
                case 1://main menu
                    Console.WriteLine(Color.Apply("TERVETULOA PELIIN\n", Color.Blue));
                    Console.WriteLine($"{"1. ALOITA PELI",-30}");
                    Console.WriteLine($"{"2. POISTU PELISTÄ",-30}");
                    Console.WriteLine($"{"3. HUIPPUTULOKSET",-30}");
                    Console.WriteLine($"{"4. PELAAJAT",-30}\n");
                    Console.Write("Valitse toimintasi: ");

                    while (true)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey();

                        if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.D3 || keyInfo.Key == ConsoleKey.D4)
                        {
                            return keyInfo.KeyChar;
                        }
                        else
                        {
                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.WriteLine(errorMessage);

                        }
                    }//game start(main menu)
                case 2://Enter
                    Console.Write(prompt);
                    while (true)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey();

                        if (keyInfo.Key == ConsoleKey.Enter)
                        {
                            return keyInfo.KeyChar;
                        }
                        else
                        {
                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.WriteLine(errorMessage);
                        }
                    }//enter
                case 3: //Y/n
                    Console.Write(prompt);
                    while (true)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey();

                        if (keyInfo.KeyChar == 'Y' || 
                            keyInfo.KeyChar == 'y' ||
                            keyInfo.KeyChar == 'N' ||
                            keyInfo.KeyChar == 'n')
                        {
                            return keyInfo.KeyChar;
                        }
                        else
                        {
                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.WriteLine(errorMessage);
                        }
                    }//Y/n
                case 4: //custom aseet
                    Console.WriteLine(Color.Apply("CUSTOM ASEET\n", Color.Red));
                    for (int i = 0; i < Items.CustomWeapons.Count; i++)
                    {
                        char weaponIndex = (char)('A' + i);
                        Console.WriteLine($"{weaponIndex}. {Color.Apply(Items.CustomWeapons[i], Color.Red),-21} " +
                            $"| vahinko: {Color.Apply(Items.DamageItems(Characters.CharacterList[0], Items.CustomWeapons[i]) - Characters.CharacterList[0].Damage, Color.Red),-21}");
                    }
                    Console.WriteLine("\n");
                    Console.Write("Valitse aseesi: ");

                    while (true)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey();

                        if (keyInfo.KeyChar >= 'A' && keyInfo.KeyChar <= 'P' ||
                            keyInfo.KeyChar >= 'a' && keyInfo.KeyChar <= 'p')
                        {
                            return keyInfo.KeyChar;
                        }
                        else
                        {
                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.WriteLine(errorMessage);
                        }
                    }//Custom aseet
                case 5: //Hahmo valinta
                    Console.WriteLine(Color.Apply("HAHMOT\n", Color.Blue));
                    Console.WriteLine($"1. {Color.Apply(Characters.Models[0], Color.Blue),-30} | Elämäpisteet: {Color.Apply(500, Color.Green),-30} | Vaikeustaso: {Color.Apply(1, Color.Green),-30}");
                    Console.WriteLine($"2. {Color.Apply(Characters.Models[1], Color.Blue),-30} | Elämäpisteet: {Color.Apply(400, Color.Green),-30} | Vaikeustaso: {Color.Apply(2, Color.Yellow),-30}");
                    Console.WriteLine($"3. {Color.Apply(Characters.Models[2], Color.Blue),-30} | Elämäpisteet: {Color.Apply(300, Color.Green),-30} | Vaikeustaso: {Color.Apply(3, Color.Blue),-30}");
                    Console.WriteLine($"4. {Color.Apply(Characters.Models[3], Color.Blue),-30} | Elämäpisteet: {Color.Apply(200, Color.Green),-30} | Vaikeustaso: {Color.Apply(4, Color.Red),-30}");
                    Console.WriteLine($"5. {Color.Apply(Characters.Models[4], Color.Blue),-30} | Elämäpisteet: {Color.Apply("Custom", Color.Purple),-30} | Vaikeustaso: {Color.Apply("Custom", Color.Purple),-30}");
                    Console.WriteLine("\n");
                    Console.Write("Valitse hahmosi: ");
                    while (true)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey();

                        if (keyInfo.Key == ConsoleKey.D1 ||
                            keyInfo.Key == ConsoleKey.D2 ||
                            keyInfo.Key == ConsoleKey.D3 ||
                            keyInfo.Key == ConsoleKey.D4 ||
                            keyInfo.Key == ConsoleKey.D5)
                        {
                            return keyInfo.KeyChar;
                        }
                        else
                        {
                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.WriteLine(errorMessage);
                        }
                    }//Hahmo valinta
                case 6: //custom hahmo 1-7
                    Console.WriteLine(Color.Apply("CUSTOM HAHMOT\n", Color.Purple));
                    Console.WriteLine($"1. {Color.Apply(Characters.CustomModels[0], Color.Blue),-35}");
                    Console.WriteLine($"2. {Color.Apply(Characters.CustomModels[1], Color.Blue),-35}");
                    Console.WriteLine($"3. {Color.Apply(Characters.CustomModels[2], Color.Blue),-35}");
                    Console.WriteLine($"4. {Color.Apply(Characters.CustomModels[3], Color.Blue),-35}");
                    Console.WriteLine($"5. {Color.Apply(Characters.CustomModels[4], Color.Blue),-35}");
                    Console.WriteLine($"6. {Color.Apply(Characters.CustomModels[5], Color.Blue),-35}");
                    Console.WriteLine($"7. {Color.Apply(Characters.CustomModels[6], Color.Blue),-35}\n");
                    Console.Write("Valitse hahmo: ");

                    while (true)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey();

                        if (keyInfo.Key >= ConsoleKey.D1 && keyInfo.Key <= ConsoleKey.D7)
                        {
                            return keyInfo.KeyChar;
                        }
                        else
                        {
                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.WriteLine(errorMessage);
                        }
                    }//Custom hahmo
                case 7://esc lopetus
                    Console.WriteLine("Haluatko varmasti poistua?");
                    Console.WriteLine(Color.Apply("Kyllä = Enter", Color.Red));
                    Console.WriteLine(Color.Apply("Takaisin = Esc", Color.Green));
                    while (true)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey();

                        if (keyInfo.Key == ConsoleKey.Escape || keyInfo.Key == ConsoleKey.Enter)
                        {
                            return keyInfo.KeyChar;
                        }
                        else
                        {
                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.WriteLine(errorMessage);
                        }
                    }//Esc
                case 8://visa kysymykset
                    Console.WriteLine("\n");
                    Console.Write("Vastauksesi: ");
                    while (true)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey();

                        if (keyInfo.KeyChar == 'A' || keyInfo.KeyChar == 'a' ||
                            keyInfo.KeyChar == 'B' || keyInfo.KeyChar == 'b' ||
                            keyInfo.KeyChar == 'C' || keyInfo.KeyChar == 'c' ||
                            keyInfo.KeyChar == 'D' || keyInfo.KeyChar == 'd')
                        {
                            return keyInfo.KeyChar;
                        }
                        else
                        {
                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.WriteLine(errorMessage);
                        }
                    }//Visa kysymykset
                case 9://game win
                    string items = "";
                    foreach (string item in Characters.CharacterList[0].Collectables)
                    {
                        items += item + ", ";
                    }
                    int bonusPoints = Items.TrinketItems(Characters.CharacterList[0].Collectables);

                    Console.WriteLine("VOITIT PELIN\n");
                    Console.WriteLine($"Nimi: {Users.UserList[0].Name}");
                    Console.WriteLine($"Hahmo: {Color.Apply(Characters.CharacterList[0].Character, Color.Blue)}");
                    Console.WriteLine($"Pisteet: {Levels.Points}");
                    Console.WriteLine($"Sait bonuspisteitä keräilyesineistäsi {Color.Apply(items, Color.Purple)} +{bonusPoints} pistettä!");
                    Console.WriteLine($"Aikaa jäi jäljelle: {Color.Apply(Timer.FormattedTime, Color.Red)}\n");
                    Console.WriteLine("1. PELAA UUDESTAAN");
                    Console.WriteLine("2. POISTU PELISTÄ");
                    Console.WriteLine("3. HUIPPUTULOKSET\n");
                    Console.Write("Valitse toimintasi: ");

                    while (true)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey();

                        if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.D3)
                        {
                            return keyInfo.KeyChar;
                        }
                        else
                        {
                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.WriteLine(errorMessage);
                        }
                    }//Game win
                case 10://game over
                    Console.WriteLine(Color.Apply("HÄVISIT PELIN\n", Color.Red));
                    Console.WriteLine($"Nimi: {Users.UserList[0].Name}");
                    Console.WriteLine($"Hahmo: {Color.Apply(Characters.CharacterList[0].Character, Color.Blue)}");
                    Console.WriteLine($"Pisteet: {Levels.Points}");
                    Console.WriteLine($"Aikaa jäi jäljelle: {Color.Apply(Timer.FormattedTime, Color.Red)}\n");
                    Console.WriteLine("1. PELAA UUDESTAAN");
                    Console.WriteLine("2. POISTU PELISTÄ");
                    Console.WriteLine("3. HUIPPUTULOKSET\n");
                    Console.Write("Valitse toimintasi: ");

                    while (true)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey();

                        if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.D3)
                        {
                            return keyInfo.KeyChar;
                        }
                        else
                        {
                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.WriteLine(errorMessage);
                        }
                    }//Game over
                case 11://weaponchoose()
                    Console.WriteLine(Color.Apply("ASEET\n", Color.Red));
                    Console.WriteLine($"1. {Color.Apply(Items.Weapons[0], Color.Red),-20} | vahinko: {Color.Apply(Items.DamageItems(Characters.CharacterList[0], Items.Weapons[0]) - Characters.CharacterList[0].Damage, Color.Red),-10}");
                    Console.WriteLine($"2. {Color.Apply(Items.Weapons[1], Color.Red),-20} | vahinko: {Color.Apply(Items.DamageItems(Characters.CharacterList[0], Items.Weapons[1]) - Characters.CharacterList[0].Damage, Color.Red),-10}");
                    Console.WriteLine($"3. {Color.Apply(Items.Weapons[2], Color.Red),-20} | vahinko: {Color.Apply(Items.DamageItems(Characters.CharacterList[0], Items.Weapons[2]) - Characters.CharacterList[0].Damage, Color.Red),-10}");
                    Console.WriteLine($"4. {Color.Apply(Items.Weapons[3], Color.Red),-20} | vahinko: {Color.Apply(Items.DamageItems(Characters.CharacterList[0], Items.Weapons[3]) - Characters.CharacterList[0].Damage, Color.Red),-10}");
                    Console.WriteLine($"5. {Color.Apply(Items.Weapons[4], Color.Red),-20} | vahinko: {Color.Apply(Items.DamageItems(Characters.CharacterList[0], Items.Weapons[4]) - Characters.CharacterList[0].Damage, Color.Red),-10}");

                    Console.WriteLine("\n");
                    Console.Write("Valitse toimintasi: ");

                    while (true)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey();

                        if (keyInfo.Key == ConsoleKey.D1 ||
                            keyInfo.Key == ConsoleKey.D2 ||
                            keyInfo.Key == ConsoleKey.D3 ||
                            keyInfo.Key == ConsoleKey.D4 ||
                            keyInfo.Key == ConsoleKey.D5)
                        {
                            return keyInfo.KeyChar;
                        }
                        else
                        {
                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.WriteLine(errorMessage);
                        }
                    }//Weapon choose
                case 12: //custom difficulty
                    Console.WriteLine(prompt);
                    while (true)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey();

                        if (keyInfo.Key == ConsoleKey.D1 ||
                            keyInfo.Key == ConsoleKey.D2 ||
                            keyInfo.Key == ConsoleKey.D3 ||
                            keyInfo.Key == ConsoleKey.D4 ||
                            keyInfo.Key == ConsoleKey.D5)
                        {
                            return keyInfo.KeyChar;
                        }
                        else
                        {
                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.WriteLine(errorMessage);
                        }
                    }//Custom difficulty
                case 13: //weaponrandomizer()
                    Console.WriteLine("\n");
                    Console.WriteLine($"TASON PALKINNOT\n");
                    if (Items.CustomWeapons.Count < 1)
                    {
                        Console.WriteLine($"1. Vahinko: {Color.Apply(Items.Weapons[Items.RandomCustomWeapons], Color.Red)} " +
                    $"| {Color.Apply(Items.DamageItems(Characters.CharacterList[0], Items.Weapons[Items.RandomCustomWeapons]) - Characters.CharacterList[0].Damage, Color.Red)} vahinkoa.");
                    }
                    else
                    {
                        Console.WriteLine($"1. Vahinko: {Color.Apply(Items.CustomWeapons[Items.RandomCustomWeapons], Color.Red)} " +
                        $"| {Color.Apply(Items.DamageItems(Characters.CharacterList[0], Items.CustomWeapons[Items.RandomCustomWeapons]) - Characters.CharacterList[0].Damage, Color.Red)} vahinkoa.");
                    }

                    Console.WriteLine("*********************************************");
                    Console.WriteLine($"2. Elämäpisteet: {Color.Apply(Items.Armors[Items.RandomArmors], Color.Green)} | " +
                        $"+{Color.Apply(Items.HealthItems(Characters.CharacterList[0], Items.Armors[Items.RandomArmors]), Color.Green)} kokonais elämäpisteitä hahmolle.");
                    Console.WriteLine("*********************************************");
                    Console.WriteLine($"3. Keräilyesine: {Color.Apply(Items.Trinkets[Items.RandomTrinkets], Color.Purple)} |+??? {Color.Apply("Mystinen palkinto.", Color.Red)} (ei voi käyttää taistelussa).");
                    Console.WriteLine("*********************************************");
                    if (Items.Spells[Items.RandomSpells].Equals("Parantava Taika")) Console.WriteLine($"4. Loitsu: {Color.Apply(Items.Spells[Items.RandomSpells], Color.Green)} " +
                        $"| + täyteen elämäpisteisiin nosto");
                    else Console.WriteLine($"4. Loitsu: {Color.Apply(Items.Spells[Items.RandomSpells], Color.Blue)} " +
                    $"| +{Color.Apply((Items.SpellItems(Items.Spells[Items.RandomSpells]) * 100).ToString(), Color.Blue)}% mahdollisuuden tappaa vihollinen heti, 1-käyttökerta.");
                    Console.WriteLine("\n");
                    Console.Write("Valitse palkintosi: ");

                    while (true)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey();

                        if (keyInfo.Key == ConsoleKey.D1 ||
                            keyInfo.Key == ConsoleKey.D2 ||
                            keyInfo.Key == ConsoleKey.D3 ||
                            keyInfo.Key == ConsoleKey.D4)
                        {
                            return keyInfo.KeyChar;
                        }
                        else
                        {
                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.WriteLine(errorMessage);
                        }
                    }//Weapon randomizer
                case 14: //ChooseAction()
                    Characters character = Characters.CharacterList[0];
                    Console.WriteLine("\n");
                    Console.WriteLine($"Elämäpisteeesi: {Color.Apply(character.Health, Color.Green)}\n");
                    Console.WriteLine("TAVARASI\n");
                    for (int i = 0; i < character.Inventory.Count; i++)
                    {
                        char weaponIndex = (char)('A' + i);
                        if (character.Inventory[i].Equals("Parantava Taika"))
                        {
                            Console.WriteLine($"{weaponIndex}. Parantava Taika: {Color.Apply(character.Inventory[i], Color.Green)} | + täyteen elämäpisteisiin nosto.");
                            continue;
                        }
                        else if (character.Inventory[i].Equals("Parannus"))
                        {
                            Console.WriteLine($"{weaponIndex}. Normaali parannus: {Color.Apply(character.Inventory[i], Color.Green)} | {Color.Apply("+50", Color.Green)} elämäpistettä.");
                            continue;
                        }
                        else if (Items.Weapons.Contains(character.Inventory[i]) || Items.CustomWeapons.Contains(character.Inventory[i]) || Items.DeletedWeapons.Contains(character.Inventory[i]))
                        {
                            Console.WriteLine($"{weaponIndex}. Vahinko: {Color.Apply(character.Inventory[i], Color.Red), -10} |" +
                                $" {Color.Apply("+", Color.Red)}{Color.Apply(Items.DamageItems(Characters.CharacterList[0], character.Inventory[i]) - Characters.CharacterList[0].Damage, Color.Red)} vahinkoa.");
                            continue;
                        }
                        else if (Items.Spells.Contains(character.Inventory[i]) || Items.DeletedSpells.Contains(character.Inventory[i]))
                        {
                            Console.WriteLine($"{weaponIndex}. Loitsu: {Color.Apply(character.Inventory[i], Color.Blue)} | " +
                                $"{Color.Apply("+", Color.Blue)}{Color.Apply((Items.SpellItems(character.Inventory[i]) * 100).ToString(), Color.Blue)}% mahdollisuuden tappaa vihollinen heti, 1-käyttökerta.");

                            continue;
                        }
                    }
                    Console.WriteLine("\n");
                    Console.Write("Valitse toimintasi: ");

                    while (true)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey();

                        if (keyInfo.KeyChar >= 'A' && keyInfo.KeyChar <= 'U' ||
                            keyInfo.KeyChar >= 'a' && keyInfo.KeyChar <= 'u')
                        {
                            return keyInfo.KeyChar;
                        }
                        else
                        {
                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.WriteLine(errorMessage);
                        }
                    }//Choose action()
                case 15://Boss fight
                    Console.WriteLine(prompt);
                    int times = 0;
                    while (true)
                    {
                        if(times <= 5) Console.WriteLine($"{Color.Apply("Sammuta itsesi!, paina ENTER vielä ", Color.Red)}{Color.Apply(times, Color.Red)}{Color.Apply("-kertaa!!!", Color.Red)}");
                        if (times > 5 && times <= 10) Console.WriteLine($"{Color.Apply("Sammuta itsesi!, paina ENTER vielä ", Color.Yellow)}{Color.Apply(times, Color.Yellow)}{Color.Apply("-kertaa!!!", Color.Yellow)}");
                        if (times > 10 && times <= 15) Console.WriteLine($"{Color.Apply("Sammuta itsesi!, paina ENTER vielä ", Color.Green)}{Color.Apply(times, Color.Green)}{Color.Apply("-kertaa!!!", Color.Green)}");
                        if (times > 15 && times <= 20) Console.WriteLine($"{Color.Apply("Sammuta itsesi!, paina ENTER vielä ", Color.Blue)}{Color.Apply(times, Color.Blue)}{Color.Apply("-kertaa!!!", Color.Blue)}");

                        ConsoleKeyInfo keyInfo = Console.ReadKey();
                        Console.Clear();
                        if (keyInfo.Key == ConsoleKey.Enter)
                        {
                            times++;

                            if(times == 20)
                            {
                                return keyInfo.KeyChar;
                            }
                            continue;
                        }
                        else
                        {
                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.WriteLine(errorMessage);
                        }
                    }//Boss fight
                default:
                    Console.WriteLine("Väärä GetUserInput() versio.");
                    return '\0';
            }
        }
    }
}
