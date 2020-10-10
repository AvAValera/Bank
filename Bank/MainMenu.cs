using System;

namespace Bank
{
    class MainMenu
    {
        static void Main(string[] args)
        {
            while (true)
            {
                MainMenu.MenuBank();
            }
        }

        static void MenuBank()
        {
            var shtext = new ShowText();
            Accounting acc = new Accounting();
            var dep = new Deposit();
               
            shtext.Text("Welcome to the BANK\n");
            shtext.Text("1-Balance\n2-Take money\n3-Add money\n4-Deposit\n");

            var choise = Console.ReadLine();

            switch (choise)
            {
                case "1":
                    acc.CheckBalanse();
                    break;
                case "2":
                    shtext.Text("How much money?");
                    int mon = int.Parse(Console.ReadLine());
                    acc.takeMoney(mon);
                    break;
                case "3":
                    shtext.Text("How much add moneys in you account?\n");
                    int monn = int.Parse(Console.ReadLine());
                    acc.addBalance(monn);
                    shtext.Text($"On You balanse add is {monn}$\n");
                    shtext.ReturnMenu();
                    break;
                    
                case "4":
                    shtext.Text("Deposit menu\n");
                    shtext.Text("1-Open deposit\n2-Close deposit\n3-Check deposit\n4-Main menu\n");
                    var choiseDep = Console.ReadLine();
                    switch (choiseDep)
                    {
                        case "1":
                            var _checdata = new CheckingDataFile();
                            _checdata.CheckFileDeposit();
                            if (CheckingDataFile.EnableDeposit == true) break;
                            shtext.Text("Conditions Deposit : (6 %)Six percent in minute\n");
                            shtext.Text("Enter quantity put down on your deposit.\n");
                            var money = Convert.ToDouble(Console.ReadLine());
                            dep.OpenDeposit(money);
                            acc.takeMoney(money);
                            shtext.ReturnMenu();
                            break;
                            
                        case "2":
                            shtext.Text("If you sure press \"y\" key or another key to return\n");
                            var enterChoice = Console.ReadKey();
                            if (enterChoice.Key == ConsoleKey.Y)
                            {
                                dep.CloseDeposit();
                            }
                            break;
                        case "3":
                            dep.CheckDeposit();
                            shtext.ReturnMenu();
                            break;
                        case "4":
                            break;
                            
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
