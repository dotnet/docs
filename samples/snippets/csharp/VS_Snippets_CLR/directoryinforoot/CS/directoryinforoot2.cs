// <snippet2>
using System;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo di1 = new DirectoryInfo(@"\\tempshare\tempdir");
            DirectoryInfo di2 = new DirectoryInfo("tempdir");
            DirectoryInfo di3 = new DirectoryInfo(@"x:\tempdir");
            DirectoryInfo di4 = new DirectoryInfo(@"c:\");
            
            Console.WriteLine("The root path of '{0}' is '{1}'", di1.FullName, di1.Root);
            Console.WriteLine("The root path of '{0}' is '{1}'", di2.FullName, di2.Root);
            Console.WriteLine("The root path of '{0}' is '{1}'", di3.FullName, di3.Root);
            Console.WriteLine("The root path of '{0}' is '{1}'", di4.FullName, di4.Root);
        }
    }
}
/* 
This code produces output similar to the following:

The root path of '\\tempshare\tempdir' is '\\tempshare\tempdir'
The root path of 'c:\Projects\ConsoleApplication1\ConsoleApplication1\bin\Debug\tempdir' is 'c:\'
The root path of 'x:\tempdir' is 'x:\'
The root path of 'c:\' is 'c:\'
Press any key to continue . . .

*/

// </snippet2>