using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bankomat_2
{
    public class Bank
    {
        public static void TheBank()
        {
            List<BankAccount> bankAccountsInitial = new List<BankAccount>();
            List<string> allAccountNames = new List<string>();
            string loadString;
            string fileName = "AccountList";

            if (File.Exists(@$"{fileName}.json")) //check if the file exists
            {
                loadString = MyJsonWriter.LoadFromFile(fileName);
            }
            else //otherwise create all bank-accounts
            {                
                allAccountNames = InitialAccountNames();
                bankAccountsInitial = AccountEdit.CreateAllAccounts(allAccountNames);                
                loadString = MyJsonWriter.WriteToFile(bankAccountsInitial, fileName);
            }
            //load the file to the reset List
            List<BankAccount> bankAccounts = JsonSerializer.Deserialize<List<BankAccount>>(loadString) ?? new List<BankAccount>();

            //reset the names to match the Actual Accounts
            allAccountNames.Clear();
            for (int i = 0; i < bankAccounts.Count; i++)
            {
                allAccountNames.Add(bankAccounts[i].AccountNr);
            }
                        
            while (true) //while-loop to stop from escaping the menu
            {
                int menuSelected = Menu.MenuMakerActions();
                Console.Clear();

                switch (menuSelected)
                {
                    case 0: //Display all accounts
                        for (int i = 0; i < bankAccounts.Count; i++)
                        {
                            Console.Write(bankAccounts[i].AccountNr + bankAccounts[i].AccountMoney.ToString().PadLeft(20) + " SEK");
                            Console.WriteLine();
                        }
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
                    case 5: //Add new account -> 
                        allAccountNames = AccountEdit.CreateNewAccount(bankAccounts, allAccountNames);
                        break;
                    case 6: //Delete account ->
                        allAccountNames = AccountEdit.DeleteAccount(allAccountNames, bankAccounts, Menu.MenuSelection(allAccountNames));
                        break;
                    case 7: //Quit -> 
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
