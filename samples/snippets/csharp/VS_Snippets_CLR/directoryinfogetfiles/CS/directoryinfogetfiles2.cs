// <snippet2>
using System;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\tomfitz\Documents\ExampleDir");
            Console.WriteLine("No search pattern returns:");
            foreach (var fi in di.GetFiles())
            {
                Console.WriteLine(fi.Name);
            }

            Console.WriteLine();

            Console.WriteLine("Search pattern *2* returns:");
            foreach (var fi in di.GetFiles("*2*"))
            {
                Console.WriteLine(fi.Name);
            }

            Console.WriteLine();

            Console.WriteLine("Search pattern test?.txt returns:");
            foreach (var fi in di.GetFiles("test?.txt"))
            {
                Console.WriteLine(fi.Name);
            }

            Console.WriteLine();

            Console.WriteLine("Search pattern AllDirectories returns:");
            foreach (var fi in di.GetFiles("*", SearchOption.AllDirectories))
            {
                Console.WriteLine(fi.Name);
            }
        }
    }
}
/* 
This code produces output similar to the following:

No search pattern returns:
log1.txt
log2.txt
test1.txt
test2.txt
test3.txt

Search pattern *2* returns:
log2.txt
test2.txt

Search pattern test?.txt returns:
test1.txt
test2.txt
test3.txt

Search pattern AllDirectories returns:
log1.txt
log2.txt
test1.txt
test2.txt
test3.txt
SubFile.txt
Press any key to continue . . .

*/
// </snippet2>