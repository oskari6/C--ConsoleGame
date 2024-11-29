
namespace ConsoleApp1
{
    class Fight4 : Fights
    {
        //LUURANKO
        internal static void Print(HalfEatenSkeleton skeleton, Characters character)
        {
            bool stunned = false;
            string weapon;
            string attack;
            double odds;
            double chance;
            int damage;

            Console.WriteLine($"Neljäs taistelu {Color.Apply("Puoliksi Syötyä Luurankoa", Color.Red)} vastaan.\n");
            UI.EnterCheck();

            while (character.Health > 0 && skeleton.Health > 0)
            {   //hahmo hyökkää
                if (!stunned)
                {
                    //hahmo hyökkää
                    Console.WriteLine("Sinun vuorosi.");
                    weapon = Items.ChooseAction();
                    if (weapon.Equals("Parannus"))
                    {
                        Console.WriteLine($"{Color.Apply(weapon, Color.Green)} antoi {Color.Apply(50, Color.Green)} elämäpistettä!");
                        character.Health += 50;
                        Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} elämäpisteet: {Color.Apply(character.Health, Color.Green)}\n");
                        UI.EnterCheck();
                        Console.WriteLine($"{Color.Apply(skeleton.Name, Color.Red)} havaitsi että käytit {Color.Apply("Parannusta!", Color.Green)}!");
                        Console.WriteLine($"Joka kerta kun käytät Parantavia loitsuja {Color.Apply(skeleton.Name, Color.Red)} saa {Color.Apply("+10", Color.Green)} elämäpistettä");
                        skeleton.Health += Enemies.Heal;
                        Console.WriteLine($"{Color.Apply(skeleton.Name, Color.Red)} elämäpisteet: {Color.Apply(skeleton.Health, Color.Green)}\n");
                        UI.EnterCheck();
                    }
                    else if (weapon.Equals("Parantava Taika"))
                    {
                        Console.WriteLine($"{Color.Apply(weapon, Color.Green)} antaa {Color.Apply("täydet", Color.Green)} elämäpisteet!");
                        character.Health = character.MaxHealth;
                        Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} elämäpisteet: {Color.Apply(character.Health, Color.Green)}\n");
                        UI.EnterCheck();
                    }
                    else if (Items.Spells.Contains(weapon) || Items.DeletedSpells.Contains(weapon))
                    {
                        odds = Items.SpellItems(weapon);
                        chance = random.NextDouble();
                        if (chance <= odds)
                        {
                            Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} hyökkää loitsulla {Color.Apply(weapon, Color.Blue)} ja {Color.Apply("surmaa", Color.Red)} vihollisen {Color.Apply(skeleton.Name, Color.Red)}!");
                            Console.WriteLine("Loitsu on käytetty ja häviää..\n");
                            UI.EnterCheck();
                            character.Inventory.Remove(weapon);//häviää käytön jälkeen
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"{Color.Apply(weapon, Color.Blue)} loitsu ei onnistunut... menetit vuorosi");
                            Console.WriteLine("Loitsu on käytetty ja häviää..\n");
                            UI.EnterCheck();
                            character.Inventory.Remove(weapon);//häviää käytöm jälkeen
                        }
                    }
                    else if (Items.Weapons.Contains(weapon) || Items.CustomWeapons.Contains(weapon) || Items.DeletedWeapons.Contains(weapon))
                    {
                        damage = Items.DamageItems(character, weapon);
                        if (Fights.CriticalStrike()) damage = (int)(damage * Fights.critAmount);
                        Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} hyökkää aseella {Color.Apply(weapon, Color.Red)} vahingolla {Color.Apply(damage, Color.Red)} vihollista {Color.Apply(skeleton.Name, Color.Red)}!");
                        skeleton.Health -= damage;
                        Console.WriteLine($"{Color.Apply(skeleton.Name, Color.Red)} elämäpisteet: {Color.Apply(skeleton.Health, Color.Green)}\n");
                        UI.EnterCheck();
                        if (!Alive(skeleton)) break;
                    }
                }
                //vihollinen hyökkää
                Console.WriteLine($"On {Color.Apply("Puoliksi Syödyn Luurangon", Color.Red)} vuoro.\n");
                attack = Enemies.EnemyAttack(skeleton);
                damage = Items.EnemyDamage(skeleton, attack);
                if (attack.Equals("Pääkallo rusennus") && !stunned)
                {
                    Console.WriteLine($"{Color.Apply(skeleton.Name, Color.Red)} murskaa hahmon {Color.Apply(character.Character, Color.Blue)} pään erikoishyökkäyksellä {Color.Apply(attack, Color.Purple)} vahingolla {Color.Apply(damage, Color.Red)}!");
                    Console.WriteLine($"Olet saanut {Color.Apply("aivotärähdyksen", Color.Red)} etkä pysty hyökkäämään ensi kierroksella");
                    stunned = true;
                    character.Health -= damage;
                    Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} elämäpisteet: {Color.Apply(character.Health, Color.Green)}\n");
                    if (!Alive(character)) UI.GameOver(Users.UserList[0], character);
                }
                else
                {
                    do
                    {
                        attack = Enemies.EnemyAttack(skeleton);
                        if (!attack.Equals(skeleton.Attack3))
                        {
                            break;
                        }

                    } while (true);
                    damage = Items.EnemyDamage(skeleton, attack);
                    stunned = false;
                    Console.WriteLine($"{Color.Apply(skeleton.Name, Color.Red)} hyökkää hyökkäyksellä {Color.Apply(attack, Color.Red)} vahingolla {Color.Apply(damage, Color.Red)} hahmoa {Color.Apply(character.Character, Color.Blue)}!");
                    character.Health -= damage;
                    Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} elämäpisteet: {Color.Apply(character.Health, Color.Green)}\n");
                    if (!Alive(character)) UI.GameOver(Users.UserList[0], character);
                }
                UI.EnterCheck();
            }
            Console.Clear();
            Console.WriteLine($"Vihollinen 4. {Color.Apply(skeleton.Name, Color.Red)} on {Color.Apply("surmattu", Color.Red)}\n");
            UI.EnterCheck();
        }
    }
}