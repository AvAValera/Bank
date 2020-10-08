using System;

namespace Bank
{
    class MainMenu
    {
        static void Main(string[] args)
        {
            Accounting acc = new Accounting();
            
            Console.WriteLine("Welcome to the BANK");
            Console.WriteLine("1-Balance\n2-Take money\n3-Add money");

            var choise = Console.ReadLine();

            switch (choise)
            {
                case "1":
                    acc.CheckBalanse();
                    break;
                case "2":
                    Console.WriteLine("How much money?");
                    int mon = int.Parse(Console.ReadLine());
                    acc.takeMoney(mon);
                    break;
                case "3":
                    Console.WriteLine("How much add moneys in you account?");
                    int monn = int.Parse(Console.ReadLine());
                    acc.addBalance(monn);
                    break;
                default:
                    break;
            }

        }
    }
}
