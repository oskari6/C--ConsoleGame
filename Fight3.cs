
namespace ConsoleApp1
{
    class Fight3 : Fights
    {
        //VELHO
        internal static void Print(HumanSourceress human, Characters character)
        {
            bool counter = false;
            int rotation = 0;
            string weapon;
            string attack;
            double odds;
            double chance;
            int damage;

            Console.WriteLine($"Kolmas taistelu {Color.Apply("Velhoa", Color.Red)} vastaan.\n");
            UI.EnterCheck();

            while (character.Health > 0 && human.Health > 0)
            {
                if(rotation % 3 == 0 && rotation != 0)
                {
                    counter = true;
                }
                //hahmo hyökkää
                Console.WriteLine("Sinun vuorosi.\n");
                if (counter)
                {
                    weapon = character.Inventory[1];
                    damage = Items.DamageItems(character, weapon);
                    Console.WriteLine($"Aseesi on tällä kierroksella {Color.Apply(weapon, Color.Red)}");
                    if (Fights.CriticalStrike()) damage = (int)(damage * Fights.critAmount);
                    Console.WriteLine($"Olet juuri hyökkäämässä mutta jotain tapahtuu!\n");
                    Console.WriteLine($"{Color.Apply(human.Name, Color.Red)} on ottanut haltuun {Color.Apply("vastahyökkäys", Color.Purple)} loitsun!");
                    Console.WriteLine($"Tällä kierroksella tekemäsi hyökkäys {Color.Apply("vahingoittaa", Color.Red)} vain itseäsi..\n");
                    UI.EnterCheck();
                    Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} hyökkää aseella {Color.Apply(weapon, Color.Red)} vahingolla {Color.Apply(damage, Color.Red)} itseänsä!");
                    character.Health -= damage;
                    Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} elämäpisteet: {Color.Apply(character.Health, Color.Green)}");
                    Console.WriteLine($"Siirrytään seuraavaan kierrokseen ...\n");
                    UI.EnterCheck();
                    if (!Alive(character)) UI.GameOver(Users.UserList[0], character);
                    rotation++;
                    continue;
                }//vastaisku

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
                        Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} hyökkää loitsulla {Color.Apply(weapon, Color.Blue)} ja {Color.Apply("surmaa", Color.Red)} vihollisen {Color.Apply(human.Name, Color.Red)}!");
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
                    Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} hyökkää aseella {Color.Apply(weapon, Color.Red)} vahingolla {Color.Apply(damage, Color.Red)} vihollista {Color.Apply(human.Name, Color.Red)}!");
                    human.Health -= damage;
                    Console.WriteLine($"{Color.Apply(human.Name, Color.Red)} elämäpisteet: {Color.Apply(human.Health, Color.Green)}\n");
                    UI.EnterCheck();
                    if (!Alive(human)) break;
                }
                //vihollinen hyökkää
                Console.WriteLine($"On {Color.Apply("Velhon", Color.Red)} vuoro.\n");
                attack = human.Attack;
                if (weapon.Equals("Parantava Taika"))
                {
                    Console.WriteLine($"Vihollinen {Color.Apply(human.Name, Color.Red)} käyttää loitsun {Color.Apply(attack, Color.Green)} ja saa {Color.Apply("täydet", Color.Green)} elämäpisteet!");
                    human.Health = Enemies.HumanMaxHealth;
                    Console.WriteLine($"{Color.Apply(human.Name, Color.Red)} elämäpisteet: {Color.Apply(human.Health, Color.Green)}\n");
                    UI.EnterCheck();
                    rotation++;
                    continue;
                }
                else
                {
                    damage = human.Damage * (int)(1 + Items.SpellItems(attack));
                    Console.WriteLine($"{Color.Apply(human.Name, Color.Red)} hyökkää loitsulla {Color.Apply(attack, Color.Blue)} vahingolla {Color.Apply(damage, Color.Red)} hahmoa {Color.Apply(character.Character, Color.Blue)}!");
                    int temp = (int)damage;
                    character.Health -= temp;
                    Console.WriteLine($"{Color.Apply(character.Character, Color.Blue)} elämäpisteet: {Color.Apply(character.Health, Color.Green)}\n");
                    if (!Alive(character)) UI.GameOver(Users.UserList[0], character);
                }
                rotation++;
                UI.EnterCheck();
            }
            Console.Clear();
            Console.WriteLine($"Vihollinen 3. {Color.Apply(human.Name, Color.Red)} on {Color.Apply("surmattu", Color.Red)}\n");
            UI.EnterCheck();
        }
    }
}
