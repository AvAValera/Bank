using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bank
{
    class Accounting
    {
        public Accounting()
        {
            var _check = new CheckingDataFile();
            _check.CheckFileBalance();
        }
        ShowText shtext = new ShowText();
        public static double balance { get; set; }

        public void takeMoney(double money)
        {
            operationBalance();
            using (StreamWriter sw = new StreamWriter("balance.txt"))
            {
                double totalBalance = balance - money;
                sw.WriteLine(totalBalance);
                shtext.Text($"Total balanse is: {totalBalance}\n");
                shtext.ReturnMenu();
            }
        }
        public void addBalance(double money)
        {
            operationBalance();
            using (StreamWriter sw = new StreamWriter("balance.txt"))
            {
                double totalBalance = money + balance;
                sw.WriteLine(totalBalance);
            }
        }
        public void CheckBalanse()
        {
            using (StreamReader sr = new StreamReader("balance.txt"))
            {
                shtext.Text($"Balanse is: " + sr.ReadLine() + "$\n");
                shtext.ReturnMenu();
            }
        }
        private void operationBalance()
        {
            using (StreamReader sr = new StreamReader("balance.txt"))
            {
                balance = Int32.Parse(sr.ReadToEnd());
            }
        }
    }
}
