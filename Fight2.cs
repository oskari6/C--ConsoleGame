
namespace ConsoleApp1
{
    class Fight2 : Fights
    {
        //PEIKKO
        internal static void Print(Goblin goblin, Characters character)
        {
            bool bleed = false;
            string weapon;
            string attack;
            double odds;
            double chance;
            int damage;

            Console.WriteLine($"Toinen taistelu {Color.Apply("Peikkoa", Color.Red)} vastaan.\n");
            UI.EnterCheck();

            while (character.Health > 0 && goblin.Health > 0)
            {
                if (bleed) character.Health -= 5;
                if(character.Collectables.Count > 0)
                {
                    Console.WriteLine($"Voi ei {goblin.Name} on {Color.Apply("varastanut", Color.Purple)} keräilyesineesi!!\n");
                    character.Collectables.Clear();
                    UI.EnterCheck();
                }
                //hahmo hyökkää
                Console.WriteLine("Sinun vuorosi.");
                weapon = Items.ChooseAction();
                if (weapon.Equals("Parannus"))
                {
                    Console.WriteLine($"{Color.Apply(weapon, Color.Green)} antoi {Color.Apply(50, Color.Green)} elämäpistettä!");
                    character.Health += 50;
                    Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} elämäpisteet: {Color.Apply(character.Health, Color.Green)}\n");
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
                        Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} hyökkää loitsulla {Color.Apply(weapon, Color.Blue)} ja {Color.Apply("surmaa", Color.Red)} vihollisen {goblin.Name}!");
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
                else if(Items.Weapons.Contains(weapon) || Items.CustomWeapons.Contains(weapon) || Items.DeletedWeapons.Contains(weapon))
                {
                    damage = Items.DamageItems(character, weapon);
                    if (Fights.CriticalStrike()) damage = (int)(damage * Fights.critAmount);
                    Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} hyökkää aseella {Color.Apply(weapon, Color.Red)} vahingolla {Color.Apply(damage, Color.Red)} vihollista {goblin.Name}!");
                    goblin.Health -= damage;
                    Console.WriteLine($"{Color.Apply(goblin.Name, Color.Red)} elämäpisteet: {Color.Apply(goblin.Health, Color.Green)}\n");
                    UI.EnterCheck();
                    if (!Alive(goblin)) break;
                }

                //vihollinen hyökkää
                Console.WriteLine($"On {Color.Apply("Peikon", Color.Red)} vuoro.\n");
                attack = Enemies.EnemyAttack(goblin);
                damage = Items.EnemyDamage(goblin, attack);
                if(attack.Equals("Sala hyökkäys"))
                {
                    Console.WriteLine($"{Color.Apply(goblin.Name, Color.Red)} hyökkää erikoishyökkäyksellä {Color.Apply(attack, Color.Purple)} vahingolla {Color.Apply(damage, Color.Red)} hahmoa {Color.Apply(character.Character, Color.Blue)}!");
                    Console.WriteLine($"{Color.Apply(attack, Color.Purple)} aiheuttaa {Color.Apply("5:n", Color.Red)} elämäpisteen verenvuodon joka kierroksella!");
                    bleed = true;
                    character.Health -= damage;
                    Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} elämäpisteet: {Color.Apply(character.Health, Color.Green)}\n");
                    if (!Alive(character)) UI.GameOver(Users.UserList[0], character);
                }
                else
                {
                    Console.WriteLine($"{Color.Apply(goblin.Name, Color.Red)} hyökkää hyökkäyksellä {Color.Apply(attack, Color.Red)} vahingolla {Color.Apply(damage, Color.Red)} hahmoa {Color.Apply(character.Character, Color.Blue)}!\n");
                    character.Health -= damage;
                    Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} elämäpisteet: {Color.Apply(character.Health, Color.Green)}");
                    if (!Alive(character)) UI.GameOver(Users.UserList[0], character);
                }

                UI.EnterCheck();
            }
            Console.Clear();
            Console.WriteLine($"Vihollinen 2. {Color.Apply(goblin.Name, Color.Red)} on {Color.Apply("surmattu", Color.Red)}\n");
            UI.EnterCheck();
        }
    }
}
