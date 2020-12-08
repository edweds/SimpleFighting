using System;
using SimpleFighting;

namespace SimpleFighting
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintMainMenu();
            
        }
        //Simple Console main menu printing
        static void PrintMainMenu ()
        {
            Console.Clear();
            Console.WriteLine("Игра Бои");
            Console.WriteLine();
            Console.WriteLine("1 - Начать игру");
            Console.WriteLine("2 - Правила");
            Console.WriteLine("3 - Выход");
            string selected = Console.ReadLine();
            switch(selected)
            {
                case "1": 
                        var newGame = new GameLogic();
                    newGame.StartGame();
                    break;
                case "2":
                    PrintGameRules();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Неверный ввод");
                    return;                    
            }
            //Loop calling main menu printing
            PrintMainMenu();
        }
        //This method prints Game rules in to Console
        static void PrintGameRules ()
        {
            Console.Clear();
            Console.WriteLine("Тут будут правила игры");
            new Warrior().ShowStats();
            new Wizard().ShowStats();
            new Dexterous().ShowStats();
            Console.WriteLine("Для возврата в главное меню нажмите любую клавишу");
            Console.ReadKey();
        }
    }
}
