using System.Reflection;

namespace ConsoleApp1
{
    class Characters : UI
    {
        private static List<Characters> _characterList = new List<Characters>();//toiminnallisuuden takia, pelaajan ominaisuukisen haulle
        private static List<string> _models = new List<string>() { "Haltija", "Kääpiö", "Ihminen", "Alien", "Custom"};//perus hahmot
        private static List<string> _customModels = new List<string>() {"Lisko", "Kyborgi", "Marsilainen", "Supersankari", "Tekoäly", "Jeesus", "Darth Vader"};//custom hahmot

        //hahmon ominaisuudet ja attribuutit
        private List<string> _inventory = new List<string>() { "Parannus" };//tavarat
        private List<string> _collectables = new List<string>();//keräilyesineet
        private string? _character;
        private int? _health;
        private int? _maxHealth;
        private int _damage;
        private int _difficulty;
        private double _multiplier;//pisteitä varten
        private static Characters? _model;//hahmon luonti pohja

        internal static List<Characters> CharacterList => _characterList;
        internal static List<string> Models => _models;
        internal static List<string> CustomModels => _customModels;
        internal List<string> Inventory
        {
            get => _inventory;
            set => _inventory = value;
        }
        internal List<string> Collectables
        {
            get => _collectables;
            set => _collectables = value;
        }
        internal string? Character
        {
            get => _character;
            set => _character = value;
        }
        internal int? Health
        {
            get => _health;
            set => _health = value;
        }
        internal int? MaxHealth
        {
            get => _maxHealth;
            set => _maxHealth = value;
        }
        internal int Damage
        {
            get => _damage;
            set => _damage = value;
        }
        internal int Difficulty
        {
            get => _difficulty;
            set => _difficulty = value;
        }
        internal double Multiplier
        {
            get => _multiplier;
            set => _multiplier = value;
        }

