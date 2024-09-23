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
        public string AccountNr { get; private set; }
        private int accountMoney;
        public int AccountMoney { get; private set; }

        //the method which changes the money-value on a given account
        public void SetMoney(int value)
        {
            accountMoney += value;
        }
    }
    public class BankAccountJsonDto
    {
        public string? AccountNr { get; set; }
        public int AccountMoney { get; set; }
        public static BankAccount ToBankAccount(string accountNr, int accountMoney)
        {
            return new BankAccount
            {
                AccountNr = accountNr,
                AccountMoney = accountMoney
            };
        }
        public static BankAccountJsonDto FromBankAccount(BankAccount bankAccount)
        {
            return new BankAccountJsonDto
            {
                AccountNr = bankAccount.AccountNr,
                AccountMoney = bankAccount.AccountMoney
            };
        }
    }

}
