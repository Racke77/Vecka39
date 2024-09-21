using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bankomat_2
{
    public static class SaveExit
    {
        public static void SaveAndExit(List<BankAccount> bankAccounts )
        {
            string saveString = JsonSerializer.Serialize(bankAccounts);
            System.IO.File.WriteAllText("AccountList.json", saveString);
            Environment.Exit(1);
        }
    }
}
