using System;

namespace SimpleFighting
{
    public abstract class BaseFighter
    {
        protected Random rnd; //variaty number generator
        public event Action PlayerDead;
        public string Name { get; private set; }
        public string HeroDescription { get; private set; }
        public string UltAbilityDescription { get; private set; }

        private int strength;
        public int Strength
        {
            get { return strength; }
            set
            {
                strength = value;
                Damage = value * Constants.damageMultiplier;
            }
        }
        public int Damage { get; private set; }

        private int agility;
        public int Agility 
        {
            get { return agility; }
            set
            {
                agility = value;
                DodgeChance = value * Constants.dodgeMultiplier;
            }
        }
        public int DodgeChance { get; private set; }

        private int vitality;
        public int Vitality
        {
            get { return vitality; }
            set
            {
                vitality = value;
                HealthPoints = value * Constants.hpMultiplier;
            }
        }
        private int healthPoints;
        public int HealthPoints 
        {
            get  { return healthPoints; }
            set
            {
                if (value <= 0)
                    if(PlayerDead!=null)
                    PlayerDead();
                else healthPoints = value;
            }
        }
        protected BaseFighter (string name,string heroDescription, string ultAbilityDescription, int strength, int agility, int vitality)
        {
            rnd = new Random();
            Name = name;
            HeroDescription = heroDescription;
            UltAbilityDescription = ultAbilityDescription;
            Strength = strength;
            Agility = agility;
            Vitality = vitality;
        }
        public int Kick ()
        {
            int kickDamage= rnd.Next(Damage - Constants.damageVariety, Damage + 1);
            Console.WriteLine("{0} наносит удар и отнимает {1} очков здоровья",this.Name,kickDamage);
            return kickDamage;
            
        }
        public abstract int UltAbilittyUsing();
        public override string ToString()
        {
            return $"Имя:{Name}\n Сила:{Strength}\t\t Ловкость:{Agility}\t\t Живучесть:{Vitality}\n Урон:{Damage} \t Шанс увернуться: {DodgeChance}% \t HP:{HealthPoints}\n Умение:{UltAbilityDescription}";
        }

    }
}
