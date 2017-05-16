// <Snippet1>
using System;
using System.IO;

class GetAName
{
    public static void Main(string[] args)
    {
        DirectoryInfo dir = new DirectoryInfo(".");
        String dirName=dir.Name;
        Console.WriteLine("DirectoryInfo name is {0}.", dirName);
    }
}
// </Snippet1>