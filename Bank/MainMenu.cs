using System;

namespace Bank
{
    class MainMenu
    {
        static void Main(string[] args)
        {
            var shtext = new ShowText();
            Accounting acc = new Accounting();
            var dep = new Deposit();
            dep.OpenDeposit(100);
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
                    shtext.Text("How much add moneys in you account?");
                    int monn = int.Parse(Console.ReadLine());
                    acc.addBalance(monn);
                    break;
                case "4":
                    shtext.Text("Deposit menu\n");
                    shtext.Text("1-Open deposit\n2-Close deposit\n3-Check deposit\n4-Main menu");
                    var choiseDep = Console.ReadLine();
                    switch (choiseDep)
                    {
                        case "1":
                            break;
                        case "2":
                            break;
                        case "3":
                            break;
                        case "4":
                            break;
                            
                        default:
                            break;
                    }
                    shtext.Text("Conditions Deposit : (6 %)Six percent in minute");
                    shtext.Text("Enter quantity put down on your deposit.");
                    break;
                default:
                    break;
            }

        }
    }
}
