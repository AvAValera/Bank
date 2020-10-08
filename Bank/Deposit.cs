using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bank
{
    class Deposit
    {
        public void OpenDeposit()
        {
            saveDataDeposit();
        }

        void saveDataDeposit()
        {
            FileInfo file = new FileInfo("acc.txt");

            DateTime data = DateTime.Now;
            if (file.Length != 0)
            {
                Console.WriteLine("Deposit now open");
            }
            else
            {
                using (StreamWriter sw = new StreamWriter("acc.txt"))
                {
                    sw.WriteLine(data.Year);
                    sw.WriteLine(data.Month);
                    sw.WriteLine(data.Day);
                    sw.WriteLine(data.Hour);
                    sw.WriteLine(data.Minute);
                    sw.WriteLine(data.Second);
                }
            }

        }

        public void checkDeposit(double mon)
        {
            string[] saveData = new string[5];
            saveData = File.ReadAllLines("acc.txt");
            DateTime dt = new DateTime(Convert.ToInt32(saveData[0]), Convert.ToInt32(saveData[1]), Convert.ToInt32(saveData[2]), Convert.ToInt32(saveData[3]),
                Convert.ToInt32(saveData[4]), Convert.ToInt32(saveData[5]));
            TimeSpan ts = DateTime.Now - dt;
            Console.WriteLine(ts);
            double money = 0;
            money = (ts.TotalSeconds * mon) / 1000; //10sec = 1$
            Console.WriteLine((int)money + mon);
        }
    }
}
