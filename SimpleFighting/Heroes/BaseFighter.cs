using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFighting
{
    public abstract class BaseFighter
    {
        protected Random rnd; //variaty number generator
        public delegate void IsDeadDelegate();
        public event IsDeadDelegate PlayerDead;
        public string Name { get; private set; }
        public string HeroDescription { get; private set; }
        public string UltAbilityDescription { get; private set; }

        private int strength;
        public int Strength
        {
            get { return strength; }
            private set
            {
                strength = value;
                Damage = value * 10;
            }
        }
        public int Damage { get; private set; }

        private int agility;
        public int Agility 
        {
            get { return agility; }
            private set
            {
                agility = value;
                DodgeChance = value * 6;
            }
        }
        public int DodgeChance { get; private set; }

        private int vitality;
        public int Vitality
        {
            get { return vitality; }
            private set
            {
                vitality = value;
                HealthPoints = value * 100;
            }
        }
        public int HealthPoints { get; private set; }
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
            return rnd.Next(Damage-10, Damage + 1);            
        }
        public abstract int UltAbilittyUsing();
        public virtual void ShowStats()
        {
            Console.WriteLine("Имя:{0}\n Сила:{1}\t\t Ловкость:{2}\t\t Живучесть:{3}\n Урон:{4} \t Шанс увернуться: {5}% \t HP:{6}\n Умение:{7}", 
                Name, Strength, Agility, Vitality, Damage, DodgeChance, HealthPoints, UltAbilityDescription);
        }

    }
}
