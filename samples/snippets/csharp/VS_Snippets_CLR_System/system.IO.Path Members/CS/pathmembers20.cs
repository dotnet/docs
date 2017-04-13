// <snippet20>
using System;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = Path.GetRandomFileName();
            Console.WriteLine("Random file name is " + result);
        }
    }
}

/*

 This code produces output similar to the following:

 Random file name is w143kxnu.idj
 Press any key to continue . . .
 
 */
// </snippet20>