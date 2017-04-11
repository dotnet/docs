// <Snippet1>
using System;
using System.IO;

class Program
{

    static void Main(string[] args)
    {
        try
        {

            //  Specify a directory name that does not exist for this demo.
            string dir = @"c:\78fe9lk";

            // If this directory does not exist, a DirectoryNotFoundException is thrown
            // when attempting to set the current directory.
            Directory.SetCurrentDirectory(dir);
        }
        catch (DirectoryNotFoundException dirEx)
        {
			// Let the user know that the directory did not exist.
            Console.WriteLine("Directory not found: " + dirEx.Message);
        }
    }
}
// </Snippet1>




