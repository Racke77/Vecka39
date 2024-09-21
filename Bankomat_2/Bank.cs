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

            //check if the file exists
            try
            {
                loadString = System.IO.File.ReadAllText("AccountList.json");
            }
            catch
            {
                //create all bank-accounts
                allAccountNames = InitialAccountNames();
                bankAccountsInitial = AccountEdit.CreateAllAccounts(allAccountNames);
                loadString = JsonSerializer.Serialize(bankAccountsInitial);
                System.IO.File.WriteAllText("AccountList.json", loadString);
            }
            //load the file to the reset List
            List<BankAccount> bankAccounts = JsonSerializer.Deserialize<List<BankAccount>>(loadString) ?? new List<BankAccount>();

            //reset the names to match the Actual Accounts
            allAccountNames.Clear();
            for (int i = 0; i < bankAccounts.Count; i++)
            {
                allAccountNames.Add(bankAccounts[i].AccountNr);
            }

            //while-loop to stop from escaping the menu
            while (true)
            {
                int menuSelected = Menu.MenuMakerActions();
                Console.Clear();

                switch (menuSelected)
                {
                    case 0:
                        //Display all accounts
                        for (int i = 0; i < bankAccounts.Count; i++)
                        {
                            Console.Write(bankAccounts[i].AccountNr + bankAccounts[i].AccountMoney.ToString().PadLeft(20) + " SEK");
                            Console.WriteLine();
                        }
                        Console.ReadLine();
                        break;
                    case 1:
                        //View account -> open a menu for account-names -> open the account
                        menuSelected = Menu.MenuSelection(allAccountNames);
                        Console.Clear();

                        Console.Write(bankAccounts[menuSelected].AccountNr + bankAccounts[menuSelected].AccountMoney.ToString().PadLeft(20) + " SEK");
                        Console.ReadLine();
                        break;
                    case 2:
                        //Find account
                        Console.CursorVisible = true;
                        int indexNr = Search.LinearSearch(bankAccounts, Input.StringInputCatch());
                        if (indexNr < 0)
                        {
                            Console.WriteLine("There is no account by that name.");
                            Console.ReadLine();
                        }
                        else
                        {
                            //do something with it?
                            menuSelected = Menu.DisplayFoundAccount(bankAccounts, indexNr);
                            switch (menuSelected)
                            {
                                case 0: //Return
                                    break;
                                case 1: //Add money
                                    AccountEdit.MoneyEdits(1, "deposit", bankAccounts, indexNr);
                                    break;
                                case 2: //Take money
                                    AccountEdit.MoneyEdits(-1, "withdraw", bankAccounts, indexNr);
                                    break;
                                case 3: //Delete account
                                    Console.WriteLine();
                                    allAccountNames = AccountEdit.DeleteAccount(allAccountNames, bankAccounts, indexNr);
                                    break;
                            }
                        }
                        break;
                    case 3:
                        //Add to account -> open a menu for account-names (send Add)
                        AccountEdit.MoneyEdits(1, "deposit", bankAccounts, Menu.MenuSelection(allAccountNames));
                        break;
                    case 4:
                        //Remove from account -> open a menu for account-names (send Remove)
                        AccountEdit.MoneyEdits(-1, "withdraw", bankAccounts, Menu.MenuSelection(allAccountNames));
                        break;
                    case 5:
                        //Add new account -> 
                        allAccountNames = AccountEdit.CreateNewAccount(bankAccounts, allAccountNames);
                        break;
                    case 6:
                        //Delete account ->
                        allAccountNames = AccountEdit.DeleteAccount(allAccountNames, bankAccounts, Menu.MenuSelection(allAccountNames));
                        break;
                    case 7:
                        //Quit -> 
                        SaveExit.SaveAndExit(bankAccounts);
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
