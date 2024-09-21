namespace Bankomat_2
{
    public class Menu
    {
        public static int MenuMakerActions()
        {
            List<string> actionOptions = new List<string>()
            {
                "Display all", "View account", "Deposit to account", "Withdraw from account", "Add new account", "Delete account", "Quit"
            };
            return MenuSelection(actionOptions);
        }
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
                    //printing out the selected menu
                    if (i == menuSelect)
                    {
                        Console.WriteLine(menuOptions[menuSelect] + " <---");
                    }
                    //printing out all other options
                    else
                    {
                        Console.WriteLine(menuOptions[i]);
                    }
                }
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
    }
}