
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    class Fight5 : Fights
    {
        //ZOMBI
        internal static void Print(RottenZombie zombie, Characters character)
        {
            string weapon;
            string attack;
            double odds;
            double chance;
            int damage;

            Console.WriteLine($"Viides taistelu {Color.Apply("Mädäntynyttä Zombia", Color.Red)} vastaan vastaan.\n");
            UI.EnterCheck();

            while (character.Health > 0 && zombie.Health > -50)//zombi ei kuole helposti
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
                        Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} hyökkää loitsulla {Color.Apply(weapon, Color.Blue)} ja {Color.Apply("surmaa", Color.Red)} vihollisen {Color.Apply(zombie.Name, Color.Red)}!\n");
                        Console.WriteLine("Loitsu on käytetty ja häviää..\n");
                        UI.EnterCheck();
                        character.Inventory.Remove(weapon);//häviää käytön jälkeen
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{Color.Apply(weapon, Color.Blue)} loitsu ei onnistunut... menetit vuorosi.");
                        Console.WriteLine("Loitsu on käytetty ja häviää..\n");
                        UI.EnterCheck();
                        character.Inventory.Remove(weapon);//häviää käytöm jälkeen
                    }
                }
                if (Items.Weapons.Contains(weapon) || Items.CustomWeapons.Contains(weapon) || Items.DeletedWeapons.Contains(weapon))
                {
                    damage = Items.DamageItems(character, weapon);
                    if (Fights.CriticalStrike()) damage = (int)(damage * Fights.critAmount);
                    Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} hyökkää aseella {Color.Apply(weapon, Color.Red)} vahingolla {Color.Apply(damage, Color.Red)} vihollista {Color.Apply(zombie.Name, Color.Red)}!");
                    zombie.Health -= damage;
                    Console.WriteLine($"{Color.Apply(zombie.Name, Color.Red)} elämäpisteet: {Color.Apply(zombie.Health, Color.Green)}\n");
                    UI.EnterCheck();
                    if (!Alive(zombie)) break;
                }
                if (zombie.Health <= 0)
                {
                    Console.WriteLine($"{Color.Apply("Zombien", Color.Purple)} elämäpisteet ovat menneet alle {Color.Apply("nollaan", Color.Red)}, mutta hän ei kuole, ei kai auta kun jatkaa taistelua..???\n");
                    UI.EnterCheck();
                }

                //vihollinen hyökkää
                Console.WriteLine($"On {Color.Apply("Mädäntyneen Zombin", Color.Red)} vuoro.\n");
                attack = Enemies.EnemyAttack(zombie);
                damage = Items.EnemyDamage(zombie, attack);
                Console.WriteLine($"{Color.Apply(zombie.Name, Color.Red)} hyökkää hyökkäyksellä {Color.Apply(attack, Color.Red)} vahingolla {Color.Apply(damage, Color.Red)} hahmoa {Color.Apply(character.Character, Color.Blue)}!");
                character.Health -= damage;
                Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} elämäpisteet: {Color.Apply(character.Health, Color.Green)}\n");
                if (!Alive(character)) UI.GameOver(Users.UserList[0], character);
                UI.EnterCheck();
            }
            Console.Clear();
            Console.WriteLine($"Viimeinen vihollinen {Color.Apply(zombie.Name, Color.Red)} on {Color.Apply("surmattu", Color.Red)}\n");
            UI.EnterCheck();
        }
    }
}
