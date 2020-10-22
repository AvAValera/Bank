using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bank
{
    class Accounting
    {
       public static double balance { get; set; }

       public Accounting() //Check Accounting
       {
           var _checkData = new CheckingDataFile();
           _checkData.CheckFileBalance();
       }
        public void CheckBalanse()
        {
            using (StreamReader sr = new StreamReader("balance.txt"))
            {
                balance = double.Parse(sr.ReadLine());
            }
        }
        public void TakeMoney(double money)
        {
            CheckBalanse();
            if (balance >= money)
            {
                double result = balance - money;
                using (var sw = new StreamWriter("balance.txt"))
                {
                    sw.WriteLine(result);
                }
            }
            else
            {
                var sht = new ShowText();
                sht.Text("On your balance, there is no required amount!\n");
                return;
            }
        }
    }
}
