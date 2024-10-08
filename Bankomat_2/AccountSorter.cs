﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_2
{
    public class AccountSorter
    {
        public static List<BankAccount> SortAccounts(List<BankAccount> bankAccounts)
        {
            CultureInfo svCulture = new CultureInfo("sv-SE"); //set the culture (for sorting å-ä-ö)

            //create a new BankAccount-list -> Fill it with the sorted list
            var sortedList = bankAccounts.OrderBy(x => x.AccountNr, StringComparer.Create(svCulture, false)).ToList();
            Console.WriteLine("The list of accounts is now sorted from (a -> z)");
            Console.ReadLine();
            return sortedList;
        }
    }
}
