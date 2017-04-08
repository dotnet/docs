using System;
using System.IO;

class Example
{
    static void Main()
    {
// <Snippet1>
string curFile = @"c:\temp\test.txt";
Console.WriteLine(File.Exists(curFile) ? "File exists." : "File does not exist.");
// </Snippet1>  
    }
}