        internal Characters(string? character)
        {
            if (character == Models[0])
            {
                this.Character = character;
                this.Difficulty = 1;
                this.Health = 500;
                this.MaxHealth = 500;
                this.Multiplier = 1;
                this.Damage = 20;
            }
            if (character == Models[1])
            {
                this.Character = character;
                this.Difficulty = 2;
                this.Health = 500;
                this.MaxHealth = 500;
                this.Multiplier = 1.2;
                this.Damage = 20;
            }
            if (character == Models[2])
            {
                this.Character = character;
                this.Difficulty = 3;
                this.Health = 450;
                this.MaxHealth = 450;
                this.Multiplier = 1.5;
                this.Damage = 20;
            }
        }//muodostaja 1-3 hahmot
        internal Characters()
        {
            this.Character = Models[3];
            this.Difficulty = 4;
            string weapon = WeaponRandomizer();//ei aseen valinta vaihto ehtoa, saa randomina
            this.Inventory.Add(weapon);
            this.Health = 400;
            this.MaxHealth = 400;
            this.Multiplier = 2;
            this.Damage = 20;
        }//muodostaja hahmo 4
        internal Characters(string character, int difficulty, int health, int damage)
        {
            this.Character = character;
            this.Difficulty = difficulty;
            this.Health = health;
            this.MaxHealth = health;
            this.Multiplier = 2;
            this.Damage = damage;
        }//muodostaja custom hahmo
        internal static void CharacterChoose(Users user)
        {
            string character;
            int damage;
            int difficulty;
            int health;

            List<string> weapons = new List<string>();

            Input.UserInput = Input.GetUserInput("", $"{Color.Apply("Et painanut oikein, paina 1-5.", Color.Red)}", 5);
            Console.Clear();

            switch (Input.UserInput)
            {
                case '1':
                    Console.Clear();
                    character = Models[0];
                    _model = new Characters(character);
                    CharacterList.Add(_model);
                    weapons.Add(WeaponChoose());
                    foreach (string weapon in weapons)
                    {
                        _model.Inventory.Add(weapon);
                    }
                    UI.GameStartInfo(user, _model);
                    break;
                case '2':
                    character = Models[1];
                    _model = new Characters(character);
                    CharacterList.Add(_model);
                    weapons.Add(WeaponChoose());
                    foreach (string weapon in weapons)
                    {
                        _model.Inventory.Add(weapon);
                    }
                    UI.GameStartInfo(user, _model);
                    break;
                case '3':
                    character = Models[2];
                    _model = new Characters(character);
                    CharacterList.Add(_model);
                    weapons.Add(WeaponChoose());
                    foreach (string weapon in weapons)
                    {
                        _model.Inventory.Add(weapon);
                    }
                    UI.GameStartInfo(user, _model);
                    break;
                case '4':
                    _model = new Characters();
                    CharacterList.Add(_model);
                    UI.GameStartInfo(user, _model);
                    break;
                case '5':
                    character = CustomCharacter();
                    damage = CustomDamage();
                    Console.Clear();
                    difficulty = CustomDifficulty();
                    Console.Clear();
                    health = CustomHealth();
                    Console.Clear();
                    _model = new Characters(character, difficulty, health, damage);
                    CharacterList.Add(_model);
                    weapons = CustomWeapon();
                    foreach (string weapon in weapons)
                    {
                        _model.Inventory.Add(weapon);
                        Items.DeletedWeapons.Add(weapon);
                        Items.CustomWeapons.Remove(weapon);
                    }
                    UI.GameStartInfo(user, _model);
                    break;
                default:
                    Console.WriteLine("UserInput() ei toimi.");
                    break;
            }
        }//hahmon valinta
        static string WeaponChoose()
        {
            Input.UserInput = Input.GetUserInput("", $"{Color.Apply("Et painanut oikein, paina 1-5.", Color.Red)}", 11);
            Console.Clear();

            switch (Input.UserInput)
            {
                case '1':
                    return Items.Weapons[0];
                case '2':
                    return Items.Weapons[1];
                case '3':
                    return Items.Weapons[2];
                case '4':
                    return Items.Weapons[3];
                case '5':
                    return Items.Weapons[4];
                default:
                    Console.WriteLine("UserInput() ei toimi.");
                    return "\0";
            }
        }//aseen valinta
        static string CustomCharacter()
        {
            string character;

            Input.UserInput = Input.GetUserInput("", $"{Color.Apply("Et painanut oikein, paina 1-7.", Color.Red)}", 6);

            switch (Input.UserInput)
            {
                case '1':
                    character = Characters.CustomModels[0];
                    break;
                case '2':
                    character = Characters.CustomModels[1];
                    break;
                case '3':
                    character = Characters.CustomModels[2];
                    break;
                case '4':
                    character = Characters.CustomModels[3];
                    break;
                case '5':
                    character = Characters.CustomModels[4];
                    break;
                case '6':
                    character = Characters.CustomModels[5];
                    break;
                case '7':
                    character = Characters.CustomModels[6];
                    break;
                default:
                    Console.WriteLine("CustomCharacter() ei toimi");
                    character = "";
                    break;
            }
            Console.Clear();

            return character;
        }//custom hahmon valinta
        static List<string> CustomWeapon()
        {
            List<string> weapons = new List<string>();
            while (true)
            {
                Input.UserInput = Input.GetUserInput("", $"{Color.Apply("Et painanut oikein, paina A-P.", Color.Red)}", 4);
                Console.Clear();

                string weapon = Input.UserInput switch
                {
                    'A' or 'a' => weapon = Items.CustomWeapons[0],
                    'B' or 'b' => weapon = Items.CustomWeapons[1],
                    'C' or 'c' => weapon = Items.CustomWeapons[2],
                    'D' or 'd' => weapon = Items.CustomWeapons[3],
                    'E' or 'e' => weapon = Items.CustomWeapons[4],
                    'F' or 'f' => weapon = Items.CustomWeapons[5],
                    'G' or 'g' => weapon = Items.CustomWeapons[6],
                    'H' or 'h' => weapon = Items.CustomWeapons[7],
                    'I' or 'i' => weapon = Items.CustomWeapons[8],
                    'J' or 'j' => weapon = Items.CustomWeapons[9],
                    'K' or 'k' => weapon = Items.CustomWeapons[10],
                    'L' or 'l' => weapon = Items.CustomWeapons[11],
                    'M' or 'm' => weapon = Items.CustomWeapons[12],
                    'N' or 'n' => weapon = Items.CustomWeapons[13],
                    'O' or 'o' => weapon = Items.CustomWeapons[14],
                    'P' or 'p' => weapon = Items.CustomWeapons[15],
                    _ => throw new InvalidOperationException("UserInput() ei toimi.")
                };

                if (weapons.Contains(weapon))
                {
                    Console.Clear();
                    Console.WriteLine(Color.Apply("Sinulla on jo ase. Valitse toinen.", Color.Red));
                    continue;
                }
                weapons.Add(weapon);
                Console.Clear();
                if (weapons.Count == Items.CustomWeapons.Count) return weapons;

                Input.UserInput = Input.GetUserInput($"Haluatko lisää aseita? (Y/n)", $"{Color.Apply("Et painanut oikein, paina (Y/n).", Color.Red)}", 3);

                switch (Input.UserInput)
                {
                    case 'Y':
                    case 'y':
                        Console.Clear();
                        continue;
                    case 'n':
                    case 'N':
                        Console.Clear();
                        return weapons;
                    default:
                        Console.WriteLine("UserInput() ei toimi.");
                        break;
                }
            }
        }//custom aseen valinta
        static int CustomDifficulty()
        {
            Input.UserInput = Input.GetUserInput($"Paina {Color.Apply("vaikeustaso", Color.Red)} (1-5): ", $"{Color.Apply("Et painanut oikein, paina 1-5.", Color.Red)}", 12);

            switch (Input.UserInput)
            {
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                    Console.Clear();
                    return int.Parse(Input.UserInput.ToString());
                default:
                    Console.WriteLine("UserInput() ei toimi.");
                    return 0;
            }
        }//custom vaikeustason valinta
        static int CustomHealth()
        {
            int input;
            while (true)//methodi
            {
                Console.Write($"Valitse {Color.Apply("elämäpisteet", Color.Green)} (1-1000): ");
                int.TryParse(Console.ReadLine(), out input);
                if (input <= 0 || input > 1000)
                {
                    Console.WriteLine(Color.Apply("Anna elämäpisteet väliltä (1-1000)", Color.Red));
                    continue;
                }
                break;
            }
            return input;
        }//custom elämäpisteiden valinta

        static int CustomDamage()
        {
            int input;

            while (true)//methodi
            {
                Console.Write($"Valitse hahmon {Color.Apply("vahinko", Color.Red)} 1-30: ");
                int.TryParse(Console.ReadLine(), out input);
                if (input <= 0 || input > 30)
                {
                    Console.WriteLine(Color.Apply("Anna vahinko 1-30 väliltä", Color.Red));
                    continue;
                }
                break;
            }
            return input;
        }//custom damagen valinta
        string WeaponRandomizer()
        {
            Random randomItem = new Random();
            int randomWeapons = randomItem.Next(1, Items.Weapons.Count);
            return Items.Weapons[randomWeapons];
        }//Hahmo 4 random ase
    }
}
