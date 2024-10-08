﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;

namespace Bankomat_2
{
    public class Bank
    {
        public static void TheBank()
        {
            List<string> allAccountNames = new List<string>();
            List<BankAccount> bankAccounts = new List<BankAccount>();
            string fileName = "AccountList";

            if (File.Exists(@$"{fileName}.json")) //check if the file exists
            {
                bankAccounts = MyJsonWriter.LoadFromFile(fileName); //load from file
                foreach (var bankAccount in bankAccounts) //update account-names to fit loaded list
                {
                    allAccountNames.Add(bankAccount.AccountNr);
                }
            }
            else //otherwise create all bank-accounts
            {                
                allAccountNames = InitialAccountNames();
                bankAccounts = AccountEdit.CreateAllAccounts(allAccountNames);     
            }
                        
            while (true) //while-loop to stop from escaping the menu
            {
                int menuSelected = Menu.MenuMakerActions();
                Console.Clear();

                switch (menuSelected)
                {
                    case 0: //Display all accounts
                        Display.DisplayAllMethod(bankAccounts);
                        Console.ReadLine();
                        break;
                    case 1: //View account -> open a menu for account-names -> open the account
                        menuSelected = Menu.MenuSelection(allAccountNames);
                        allAccountNames = AccountEdit.EditSelectedAccount(bankAccounts, menuSelected, allAccountNames);
                        break;
                    case 2: //Find account
                        Console.CursorVisible = true;
                        int indexNr = Search.LinearSearch(bankAccounts, Input.StringInputCatch());
                        if (indexNr < 0)
                        {
                            Console.WriteLine("There is no account by that name.");
                            Console.ReadLine();
                        }
                        else //do something with it?
                        {                            
                            allAccountNames = AccountEdit.EditSelectedAccount(bankAccounts, indexNr, allAccountNames);
                        }
                        break;
                    case 3: //Add to account -> open a menu for account-names (send Add)
                        AccountEdit.MoneyEdits(1, "deposit", bankAccounts, Menu.MenuSelection(allAccountNames));
                        break;
                    case 4: //Remove from account -> open a menu for account-names (send Remove)
                        AccountEdit.MoneyEdits(-1, "withdraw", bankAccounts, Menu.MenuSelection(allAccountNames));
                        break;
                    case 5: //Sort accounts
                        bankAccounts = AccountSorter.SortAccounts(bankAccounts);
                        break;
                    case 6: //Add new account -> 
                        allAccountNames = AccountEdit.CreateNewAccount(bankAccounts, allAccountNames);
                        break;
                    case 7: //Delete account ->
                        allAccountNames = AccountEdit.DeleteAccount(allAccountNames, bankAccounts, Menu.MenuSelection(allAccountNames));
                        break;
                    case 8: //Quit -> 
                        MyJsonWriter.WriteToFile(bankAccounts, fileName);
                        Environment.Exit(1);
                        break;
                }
            }
        }
        public static List<string> InitialAccountNames()
        {
            //create the bank account names
            List<string> accountNames = new List<string>()
            {
                "100010", "100011", "100012", "100013", "100014", "100015", "100016", "100017", "100018", "100019"
            };
            return accountNames;
        }
    }
}
