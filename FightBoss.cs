
namespace ConsoleApp1
{
    class FightBoss : Fights
    {
        //LOHIKÄÄRME
        internal static void Print(DragonBoss dragon, Characters character)
        {
            int rotation = 0;
            string weapon;
            string attack;
            double odds;
            double chance;
            int damage;

            Console.WriteLine($"Päätaistelu {Color.Apply("Lohikäärmettä", Color.Red)} vastaan\n");
            UI.EnterCheck();

            while (character.Health > 0 && dragon.Health > 0)
            {
                if (rotation % 2 == 0 && rotation != 0)
                {
                    Console.WriteLine($"{Color.Apply(dragon.Name, Color.Red)} on lentänyt suojaan käyttämällä {Color.Apply(dragon.Attack3, Color.Purple)}-puolustusta.");
                    Console.WriteLine($"{Color.Apply("Lohikäärmettä", Color.Red)} ei voi hyökätä tällä kierroksella\n");
                    if (character.Inventory.Contains("Parannus"))
                    {
                        Console.WriteLine($"{Color.Apply("Parantava Taika", Color.Green)} ei ole saatavilla kun {Color.Apply(dragon.Name, Color.Red)} on {Color.Apply("suojassa", Color.Purple)}.");
                        Input.UserInput = Input.GetUserInput($"Haluatko käyttää {Color.Apply("Parannusta", Color.Green)} ({Color.Apply("+50", Color.Green)} elämäpisteet) (Y/n)?", "Et painanut oikein, yritä uudestaan.", 3);
                        switch (Input.UserInput)
                        {
                            case 'Y':
                            case 'y':
                                character.Health += 50;
                                Console.WriteLine("Parannetaan...\n");
                                Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} elämäpisteet: {Color.Apply(character.Health, Color.Green)}\n");
                                UI.EnterCheck();
                                rotation++;
                                continue;
                            case 'N':
                            case 'n':
                                UI.EnterCheck();
                                rotation++;
                                continue;
                            default:
                                Console.WriteLine("UserInput() ei toimi.");
                                break;
                        }
                    }
                }//lento pois
                if (rotation == 0 || rotation % 5 == 0)
                {
                    Console.WriteLine($"{Color.Apply(dragon.Name, Color.Red)} yllättää hahmon {Color.Apply(character.Character, Color.Blue)}!\n");

                    attack = dragon.Attack4 ?? "";
                    damage = Items.EnemyDamage(dragon, attack);
                    Console.WriteLine($"{Color.Apply(dragon.Name, Color.Red)} hyökkää erikoishyökkäyksellä {Color.Apply(attack, Color.Purple)} vahingolla {Color.Apply(damage, Color.Red)} hahmoa {Color.Apply(character.Character, Color.Blue)}!");
                    Console.WriteLine($"Hyökkäykset {Color.Apply("Lohikäärmettä", Color.Red)} vastaan tällä kierroksella tekevät vähemmän {Color.Apply("vahinkoa", Color.Red)}.\n");
                    character.Health -= damage;
                    Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} elämäpisteet: {Color.Apply(character.Health, Color.Green)}\n");
                    UI.EnterCheck();
                    if (!Alive(character)) UI.GameOver(Users.UserList[0], character);

                    //hahmo hyökkää
                    Console.WriteLine("Sinun vuorosi.\n");
                    Console.WriteLine($"Hyökkäykset tekevät tällä kierroksella vähemmän {Color.Apply("vahinkoa.", Color.Red)}");
                    weapon = Items.ChooseAction();
                    if (weapon.Equals("Parannus"))
                    {
                        Console.WriteLine($"{Color.Apply(weapon, Color.Green)} antoi {Color.Apply(50, Color.Green)} elämäpistettä!");
                        character.Health += 50;
                        Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} elämäpisteet: {Color.Apply(character.Health, Color.Green)}\n");
                        UI.EnterCheck();
                        rotation++;
                        continue;
                    }
                    else if (weapon.Equals("Parantava Taika"))
                    {
                        Console.WriteLine($"{Color.Apply(weapon, Color.Green)} antaa {Color.Apply("täydet", Color.Green)} elämäpisteet!");
                        character.Health = character.MaxHealth;
                        Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} elämäpisteet: {Color.Apply(character.Health, Color.Green)}\n");
                        UI.EnterCheck();
                        rotation++;
                        continue;
                    }
                    else if (Items.Spells.Contains(weapon) || Items.DeletedSpells.Contains(weapon))
                    {
                        odds = Items.SpellItems(weapon);
                        chance = random.NextDouble();
                        if (chance <= odds)
                        {
                            Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} hyökkää loitsulla {Color.Apply(weapon, Color.Blue)} vihollista {Color.Apply(dragon.Name, Color.Red)}!");
                            Console.WriteLine($"{Color.Apply(dragon.Name, Color.Red)} menettää {Color.Apply("kolmasosan", Color.Red)} elämäpisteistään.\n");
                            dragon.Health -= (Enemies.DragonMaxHealth / 3);
                            Console.WriteLine($"{Color.Apply(dragon.Name, Color.Red)} elämäpisteet: {Color.Apply(dragon.Health, Color.Green)}\n");
                            if (!Alive(dragon)) break;
                            Console.WriteLine("Loitsu on käytetty ja häviää..\n");
                            UI.EnterCheck();
                            character.Inventory.Remove(weapon);//häviää käytön jälkeen
                            rotation++;
                            continue;
                        }
                        else
                        {
                            Console.WriteLine($"{Color.Apply(weapon, Color.Blue)} loitsu ei onnistunut... menetit vuorosi");
                            Console.WriteLine("Loitsu on käytetty ja häviää..\n");
                            character.Inventory.Remove(weapon);//häviää käytön jälkeen
                            UI.EnterCheck();
                            rotation++;
                            continue;
                        }
                    }
                    else if (Items.Weapons.Contains(weapon) || Items.CustomWeapons.Contains(weapon) || Items.DeletedWeapons.Contains(weapon))
                    {   //hahmo hyökkää
                        damage = (int)(0.5 * (Items.DamageItems(character, weapon)));
                        if (Fights.CriticalStrike()) damage = (int)(damage * Fights.critAmount);
                        Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} hyökkää aseella {Color.Apply(weapon, Color.Red)} vahingolla {Color.Apply(damage, Color.Red)} vihollista {Color.Apply(dragon.Name, Color.Red)}!");
                        dragon.Health -= damage;
                        Console.WriteLine($"{Color.Apply(dragon.Name, Color.Red)} elämäpisteet: {Color.Apply(dragon.Health, Color.Green)}\n");
                        UI.EnterCheck();
                        if (!Alive(dragon)) break;
                        rotation++;
                        continue;
                    }
                }//karjunta
                if (rotation % 3 == 0)
                {
                    //lohikäärme hyökkää
                    Console.WriteLine($"On {Color.Apply("Lohikäärmeen", Color.Red)} vuoro.\n");
                    attack = dragon.Attack ?? "";
                    damage = Items.EnemyDamage(dragon, attack);
                    Console.WriteLine($"{Color.Apply(dragon.Name, Color.Red)} hyökkää erikoishyökkäyksellä {Color.Apply(attack, Color.Purple)} vahingolla {Color.Apply(damage, Color.Red)} hahmoa {Color.Apply(character.Character, Color.Blue)}!\n");
                    Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} on {Color.Apply("tulessa", Color.Red)}! Hänen pitää käyttää {Color.Apply("Parannus", Color.Green)} loitsua välittömästi!!\n");
                    char UserInput = Input.GetUserInput($"Paina {Color.Apply("ENTER", Color.Purple)} näppäintä kunnes olet sammunut tulesta!!", $"Et painanut {Color.Apply("ENTER", Color.Purple)} näppäintä, yritä uudestaan.", 15);


                    switch (UserInput)
                    {
                        case '\r':
                            break;
                        default:
                            Console.WriteLine("EnterCheck() ei toimi.");
                            Console.Clear();
                            break;
                    }
                    character.Health -= damage;
                    Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} elämäpisteet: {Color.Apply(character.Health, Color.Green)}\n");
                    Thread ignoreInputThread = new Thread(() => UI.IgnoreUserInput());
                    ignoreInputThread.Start();
                    Thread.Sleep(5000);
                    UI.EnterCheck();
                    if (!Alive(character)) UI.GameOver(Users.UserList[0], character);

                    //hahmo hyökkää
                    Console.WriteLine("Sinun vuorosi.\n");
                    weapon = Items.ChooseAction();
                    if (weapon.Equals("Parannus"))
                    {
                        Console.WriteLine($"{Color.Apply(weapon, Color.Green)} antoi {Color.Apply(50, Color.Green)} elämäpistettä!");
                        character.Health += 50;
                        Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} elämäpisteet: {Color.Apply(character.Health, Color.Green)}\n");
                        UI.EnterCheck();
                        rotation++;
                        continue;
                    }
                    else if (weapon.Equals("Parantava Taika"))
                    {
                        Console.WriteLine($"{Color.Apply(weapon, Color.Green)} antaa täydet elämäpisteet!");
                        character.Health = character.MaxHealth;
                        Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} elämäpisteet: {Color.Apply(character.Health, Color.Green)}\n");
                        UI.EnterCheck();
                        rotation++;
                        continue;
                    }
                    else if (Items.Spells.Contains(weapon) || Items.DeletedSpells.Contains(weapon))
                    {
                        odds = Items.SpellItems(weapon);
                        chance = random.NextDouble();
                        if (chance <= odds)
                        {
                            Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} hyökkää loitsulla {Color.Apply(weapon, Color.Blue)} vihollista {Color.Apply(dragon.Name, Color.Red)}!");
                            Console.WriteLine($"{Color.Apply(dragon.Name, Color.Red)} menettää {Color.Apply("puolet", Color.Red)} elämäpisteistään.\n");
                            dragon.Health -= (Enemies.DragonMaxHealth / 2);
                            Console.WriteLine($"{Color.Apply(dragon.Name, Color.Red)} elämäpisteet: {Color.Apply(dragon.Health, Color.Green)}");
                            Console.WriteLine("Loitsu on käytetty ja häviää..\n");
                            character.Inventory.Remove(weapon);//häviää käytön jälkeen
                            UI.EnterCheck();
                            if (!Alive(dragon)) break;
                            rotation++;
                            continue;
                        }
                        else
                        {
                            Console.WriteLine($"{Color.Apply(weapon, Color.Blue)} loitsu ei onnistunut... menetit vuorosi");
                            Console.WriteLine("Loitsu on käytetty ja häviää..\n");
                            character.Inventory.Remove(weapon);//häviää käytöm jälkeen
                            UI.EnterCheck();
                            rotation++;
                            continue;
                        }
                    }
                    else if (Items.Weapons.Contains(weapon) || Items.CustomWeapons.Contains(weapon) || Items.DeletedWeapons.Contains(weapon))
                    {   //hahmo hyökkää
                        damage = character.Damage + Items.DamageItems(character, weapon);
                        if (Fights.CriticalStrike()) damage = (int)(damage * Fights.critAmount);
                        Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} hyökkää aseella {Color.Apply(weapon, Color.Red)} vahingolla {Color.Apply(damage, Color.Red)}" +
                            $" vihollista {dragon.Name}!");
                        dragon.Health -= damage;
                        Console.WriteLine($"{Color.Apply(dragon.Name, Color.Red)} elämäpisteet: {Color.Apply(dragon.Health, Color.Green)}\n");
                        UI.EnterCheck();
                        if (!Alive(dragon)) break;
                        rotation++;
                        continue;
                    }
                }//tulinen hengitys

                //normi hyökkäys, kynsi hyökkäys
                Console.WriteLine($"On {Color.Apply("Lohikäärmeen", Color.Red)} vuoro.\n");
                attack = dragon.Attack2 ?? "";
                damage = Items.EnemyDamage(dragon, attack);
                Console.WriteLine($"{Color.Apply(dragon.Name, Color.Red)} hyökkää hyökkäyksellä {Color.Apply(attack, Color.Red)} vahingolla {Color.Apply(damage, Color.Red)} hahmoa {Color.Apply(character.Character, Color.Blue)}!");
                character.Health -= damage;
                Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} elämäpisteet: {Color.Apply(character.Health, Color.Green)}\n");
                UI.EnterCheck();
                if (!Alive(character)) UI.GameOver(Users.UserList[0], character);

                //hahmo hyökkää
                Console.WriteLine("Sinun vuorosi.\n");
                weapon = Items.ChooseAction();
                if (weapon.Equals("Parannus"))
                {
                    Console.WriteLine($"{Color.Apply("Parannus", Color.Green)} antoi {Color.Apply(50, Color.Green)} elämäpistettä!");
                    character.Health += 50;
                    Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} elämäpisteet: {Color.Apply(character.Health, Color.Green)}\n");
                    UI.EnterCheck();
                    rotation++;
                    continue;
                }
                else if (weapon.Equals("Parantava Taika"))
                {
                    Console.WriteLine($"{Color.Apply(weapon, Color.Green)} antaa {Color.Apply("täydet", Color.Green)} elämäpisteet!");
                    character.Health = character.MaxHealth;
                    Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} elämäpisteet: {Color.Apply(character.Health, Color.Green)}\n");
                    UI.EnterCheck();
                    rotation++;
                    continue;
                }
                else if (Items.Spells.Contains(weapon) || Items.DeletedSpells.Contains(weapon))
                {
                    odds = Items.SpellItems(weapon);
                    chance = random.NextDouble();
                    if (chance <= odds)
                    {
                        Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} hyökkää loitsulla {Color.Apply(weapon, Color.Blue)} vihollista {Color.Apply(dragon.Name, Color.Red)}!");
                        Console.WriteLine($"{Color.Apply(dragon.Name, Color.Red)} menettää {Color.Apply("puolet", Color.Red)} elämäpisteistään.\n");
                        dragon.Health -= (Enemies.DragonMaxHealth / 2);
                        Console.WriteLine($"{Color.Apply(dragon.Name, Color.Red)} elämäpisteet: {Color.Apply(dragon.Health, Color.Green)}");
                        Console.WriteLine("Loitsu on käytetty ja häviää..\n");
                        character.Inventory.Remove(weapon);//häviää käytön jälkeen
                        UI.EnterCheck();
                        if (!Alive(dragon)) break;
                        rotation++;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"{Color.Apply(weapon, Color.Blue)} loitsu ei onnistunut... menetit vuorosi");
                        Console.WriteLine("Loitsu on käytetty ja häviää..\n");
                        character.Inventory.Remove(weapon);//häviää käytöm jälkeen
                        UI.EnterCheck();
                        rotation++;
                        continue;
                    }
                }
                else if (Items.Weapons.Contains(weapon) || Items.CustomWeapons.Contains(weapon) || Items.DeletedWeapons.Contains(weapon))
                {   //hahmo hyökkää
                    damage = Items.DamageItems(character, weapon);
                    if (Fights.CriticalStrike()) damage = (int)(damage * Fights.critAmount);
                    Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} hyökkää aseella {Color.Apply(weapon, Color.Red)} vahingolla {Color.Apply(damage, Color.Red)} vihollista {Color.Apply(dragon.Name, Color.Red)}!");
                    dragon.Health -= damage;
                    Console.WriteLine($"{Color.Apply(dragon.Name, Color.Red)} elämäpisteet: {Color.Apply(dragon.Health, Color.Green)}\n");
                    UI.EnterCheck();
                    if (!Alive(dragon)) break;
                }
                rotation++;
            }
            Console.Clear();
            Console.WriteLine($" {Color.Apply(dragon.Name, Color.Red)} katoaa...\n");
            UI.EnterCheck();
        }
    }
}
