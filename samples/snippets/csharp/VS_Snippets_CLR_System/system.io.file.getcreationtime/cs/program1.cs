<snippet1>
using System;
using System.IO;

namespace ConsoleApplication1
{
   class Program
   {
      static void Main(string[] args)
      {
         DateTime fileCreatedDate = File.GetCreationTime(@"C:\Example\MyTest.txt");
         Console.WriteLine("file created: " + fileCreatedDate);
      }
   }
}
</snippet1>