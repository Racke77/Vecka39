using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_2
{
    internal class Input
    {
        public static int NumberInputCatch() //method for try-catching int-inputs
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
        public static string StringInputCatch() //method for checking string-length
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
                    Console.WriteLine($"Please make your account-name at least {nameLength} characters long.");
                }
            }
        }
        public static bool YesNoInput() //input yes/no bool
        {
            Console.CursorVisible = true;
            if (Console.ReadLine() == "y" || Console.ReadLine() == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
