using System;

namespace Bankomat_2
{
    public class Menu
    {
        public static int MenuMakerActions()
        {
            List<string> actionOptions = new List<string>()
            {
                "Display all", "View account", "Find account" ,"Deposit to account", "Withdraw from account", "Sort accounts", "Add new account", "Delete account", "Quit"
            };
            return MenuSelection(actionOptions);
        }
        public static int DisplayFoundAccount(List<BankAccount> bankAccounts, int indexNr)
        {
            Console.Clear();
            List<string> menuOptions = new List<string>()
            {
                "Return", "Deposit", "Withdraw", "Delete account"
            };
            return MenuSelection2(menuOptions, bankAccounts, indexNr);
        }
        //up-down menu
        public static int MenuSelection(List<string> menuOptions)
        {
            int menuSelect = 0;
            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                //printing out the full menu
                for (int i = 0; i < menuOptions.Count; i++)
                {                    
                    if (i == menuSelect) //printing out the selected menu
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(menuOptions[menuSelect]);
                    }
                    else //printing out all other options
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(menuOptions[i]);
                    }
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                var keyPressed = Console.ReadKey();

                //going down, one smaller than the full menu
                if (keyPressed.Key == ConsoleKey.DownArrow && menuSelect != menuOptions.Count - 1)
                {
                    menuSelect++;
                }
                //going up, no going higher than the starting-option
                else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelect >= 1)
                {
                    menuSelect--;
                }

                //press ENTER to send back info about which menu-option was selected
                else if (keyPressed.Key == ConsoleKey.Enter)
                {
                    return menuSelect;
                }
            }
        }
        //side-to-side menu
        public static int MenuSelection2(List<string> menuOptions, List<BankAccount> bankAccounts, int indexNr)
        {
            int menuSelect = 0;
            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine(bankAccounts[indexNr].AccountNr.PadRight(10) + bankAccounts[indexNr].AccountMoney.ToString().PadLeft(20) + " SEK");
                Console.WriteLine();
                Console.WriteLine();
                for (int i = 0; i < menuOptions.Count; i++)
                {                    
                    if (i == menuSelect) //printing out the selected menu
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(menuOptions[menuSelect] + "  ");
                    }
                    else //printing out all other options
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(menuOptions[i] + "  ");
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                var keyPressed = Console.ReadKey();
                //movement
                if (keyPressed.Key == ConsoleKey.RightArrow && menuSelect != menuOptions.Count - 1)
                {
                    menuSelect++;
                }
                else if (keyPressed.Key == ConsoleKey.LeftArrow && menuSelect >= 1)
                {
                    menuSelect--;
                }
                //select
                else if (keyPressed.Key == ConsoleKey.Enter)
                {
                    return menuSelect;
                }
            }
        }
    }
}
