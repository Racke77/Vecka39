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
        private int accountMoney;
        public int AccountMoney
        {
            get { return accountMoney; }
        }
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
    public class BankAccountJsonDto
    {
        public string AccountNr { get; set; }
        public int AccountMoney { get; set; }
        public BankAccount ToBankAccount()
        {
            return new BankAccount(AccountNr, AccountMoney)
            {

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
