// <Snippet1>
using System;
using System.IO;

class Test 
{

    public static void Main() 
    {
        string path = @"c:\temp\MyTest.txt";
        FileInfo fi = new FileInfo(path);

        if (!fi.Exists) 
        {
            //Create a file to write to.
            using (StreamWriter sw = fi.CreateText()) 
            {
                sw.WriteLine("Hello");
                sw.WriteLine("And");
                sw.WriteLine("Welcome");
            }
        }

        //Open the file to read from.
        using (StreamReader sr = fi.OpenText()) 
        {
            string s = "";
            while ((s = sr.ReadLine()) != null) 
            {
                Console.WriteLine(s);
            }
        }
    }
}
//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//
//Hello
//And
//Welcome
// </Snippet1>
