using System;
using System.Threading;

namespace Bank
{
    public class ShowText
    {
        public void Text(string text)
        {
            char[] charText = text.ToCharArray();
            for (int i = 0; i < charText.Length; i++)
            {
                Console.Write(charText[i]);
                Thread.Sleep(50);
            }
        }
    }
}