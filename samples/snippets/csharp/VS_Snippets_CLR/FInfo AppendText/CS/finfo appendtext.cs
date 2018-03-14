// <Snippet1>
using System;
using System.IO;

class Test 
{
	
    public static void Main() 
    {
        FileInfo fi = new FileInfo(@"c:\MyTest.txt");

        // This text is added only once to the file.
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

        // This text will always be added, making the file longer over time
        // if it is not deleted.
        using (StreamWriter sw = fi.AppendText()) 
        {
            sw.WriteLine("This");
            sw.WriteLine("is Extra");
            sw.WriteLine("Text");
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
//This
//is Extra
//Text

//When you run this application a second time, you will see the following output:
//
//Hello
//And
//Welcome
//This
//is Extra
//Text
//This
//is Extra
//Text

// </Snippet1>
