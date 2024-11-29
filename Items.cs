
namespace ConsoleApp1
{
    static class Items
    {   //kaikki aseet + deleted listat on organisointia ja toimivuutta varten
        private static List<string> _weapons = new List<string>() { "Miekka", "Jousipyssy", "Sauva", "Keihäs", "Kirves", "Pistooli" };
        private static List<string> _customWeapons = new List<string>() {
            "Soihtu", "Sirppi", "Kynnet", "Kirves", "Harppuuna", "Kävelykeppi", "Sinko", "Atomi Pommi", "Katapultti", "AK-47", "Vesipyssy", "Linko", "Pumerangi", "Liekinheitin", "Haulikko", "Ritsa" };
        private static List<string> _deletedWeapons = new List<string>();
        private static List<string> _deletedSpells = new List<string>();
        //loput itemit
        private static List<string> _armors = new List<string>() { "Nahka haarniska", "Teräs kypärä", "Alumiini saappaat", "Muovi hanskat", "Kulta hartijasuojat" };
        private static List<string> _trinkets = new List<string>() { "Kaulakoru", "Uraani", "Timantti" ,"Meteoriitti", "CPU" };
        private static List<string> _spells = new List<string>() { "Tulipallo", "Jääpallo", "Ketju Salama", "Jää Nova", "Jää Myrsky", "Parantava Taika" };
        private static List<string> _humanSpells = new List<string>() { "Tulipallo", "Jääpallo", "Ketju Salama", "Jää Nova", "Jää Myrsky", "Parantava Taika" };
        
        internal static List<string> Weapons => _customWeapons;
        internal static List<string> CustomWeapons => _customWeapons;
        internal static List<string> DeletedWeapons
        {
            get => _deletedWeapons;
            set => _deletedWeapons = value;
        }
        internal static List<string> DeletedSpells
        {
            get => _deletedSpells;
            set => _deletedSpells = value;
        }

        internal static List<string> Armors => _armors;
        internal static List<string> Trinkets => _trinkets;
        internal static List<string> Spells => _spells;
        internal static List<string> HumanSpells => _humanSpells;
        //random tavaroita varten
        private static int _randomCustomWeapons;
        private static int _randomArmors;
        private static int _randomTrinkets;
        private static int _randomSpells;
        private static Random _randomItem = new Random();

        internal static int RandomCustomWeapons
        {
            get => _randomCustomWeapons;
            set => _randomCustomWeapons = value;
        }
        internal static int RandomArmors
        {
            get => _randomArmors;
            set => _randomArmors = value;
        }
        internal static int RandomTrinkets
        {
            get => _randomTrinkets;
            set => _randomTrinkets = value;
        }
        internal static int RandomSpells
        {
            get => _randomSpells;
            set => _randomSpells = value;
        }
        internal static Random RandomItem
        {
            get => _randomItem;
            set => _randomItem = value;
        }

