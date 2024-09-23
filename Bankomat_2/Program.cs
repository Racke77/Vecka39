using System.ComponentModel.Design;

namespace Bankomat_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.WriteLine("Welcome to The Bank"); //splash-screen
            Console.ReadLine();

            Bank.TheBank(); //start the actual bank
        }
    }
}
