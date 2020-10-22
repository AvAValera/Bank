using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bank
{
    class Deposit
    {
        private static double percentDeposit;

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
            var sht = new ShowText();
            string[] saveData = new string[5];
            saveData = File.ReadAllLines("deposit.txt");
            DateTime dt = new DateTime(Convert.ToInt32(saveData[0]), Convert.ToInt32(saveData[1]), Convert.ToInt32(saveData[2]), Convert.ToInt32(saveData[3]),
                Convert.ToInt32(saveData[4]), Convert.ToInt32(saveData[5]));
            TimeSpan ts = DateTime.Now - dt;
            Console.WriteLine("Deposit open time Day:{0} Time: {1}:{2}:{3:00}", ts.Days, ts.Hours, ts.Minutes, ts.Seconds);
            double moneyDeposit = Convert.ToDouble(saveData[6]);
            percentDeposit = (ts.TotalSeconds * moneyDeposit) / 1000; //10sec = 1$ if 100$ deposit
            sht.Text("Your start deposit is: " + moneyDeposit + "\n");
            //TODO: format out percent
            if(moneyDeposit > percentDeposit) sht.Text("Percent to deposit: " + ((moneyDeposit - percentDeposit).ToString("C2")) + "\n" );
            else sht.Text("Percent to deposit: " + ((percentDeposit - moneyDeposit).ToString()) + "\n" );
            Console.WriteLine("Total cash: {0:F}$", percentDeposit);
        }
        public void CloseDeposit()
        {
            if(File.Exists("deposit.txt"))
            {
               
            }
        }
    }
}
