
namespace ConsoleApp1
{
    class Fight1 : Fights
    {
        //ROTTA
        internal static void Print(BigRat bigrat, Characters character)
        {
            bool hide = false;
            string weapon;
            string attack;
            double odds;
            double chance;
            int damage;

            Console.WriteLine($"Ensimmäinen taistelu on {Color.Apply("Jätti Rottaa", Color.Red)} vastaan.\n");
            UI.EnterCheck();

            while (character.Health > 0 && bigrat.Health > 0)
            {
                if(hide)
                {
                    Console.WriteLine($"{Color.Apply("Rotta", Color.Red)} on mennyt {Color.Apply("piiloon", Color.Purple)} ja sinun pitää odottaa 5 sekuntia ennen kun se tulee esiin..");
                    Thread ignoreInputThread = new Thread(() => UI.IgnoreUserInput());
                    ignoreInputThread.Start();
                    Thread.Sleep(5000);
                    Console.WriteLine($"{Color.Apply("Rotta", Color.Red)} on tullut esiin, taistelu jatkuu..\n");
                    hide = false;

                    UI.EnterCheck();
                }//piiloutumuinen
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
                        Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} hyökkää loitsulla {Color.Apply(weapon, Color.Blue)} ja {Color.Apply("surmaa vihollisen", Color.Red)} {Color.Apply(bigrat.Name, Color.Red)}!");
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
                        character.Inventory.Remove(weapon);//häviää käytön jälkeen
                    }
                }
                else if (Items.Weapons.Contains(weapon) || Items.CustomWeapons.Contains(weapon) || Items.DeletedWeapons.Contains(weapon))
                {
                    damage = Items.DamageItems(character, weapon);
                    if (Fights.CriticalStrike()) damage = (int)(damage * Fights.critAmount);
                    Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} hyökkää aseella {Color.Apply(weapon, Color.Red)} vahingolla {Color.Apply(damage, Color.Red)} vihollista {Color.Apply(bigrat.Name, Color.Red)}!");
                    bigrat.Health -= damage;
                    Console.WriteLine($"{Color.Apply(bigrat.Name, Color.Red)} elämäpisteet: {Color.Apply(bigrat.Health, Color.Green)}\n");
                    UI.EnterCheck();
                    if (!Alive(bigrat)) break;
                }
                
                //vihollinen hyökkää
                Console.WriteLine($"On {Color.Apply("Jätti Rotan", Color.Red)} vuoro.\n");
                attack = Enemies.EnemyAttack(bigrat);
                if (attack.Equals("Piiloutuminen"))
                {
                    int damage2 = Items.EnemyDamage(bigrat, attack);
                    Console.WriteLine($"{Color.Apply(bigrat.Name, Color.Red)} hyökkää erikoishyökkäyksellä {Color.Apply(attack, Color.Purple)} vahingolla {Color.Apply(damage2, Color.Red)} hahmoa {Color.Apply(character.Character, Color.Blue)}!");
                    hide = true;
                    character.Health -= damage2;
                    Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} elämäpisteet: {Color.Apply(character.Health, Color.Green)}\n");
                    if (!Alive(character)) UI.GameOver(Users.UserList[0], character);
                }
                else
                {
                    damage = Items.EnemyDamage(bigrat, attack);
                    Console.WriteLine($"{Color.Apply(bigrat.Name, Color.Red)} hyökkää hyökkäyksellä {Color.Apply(attack, Color.Red)} vahingolla {Color.Apply(damage, Color.Red)} hahmoa {Color.Apply(character.Character, Color.Blue)}!");
                    character.Health -= damage;
                    Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} elämäpisteet: {Color.Apply(character.Health, Color.Green)}\n");
                    if (!Alive(character)) UI.GameOver(Users.UserList[0], character);
                }
                UI.EnterCheck();
            }
            Console.Clear();
            Console.WriteLine($"Vihollinen 1. {Color.Apply(bigrat.Name, Color.Red)} on {Color.Apply("surmattu", Color.Red)}\n");
            UI.EnterCheck();
        }
    }
}
