﻿using System;

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
           var acc = new Accounting(); 
           var sht = new ShowText();
           var checkDep = new CheckingDataFile();
           sht.Text("Welcome to the World Bank\n");
           sht.Text("1-Balance\n2-Take Money\n3-Deposit\n4-Exit\n");
           var choise = Console.ReadLine();

           switch (choise)
           {
               case "1" :
                   acc.CheckBalanse();
                   Console.WriteLine("Balance now {0:00}$",Accounting.balance);
                   sht.ReturnMenu();
                   break;
               case "2":
                   sht.Text("Please enter amount of money\n");
                   double money;
                   while (!double.TryParse(Console.ReadLine(), out money))
                   {
                       sht.Text("Please enter how much money!\n");
                   }
                   acc.TakeMoney(money);
                   sht.ReturnMenu();
                   break;
               case "3":
                   Console.Clear();
                   var deposit = new Deposit();
                   sht.Text("1-Open Deposit\n2-Close Deposit\n3-Check Deposit\n4-Return main menu\n");
                   string choiseDeposit = Console.ReadLine();
                   switch (choiseDeposit)
                   {
                       case "1" :
                           
                           if (checkDep.CheckOpenDeposit())
                           {
                               sht.Text("Open deposit to 6% in minute\nPlease enter sum.\n");
                               double sum;
                               while (!double.TryParse(Console.ReadLine(), out sum))
                               {
                                   sht.Text("Please enter how much money!\n");
                               }
                               deposit.OpenDeposit(sum);
                               acc.TakeMoney(sum);
                           }
                           else sht.ReturnMenu();
                           break;
                       case "2" :
                           //TODO: check open deposit or not
                           sht.Text("If you sure to close deposit press \"y\"");
                           var enterChoise = Console.ReadKey();
                           if (enterChoise.Key == ConsoleKey.Y)
                           {
                               deposit.CloseDeposit();
                           }
                           break;
                       case "3" :
                           if (checkDep.CheckCloseDeposit())
                           {
                               deposit.CheckAllAtribute();
                               sht.ReturnMenu();
                           }
                           else
                           {
                               sht.ReturnMenu();
                           }
                           break;
                       case "4":
                           sht.ReturnMenu();
                           break;
                   }
                   break;
               case "4":
                   Environment.Exit(1);
                   break;
           }

        }
    }
}
