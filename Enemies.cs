
namespace ConsoleApp1
{
    abstract class Enemies
    {   //vihollis ominaisuudet ja attribuutit
        private string? _name;
        private int _health;
        private int _damage;
        private static int _heal; //skeleton viholliselle
        private string? _attack;
        private string? _attack2;
        private string? _attack3;
        private string? _attack4;
        private static int _dragonMaxHealth;//erikois
        private static int _humanMaxHealth;//erikois

        protected static Random random = new Random();

        internal string? Name
        {
            get => _name;
            set => _name = value;
        }
        internal int Health
        {
            get => _health;
            set => _health = value;
        }
        internal int Damage
        {
            get => _damage;
            set => _damage = value;
        }
        internal static int Heal
        {
            get => _heal;
            set => _heal = value;
        }//skeleton
        internal string? Attack
        {
            get => _attack;
            set => _attack = value;
        }
        internal string? Attack2
        {
            get => _attack2;
            set => _attack2 = value;
        }
        internal string? Attack3
        {
            get => _attack3;
            set => _attack3 = value;
        }
        internal string? Attack4
        {
            get => _attack4;
            set => _attack4 = value;
        }
        internal static int DragonMaxHealth
        {
            get => _dragonMaxHealth;
            set => _dragonMaxHealth = value;
        }
        internal static int HumanMaxHealth
        {
            get => _humanMaxHealth;
            set => _humanMaxHealth = value;
        }


        internal static string EnemyAttack(BigRat bigrat)
        {
            Random random = new Random();
            int randNum = random.Next(1, 4);
            string? attack;
            switch (randNum)
            {
                case 1:
                    attack = bigrat.Attack;
                    break;
                case 2:
                    attack = bigrat.Attack2;
                    break;
                case 3:
                    attack = bigrat.Attack3;
                    break;
                default:
                    attack = "";
                    break;
            }
            if (attack == null)
            {
                attack = string.Empty;
            }
            return attack;
        }
        internal static string EnemyAttack(Goblin goblin)
        {
            Random random = new Random();
            int randNum = random.Next(1, 4);
            string? attack;
            
            switch (randNum)
            {
                case 1:
                    attack = goblin.Attack;
                    break;
                case 2:
                    attack = goblin.Attack2;
                    break;
                case 3:
                    attack = goblin.Attack3;
                    break;
                default:
                    attack = "";
                    break;
            }
            if (attack == null)
            {
                attack = string.Empty;
            }
            return attack;
        }

        internal static string EnemyAttack(HalfEatenSkeleton skeleton)
        {
            Random random = new Random();
            int randNum = random.Next(1, 4);
            string? attack;
            switch (randNum)
            {
                case 1:
                    attack = skeleton.Attack;
                    break;
                case 2:
                    attack = skeleton.Attack2;
                    break;
                case 3:
                    attack = skeleton.Attack3;
                    break;
                default:
                    attack = "";
                    break;
            }
            if (attack == null)
            {
                attack = string.Empty;
            }
            return attack;
        }
        internal static string EnemyAttack(RottenZombie zombie)
        {
            Random random = new Random();
            int randNum = random.Next(1, 4);
            string? attack;
            switch (randNum)
            {
                case 1:
                    attack = zombie.Attack;
                    break;
                case 2:
                    attack = zombie.Attack2;
                    break;
                case 3:
                    attack = zombie.Attack3;
                    break;
                default:
                    attack = "";
                    break;
            }
            if (attack == null)
            {
                attack = string.Empty;
            }
            return attack;
        }
    }
    class BigRat : Enemies
    {
        public BigRat(int health, int damage) 
        {
            this.Name = "Jätti Rotta";
            this.Health = health;
            this.Damage = damage;
            this.Attack = "Pureminen";
            this.Attack2 = "Häntä isku";
            this.Attack3 = "Piiloutuminen"; //invisibility
        }
    }//1. vihollinen
    class Goblin : Enemies
    {
        public Goblin(int health, int damage)
        {
            this.Name = "Peikko";
            this.Health = health;
            this.Damage = damage;
            this.Attack = "Tikari isku";
            this.Attack2 = "Sala hyökkäys";//bleed
            this.Attack3 = "Puukotus";
        }
    }//2. vihollinen
    class HumanSourceress : Enemies //hyökkää vain loitsuilla
    {
        public HumanSourceress(int health, int damage)
        {
            this.Name = "Velho";
            this.Health = health;
            this.Damage = damage;
            this.Attack = HumanRand(Items.HumanSpells.Count);
            HumanMaxHealth = health;
        }
        public static string HumanRand(int number)
        {
            int randNum = random.Next(number);
            string attack = Items.HumanSpells[randNum];
            return attack;
        }
    }//3. vihollinen
    class HalfEatenSkeleton : Enemies
    {
        public HalfEatenSkeleton(int health, int damage)
        {
            Name = "Puoliksi Syöty Luuranko";
            this.Health = health;
            this.Damage = damage;
            this.Attack = "Luu isku";
            this.Attack2 = "Luu tuho";
            this.Attack3 = "Pääkallo rusennus";//stun
            Heal = 10;
        }
    }//4. vihollinen
    class RottenZombie : Enemies
    {
        public RottenZombie(int health, int damage)
        {
            this.Name = "Mädäntynyt Zombi";
            this.Health = health;   //-100 asti
            this.Damage = damage;
            this.Attack = "Mätä puraisu";
            this.Attack2 = "Aivo kolistus";
            this.Attack3 = "Myrkky sylky";
        }
    }//5. vihollinen
    class DragonBoss : Enemies
    {
        public DragonBoss(int health, int damage)
        {
            this.Name = "Lohikäärme";
            this.Health = health;
            this.Damage = damage;
            this.Attack = "Tulinen hengitys";
            this.Attack2 = "Kynsi isku";
            this.Attack3 = "Liito korkealle";
            this.Attack4 = "Karjunta";
            DragonMaxHealth = health;
        }
    }//Viimeinen  päävihollinen
}
