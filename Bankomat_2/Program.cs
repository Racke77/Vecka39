using System.ComponentModel.Design;

namespace Bankomat_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.WriteLine("Welcome to The Bank");
            Console.ReadLine();

            Bank.TheBank();
            Console.WriteLine("Testing testing");
            Console.ReadLine();
        }
    }
}
//Sorter? -> Sort accounts based on: ID or MONEY
//Display -> Show only accounts within X and Y (money)