        internal static void ItemRandomizer(Characters character)
        {
            if (CustomWeapons.Count < 1) RandomCustomWeapons = RandomItem.Next(1, Weapons.Count);
            else RandomCustomWeapons = RandomItem.Next(1, CustomWeapons.Count);
            RandomArmors = RandomItem.Next(1, Armors.Count);
            RandomTrinkets = RandomItem.Next(1, Trinkets.Count);
            RandomSpells = RandomItem.Next(1, Spells.Count);

            Input.UserInput = Input.GetUserInput("", $"{Color.Apply("Et painanut oikein, paina 1-4.", Color.Red)}", 13);
            Console.Clear();

            switch (Input.UserInput)
            {
                case '1':
                    if (CustomWeapons.Count < 1)
                    {
                        character.Inventory.Add(Weapons[RandomCustomWeapons]);
                        DeletedWeapons.Add(Weapons[RandomCustomWeapons]);
                        Console.WriteLine($"{Weapons[RandomCustomWeapons]} Lisätty tavaroihin...\n");
                        Weapons.Remove(Weapons[RandomCustomWeapons]);
                    }
                    else
                    {
                        character.Inventory.Add(CustomWeapons[RandomCustomWeapons]);
                        DeletedWeapons.Add(CustomWeapons[RandomCustomWeapons]);
                        Console.WriteLine($"{CustomWeapons[RandomCustomWeapons]} Lisätty tavaroihin...\n");
                        CustomWeapons.Remove(CustomWeapons[RandomCustomWeapons]);
                    }

                    break;
                case '2':
                    character.MaxHealth += HealthItems(character, Armors[RandomArmors]);
                    character.Health = character.MaxHealth;
                    Console.WriteLine($"Hahmosi {Color.Apply(character.Character, Color.Blue)} elämäpisteet ovat nyt {Color.Apply(character.Health, Color.Green)}!\n");
                    Armors.Remove(Armors[RandomArmors]);
                    break;
                case '3':
                    character.Collectables.Add(Trinkets[RandomTrinkets]);
                    Console.WriteLine($"{Trinkets[RandomTrinkets]} Lisätty keräilyesineisiin...\n");
                    Trinkets.Remove(Trinkets[RandomTrinkets]);
                    break;
                case '4':
                    character.Inventory.Add(Spells[RandomSpells]);
                    DeletedSpells.Add(Spells[RandomSpells]);
                    Console.WriteLine($"{Spells[RandomSpells]} Lisätty tavaroihin...\n");
                    Spells.Remove(Spells[RandomSpells]);
                    break;
                default:
                    Console.WriteLine("ItemRandomizer() ei toiminut.");
                    break;
            }
        }//aseen arvonta / palkinto
        internal static int DamageItems(Characters character, string weapon) 
        {
            int temp = character.Damage;
            double damage = temp;

            switch (weapon)
            {
                case "Miekka":
                    damage *= 1.1;
                    break;
                case "Nuija":
                    damage *= 1.11;
                    break;
                case "Kirves":
                    damage *= 1.15;
                    break;
                case "Keihäs":
                    damage *= 1.15;
                    break;
                case "Sauva":
                    damage *= 1.2;
                    break;
                case "Pistooli":
                    damage *= 1.2;
                    break;
                case "Keppi":
                    damage *= 1.25;
                    break;
                case "Jousipyssy":
                    damage *= 1.25;
                    break;
                case "Soihtu": 
                    damage *= 1.3;
                    break;
                case "Sirppi":
                    damage *= 1.3;
                    break;
                case "Kynnet":
                    damage *= 1.35;
                    break;
                case "Harppuuna":
                    damage *= 1.35;
                    break;
                case "Sinko":
                    damage *= 1.4;
                    break;
                case "Atomi Pommi":
                    damage *= 1000;
                    break;
                case "Katapultti":
                    damage *= 1.4;
                    break;
                case "AK-47":
                    damage *= 10;
                    break;
                case "Vesipyssy":
                    damage *= 1.1;
                    break;
                case "Linko":
                    damage *= 1.45;
                    break;
                case "Pumerangi":
                    damage *= 1.45;
                    break;
                case "Liekinheitin":
                    damage *= 2;
                    break;
                case "Haulikko":
                    damage *= 1.5;
                    break;
                case "Ritsa":
                    damage *= 1.5;
                    break;
                case "Kävelykeppi":
                    damage *= 1.55;
                    break;
                default:
                    damage = 0;
                    Console.WriteLine("Items.cs() ei toimi.");
                    break;  
            }
            Math.Round(damage);
            temp = (int)damage;
            return temp;
        }//aseiden vahingot, riippuu hahmon damagesta
        internal static int EnemyDamage(Enemies enemy, string attack)
        {
            int temp = enemy.Damage;
            double damage = temp;

            switch (attack)
            {
                case "Pureminen":
                    damage *= 1.1;
                    break;
                case "Häntä isku":
                    damage *= 1.2;
                    break;
                case "Piiloutuminen":
                    damage *= 2;
                    break;
                case "Tikari isku":
                    damage *= 1.1;
                    break;
                case "Sala hyökkäys":
                    damage *= 2;
                    break;
                case "Puukotus":
                    damage *= 1.2;
                    break;
                case "Luu isku":
                    damage *= 1.1;
                    break;
                case "Luu tuho":
                    damage *= 1.2;
                    break;
                case "Pääkallo rusennus":
                    damage *= 2;
                    break;
                case "Mätä puraisu":
                    damage *= 1.1;
                    break;
                case "Aivo kolistus":
                    damage *= 1.2;
                    break;
                case "Myrkky sylky":
                    damage *= 2;
                    break;
                case "Tulinen hengitys":
                    damage *= 1.5;
                    break;
                case "Kynsi isku":
                    damage *= 1.2;
                    break;
                case "Karjunta":
                    damage *= 2;
                    break;
                default:
                    damage = 0;
                    Console.WriteLine("Items.cs ei toimi");
                    break;
            }
            Math.Round(damage);
            temp = (int)damage;
            return temp;
        }//vihollisten vahingot
        internal static int TrinketItems(List<string> collectables)
        {
            int points = 0;
            //laske keräilyesineet
            foreach (string trinket in collectables)
            {
                switch (trinket)
                {
                    case "Kaulakoru":
                        points += 100;
                        break;
                    case "Timantti":
                        points += 200;
                        break;
                    case "Uraani":
                        points += 300;
                        break;
                    case "CPU":
                        points += 500;
                        break;
                    case "Meteoriitti":
                        points += 100000;
                        break;
                    default:
                        points += 0;
                        Console.WriteLine("TrinketItems() ei toimi");
                        break;
                }
            }
            return points;
        }//keräily esineet pisteet
        internal static double SpellItems(string? spell)
        {
            double chance = 0;

            switch (spell)
            {
                case "Tulipallo":
                    chance = 0.6;
                    break;
                case "Jääpallo":
                    chance = 0.7;
                    break;
                case "Ketju Salama":
                    chance = 0.8;
                    break;
                case "Jää Nova":
                    chance = 0.9;
                    break;
                case "Jää Myrsky":
                    chance = 1.0;
                    break;
                default:
                    chance = 0;
                    Console.WriteLine("SpellsItems() ei toimi");
                    break;
            }
            return chance;
        }//loitsut, mahdollisuudet toimia
        internal static int HealthItems(Characters character, string item)
        {
            int health = 0;

            switch (item)
            {
                case "Nahka haarniska":
                    health = 100;
                    break;
                case "Teräs kypärä":
                    health = 200;
                    break;
                case "Alumiini saappaat":
                    health = 300;
                    break;
                case "Muovi hanskat":
                    health = 400;
                    break;
                case "Kulta hartijasuojat":
                    health = 500;
                    break;
                default:
                    health = 0;
                    Console.WriteLine("HealthItems() ei toimi");
                    break;
            }
            return health;
        }//elämäpiste tavarat, maxhealth
        internal static string ChooseAction()
        {
            string weapon;
            Characters character = Characters.CharacterList[0];
            while (true)
            {
                Input.UserInput = Input.GetUserInput("", "Valitsemasi ase ei ole saatavilla tai ei ole olemassa. Yritä uudestaan.", 14);
                Console.Clear();

                weapon = string.Empty;

                switch (char.ToUpper(Input.UserInput))
                {
                    case 'A':
                        if (character.Inventory.Count >= 1)
                        {
                            weapon = character.Inventory[0];
                        }
                        break;
                    case 'B':
                        if (character.Inventory.Count >= 2)
                        {
                            weapon = character.Inventory[1];
                        }
                        break;
                    case 'C':
                        if (character.Inventory.Count >= 3)
                        {
                            weapon = character.Inventory[2];
                        }
                        break;
                    case 'D':
                        if (character.Inventory.Count >= 4)
                        {
                            weapon = character.Inventory[3];
                        }
                        break;
                    case 'E':
                        if (character.Inventory.Count >= 5)
                        {
                            weapon = character.Inventory[4];
                        }
                        break;
                    case 'F':
                        if (character.Inventory.Count >= 6)
                        {
                            weapon = character.Inventory[5];
                        }
                        break;
                    case 'G':
                        if (character.Inventory.Count >= 7)
                        {
                            weapon = character.Inventory[6];
                        }
                        break;
                    case 'H':
                        if (character.Inventory.Count >= 8)
                        {
                            weapon = character.Inventory[7];
                        }
                        break;
                    case 'I':
                        if (character.Inventory.Count >= 9)
                        {
                            weapon = character.Inventory[8];
                        }
                        break;
                    case 'J':
                        if (character.Inventory.Count >= 10)
                        {
                            weapon = character.Inventory[9];
                        }
                        break;
                    case 'K':
                        if (character.Inventory.Count >= 11)
                        {
                            weapon = character.Inventory[10];
                        }
                        break;
                    case 'L':
                        if (character.Inventory.Count >= 12)
                        {
                            weapon = character.Inventory[11];
                        }
                        break;
                    case 'M':
                        if (character.Inventory.Count >= 13)
                        {
                            weapon = character.Inventory[12];
                        }
                        break;
                    case 'N':
                        if (character.Inventory.Count >= 14)
                        {
                            weapon = character.Inventory[13];
                        }
                        break;
                    case 'O':
                        if (character.Inventory.Count >= 15)
                        {
                            weapon = character.Inventory[14];
                        }
                        break;
                    case 'P':
                        if (character.Inventory.Count >= 16)
                        {
                            weapon = character.Inventory[15];
                        }
                        break;
                    case 'Q':
                        if (character.Inventory.Count >= 17)
                        {
                            weapon = character.Inventory[16];
                        }
                        break;
                    case 'R':
                        if (character.Inventory.Count >= 18)
                        {
                            weapon = character.Inventory[17];
                        }
                        break;
                    case 'S':
                        if (character.Inventory.Count >= 19)
                        {
                            weapon = character.Inventory[18];
                        }
                        break;
                    case 'T':
                        if (character.Inventory.Count >= 20)
                        {
                            weapon = character.Inventory[19];
                        }
                        break;
                    case 'U':
                        if (character.Inventory.Count >= 21)
                        {
                            weapon = character.Inventory[20];
                        }
                        break;
                    default:
                        Console.SetCursorPosition(0, Console.CursorTop + 1);
                        Console.WriteLine(Color.Apply("Valitsemasi ase ei ole saatavilla tai ei ole olemassa.", Color.Red));
                        continue;
                }

                if (!string.IsNullOrEmpty(weapon))
                {
                    return weapon;
                }
            }
        }//tavaran valinta taistelussa, lvl 2 ja 5
    }
}
