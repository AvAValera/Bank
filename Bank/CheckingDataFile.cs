using System;
using System.IO;

namespace Bank
{
    class CheckingDataFile
    {
        public void CheckFileBalance()
        {
            if (!File.Exists("balance.txt"))
            {
                using (File.Create("balance.txt"));
            }
            FileInfo fileBalance = new FileInfo("balance.txt");
            if (fileBalance.Length == 0)
            {
                using (var sw = new StreamWriter("balance.txt"))
                {
                    sw.WriteLine("100");
                }
            }
        }

        public void CheckFileDeposit()
        {
            if (!File.Exists("deposit.txt"))
            {
               using (File.Create("deposit.txt"));
            }
        }
        public bool CheckOpenDeposit()
        {
            FileInfo file = new FileInfo("deposit.txt");
            if (file.Length != 0)
            {
                var shtext = new ShowText();
                shtext.Text("Deposit now open!\n");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}