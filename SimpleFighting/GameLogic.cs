using System;
using System.Collections.Generic;
using System.Text;

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
        }
        private BaseFighter FighterCreator()
        {
            BaseFighter fighter;
            Console.WriteLine("Введите имя игрока:");
            string playerName = Console.ReadLine();
            Console.WriteLine("\nВыберите класс героя: \n 1.Воин \n 2.Проныра \n 3.Маг");
            fighter = HeroTypeChoicer();            
            for (int skillPoints = 5; skillPoints>0;skillPoints--)
            {

            }
        }
        //cohice type of selected hero and in case is input incorrect starts loop until received correct type of hero
        private static BaseFighter HeroTypeChoicer ()
        {
            int heroType = Convert.ToInt32(Console.ReadLine());
            switch (heroType)
            {
                case 1:
                    return new Warrior();
                case 2:
                    return new Dexterous();
                case 3:
                    return new Wizard();
                default:
                    Console.WriteLine("Неверный ввод");
                    HeroTypeChoicer();
                    break;
            }
            return new Warrior();
        }
    }
}
