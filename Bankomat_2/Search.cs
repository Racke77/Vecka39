using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_2
{
    public class Search
    {
        public static int LinearSearch(List<BankAccount> bankAccounts, string accountName)
        {
            //go through the entire list, if the name is found -> return index-value, otherwise return -1
            for (int i = 0; i < bankAccounts.Count; i++)
            {
                if (bankAccounts[i].AccountNr == accountName)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
