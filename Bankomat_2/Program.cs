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
        }
    }
}
//Sorter? -> Sort accounts based on: ID or MONEY -> Not on this assignment (not yet)
//Display -> Show only accounts within X and Y (money) -> Basically just a sorter (not yet)
