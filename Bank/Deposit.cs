using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bank
{
    class Deposit
    {
        private static double percentDeposit;
        public void OpenDeposit(double money)
        {
            if (!File.Exists("deposit.txt"))
            {
                using (File.Create("deposit.txt"));
            }
            FileInfo file = new FileInfo("deposit.txt");

            DateTime data = DateTime.Now;
            if (file.Length != 0)
            {
                Console.WriteLine("Deposit now open!");
                return;
            }
            else
            {
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
        }

        public void CheckDeposit()
        {
            string[] saveData = new string[5];
            saveData = File.ReadAllLines("deposit.txt");
            DateTime dt = new DateTime(Convert.ToInt32(saveData[0]), Convert.ToInt32(saveData[1]), Convert.ToInt32(saveData[2]), Convert.ToInt32(saveData[3]),
                Convert.ToInt32(saveData[4]), Convert.ToInt32(saveData[5]));
            TimeSpan ts = DateTime.Now - dt;
            Console.WriteLine($"Dposit open time {ts}");
            double moneyDeposit = Convert.ToDouble(saveData[6]);
            percentDeposit = (ts.TotalSeconds * moneyDeposit) / 1000; //10sec = 1$ if 100$ deposit
        }
        public void CloseDeposit()
        {
            if(File.Exists("deposit.txt"))
            {
               
            }
        }
    }
}
