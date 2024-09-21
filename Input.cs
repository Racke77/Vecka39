using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_2
{
    internal class Input
    {
        //method for try-catching int-inputs
        public static int NumberInputCatch()
        {
            while (true)
            {
                Console.CursorVisible = true;
                try
                {
                    int x = Convert.ToInt32(Console.ReadLine());

                    if (x < 0)
                    {
                        Console.WriteLine("You can't use negative numbers");
                    }
                    else
                    {
                        return x;
                    }
                }
                catch
                {
                    Console.CursorVisible = false;
                    Console.WriteLine("Please only input numbers.");
                }
            }
        }
        public static string StringInputCatch()
        {
            int nameLength = 3;
            while (true)
            {
                string x = Console.ReadLine();
                Console.CursorVisible = true;
                if (x.Length >= nameLength)
                {
                    return x;
                }
                else
                {
                    Console.CursorVisible = false;
                    Console.WriteLine($"Please make your account-name {nameLength} characters long.");
                }
            }
        }
        public static int YesNoInput()
        {
            while (true)
            {
                Console.CursorVisible = true;
                if (Console.ReadLine() == "y" || Console.ReadLine() == "yes")
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
