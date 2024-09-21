using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bankomat_2
{
    public class BankAccount
    {
        private string accountNr;
        public string AccountNr
        {
            get { return accountNr; }
        }

        private int accountMoney; //NEVER CALL THIS "moneyAccount" (Deserialize hates that)
        public int AccountMoney
        {
            get { return accountMoney; }
        }

        [JsonConstructor]
        public BankAccount(string accountNr, int accountMoney)
        {
            this.accountNr = accountNr;
            this.accountMoney = accountMoney;
        }

        //the method which changes the money-value on a given account
        public void SetMoney(int value)
        {
            accountMoney += value;
        }
    }
}
