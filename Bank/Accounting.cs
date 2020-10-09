using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bank
{
    class Accounting
    {
        ShowText shtext = new ShowText();
        public static int balance { get; private set; }

        public void takeMoney(int money)
        {
            operationBalance();
            using (StreamWriter sw = new StreamWriter("balance.txt"))
            {
                int totalBalance = balance - money;
                sw.WriteLine(totalBalance);
                shtext.Text($"Total balanse is: {totalBalance}\n");
            }
        }
        public void addBalance(int money)
        {
            operationBalance();
            using (StreamWriter sw = new StreamWriter("balance.txt"))
            {
                int totalBalance = money + balance;
                sw.WriteLine(totalBalance);
            }
        }
        public void CheckBalanse()
        {
            using (StreamReader sr = new StreamReader("balance.txt"))
            {
                shtext.Text($"Balanse is: " + sr.ReadLine() + "$");
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
