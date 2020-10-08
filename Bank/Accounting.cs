using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bank
{
    class Accounting
    {
        private static int balance { get; set; }

        public void takeMoney(int money)
        {
            operationBalance();
            using (StreamWriter sw = new StreamWriter("balance.txt"))
            {
                int totalBalance = balance - money;
                sw.WriteLine(totalBalance);
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
                Console.WriteLine($"Balanse is: " + sr.ReadLine() + "$");
            }
        }
        void operationBalance()
        {
            using (StreamReader sr = new StreamReader("balance.txt"))
            {
                balance = Int32.Parse(sr.ReadToEnd());
            }
        }
    }
}
