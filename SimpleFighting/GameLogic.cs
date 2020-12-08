using System;
using System.Threading;
using SimpleFighting;
namespace SimpleFighting
{
    public class GameLogic
    {
        private FightStateEnums fightstate;
        private BaseFighter player1;
        private BaseFighter player2;
        private Random rnd;

        public GameLogic()
        {
            rnd = new Random();
            fightstate = FightStateEnums.NextRound;
        }
        
        public void StartGame()
        {
            Console.Clear();
            player1=FighterCreator(1);
            Console.Clear();
            player2 = FighterCreator(2);
            StartFight();
        }
        private BaseFighter FighterCreator(int playerId)
        {
            BaseFighter fighter;
            Console.WriteLine("Введите имя игрока {0}:", playerId);
            string playerName = Console.ReadLine();
            Console.WriteLine("\nВыберите класс героя: \n 1.Воин \n 2.Проныра \n 3.Маг");
            fighter = HeroTypeChoicer(playerName);
            for (int skillPoints = 5; skillPoints>0;skillPoints--)
            {
                Console.Clear();
                fighter.ShowStats();
                Console.WriteLine("\n Распределите очки умений среди характеристик персонажа\n +1 Силы - \t +10 к урону\n " +
                    "+1 Ловкости -\t +6% шанс увернуться от атаки \n +1 Живучести - +100HP \n\n Осталось очков умений: {0} \n" +
                    " 1 - +1 к Силе\n 2 - +1 к Ловкости\n 3 - +1 к Живучести",skillPoints);
                switch (Console.ReadLine())
                {
                    case "1":
                        fighter.Strength += 1;
                        break;
                    case "2":
                        fighter.Agility += 1;
                        break;
                    case "3":
                        fighter.Vitality += 1;
                        break;
                    default:
                        Console.Clear();
                        skillPoints += 1;
                        Console.WriteLine("Неверный ввод");
                        Console.WriteLine("Нажмите любую клавишу чтобы продолжить");
                        Console.ReadKey();
                        break;
                }
            }
            fighter.PlayerDead += () => fightstate = FightStateEnums.Stopped;
            return fighter;
        }
        //cohice type of selected hero and in case is input incorrect starts loop until received correct type of hero
        private static BaseFighter HeroTypeChoicer (string name)
        {
            int heroType = Convert.ToInt32(Console.ReadLine());
            switch (heroType)
            {
                case 1:
                    return new Warrior(name);
                case 2:
                    return new Dexterous(name);
                case 3:
                    return new Wizard(name);
                default:
                    Console.WriteLine("Неверный ввод");
                    HeroTypeChoicer(name);
                    break;
            }
            return new Warrior();
        }
        private void StartFight()
        {
            for (int i = 5; i > 0; i--)
            {
                Console.Clear();
                Console.WriteLine(i+"...");
                Console.ReadKey();
            }
            int round = 1;
            while(fightstate==FightStateEnums.NextRound)
            {
                Console.Clear();
                Console.WriteLine("Раунд " + round);
                DamageCalculator(player1, player2);
                DamageCalculator(player2, player1);
                Console.WriteLine();
                player1.ShowStats();
                Console.WriteLine();
                player2.ShowStats();
                round++;
                Console.WriteLine("Раунд завершен, нажмите любую клавишу для продолжения");

                Console.ReadKey();
            }
            Console.WriteLine("Бой окончен");
            Console.ReadKey();

        }
        private void DamageCalculator(BaseFighter one, BaseFighter another)
        {
            if (another.DodgeChance > rnd.Next(1, 101))
                Console.WriteLine("{0} хотел ударить, но {1} увернулся от удара", one.Name, another.Name);
            else
                another.HealthPoints -= one.Kick();
            if (another.DodgeChance > rnd.Next(25, 101))
                Console.WriteLine("{0} попытался провести суперудар, но {1} увернулся", one.Name, another.Name);
            else
                another.HealthPoints -= one.UltAbilittyUsing();
            Console.WriteLine();
        }
    }
}
