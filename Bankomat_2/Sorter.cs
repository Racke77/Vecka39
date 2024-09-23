using Bankomat_2;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_Assignment
{
    public class Sorter
    {
        public static List<BankAccount> SorterMethod(List<BankAccount> bankAccounts)
        {
            CultureInfo culture = new CultureInfo("sv-SE"); //swedish localization
            List<BankAccount> bankAccountsSorted = bankAccounts.OrderByDescending(key => key, StringComparer.Create(culture, false));

            return bankAccounts;
        }
    }
}
