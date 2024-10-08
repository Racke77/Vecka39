﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_2
{
    internal class AccountEdit
    {
        //method for creating all accounts at the start
        public static List<BankAccount> CreateAllAccounts(List<string> accountNames)
        {
            List<BankAccount> bankAccounts = new List<BankAccount>(); //create an array to hold all of the objects

            Random randomMoney = new Random(); //create a random amount of initial money

            //go through the entire list and create objects for each installment of the array + random money
            foreach (string accountName in accountNames)
            {
                bankAccounts.Add(new BankAccount(accountName, randomMoney.Next(100, 10001)));
            }
            return bankAccounts;
        }
        //method for editing the money on the accounts
        public static void MoneyEdits(int addRemove, string question, List<BankAccount> bankAccounts, int whichAccount)
        {
            Console.Clear();
            Console.WriteLine($"How much money do you want to {question}?");
            int moneyEdit = Input.NumberInputCatch();

            //turning a "normal number" into either positive or negative (add/remove)
            moneyEdit = (moneyEdit * addRemove);

            if (moneyEdit + bankAccounts[whichAccount].AccountMoney < 0)
            {
                Console.CursorVisible = false;
                Console.WriteLine("You don't have enough money for that.");
                Console.ReadLine();
                return;
            }
            //after checking to make sure that nothing goes wrong -> use method for changing account-money
            bankAccounts[whichAccount].SetMoney(moneyEdit);
        }
        //CREATE new account
        public static List<string> CreateNewAccount(List<BankAccount> bankAccounts, List<string> allAccountNames)
        {
            Console.WriteLine("Name for the new account: ");
            Console.CursorVisible = true;
            string accountName = Input.StringInputCatch();
            Console.WriteLine("Amount of money on the account: ");
            int accountMoney = Input.NumberInputCatch();
            Console.CursorVisible = false;

            bankAccounts.Add(new BankAccount(accountName, accountMoney));
            allAccountNames.Add(accountName);
            return allAccountNames;
        }
        //DELETE account
        public static List<string> DeleteAccount(List<string> allAccountNames, List<BankAccount> bankAccounts, int menuSelect)
        {
            Console.WriteLine();
            Console.WriteLine("Are you sure you want to delete this account?");
            Console.WriteLine("y/n: ");
            Console.CursorVisible = true;
            if (Input.YesNoInput() == true) //"yes" -> delete account
            {
                bankAccounts.RemoveAt(menuSelect);
                allAccountNames.RemoveAt(menuSelect);
            }
            else
            {
                Console.WriteLine("Deletion cancelled.");
                Console.ReadLine();
            }
            return allAccountNames;
        }
        public static List<string> EditSelectedAccount(List<BankAccount> bankAccounts, int indexNr, List<string> allAccountNames)
        {
            int menuSelected = Menu.DisplayFoundAccount(bankAccounts, indexNr);
            switch (menuSelected)
            {
                case 0: //Return
                    break;
                case 1: //Add money
                    MoneyEdits(1, "deposit", bankAccounts, indexNr);
                    break;
                case 2: //Take money
                    MoneyEdits(-1, "withdraw", bankAccounts, indexNr);
                    break;
                case 3: //Delete account
                    Console.WriteLine();
                    allAccountNames = DeleteAccount(allAccountNames, bankAccounts, indexNr);
                    break;
            }
            return allAccountNames;
        }
    }
}
