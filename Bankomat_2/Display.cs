using Bankomat_2;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_2
{
    public class Display
    {
        //display all accounts
        public static void DisplayAllMethod(List<BankAccount> bankAccounts)
        {
            for (int i = 0; i < bankAccounts.Count; i++)
            {
                DisplaySingleMethod(bankAccounts, i);
            }
        }
        //display single account
        public static void DisplaySingleMethod(List<BankAccount> bankAccounts, int indexNr)
        {
            CultureInfo svCulture = new CultureInfo("sv-SE");

            Console.Write(bankAccounts[indexNr].AccountNr.PadRight(10) + //line-break for reading-convenience
                bankAccounts[indexNr].AccountMoney.ToString("C00", svCulture).PadLeft(20));
            Console.WriteLine();
        }
    }
}
