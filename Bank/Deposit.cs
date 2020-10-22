using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bank
{
    class Deposit
    {
        private static double percentDeposit;
        private double moneyDeposit;

        public Deposit() //Check Deposit
        {
            var _checkData = new CheckingDataFile();
            _checkData.CheckFileDeposit();
        }
        
        public void OpenDeposit(double money)
        {
            DateTime data = DateTime.Now;
            using (StreamWriter sw = new StreamWriter("deposit.txt")) //save date
            {
                sw.WriteLine(data.Year);
                sw.WriteLine(data.Month);
                sw.WriteLine(data.Day);
                sw.WriteLine(data.Hour);
                sw.WriteLine(data.Minute);
                sw.WriteLine(data.Second);
                sw.WriteLine(money);
            }
        }

        public void CheckDeposit()
        {
            string[] saveData = new string[5];
            saveData = File.ReadAllLines("deposit.txt");
            DateTime dt = new DateTime(Convert.ToInt32(saveData[0]), Convert.ToInt32(saveData[1]), Convert.ToInt32(saveData[2]), Convert.ToInt32(saveData[3]),
                Convert.ToInt32(saveData[4]), Convert.ToInt32(saveData[5]));
            TimeSpan ts = DateTime.Now - dt;
            Console.WriteLine("Deposit open time Day:{0} Time: {1}:{2}:{3:00}", ts.Days, ts.Hours, ts.Minutes, ts.Seconds + "\n");
            moneyDeposit = Convert.ToDouble(saveData[6]);
            percentDeposit = (ts.TotalSeconds * moneyDeposit) / 1000; //10sec = 1$ if 100$ deposit
        }
        public void CheckAllAtribute()
        {
            CheckDeposit();
            var sht = new ShowText();
            sht.Text("Your start deposit is: " + moneyDeposit + "$\n");
            sht.Text("Percent to deposit: " + percentDeposit.ToString("0.00") + "$\n" );
            sht.Text("Total cash: " + ((moneyDeposit + percentDeposit).ToString("0.00")) + "$\n");
        }

        public void CloseDeposit()
        {
            if(File.Exists("deposit.txt") )
            {
                var _checkData = new CheckingDataFile();
                if (_checkData.CheckCloseDeposit())
                {
                    var sht = new ShowText();
                    CheckDeposit();
                    Accounting.balance += (moneyDeposit + percentDeposit);
                    using (var sw = new StreamWriter("balance.txt"))
                    {
                        sw.WriteLine(Accounting.balance);
                    }
                    File.Delete("deposit.txt");

                    
                    sht.Text("Balanse is now:" + Accounting.balance.ToString("0.00") +"$\n" );
                }
            }
        }
    }
}
