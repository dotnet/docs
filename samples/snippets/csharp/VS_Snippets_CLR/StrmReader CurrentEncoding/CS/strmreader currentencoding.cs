// <Snippet1>
using System;
using System.IO;
using System.Text;

class Test 
{
	
    public static void Main() 
    {
        string path = @"c:\temp\MyTest.txt";

        try 
        {
            if (File.Exists(path)) 
            {
                File.Delete(path);
            }

            //Use an encoding other than the default (UTF8).
            using (StreamWriter sw = new StreamWriter(path, false, new UnicodeEncoding())) 
            {
                sw.WriteLine("This");
                sw.WriteLine("is some text");
                sw.WriteLine("to test");
                sw.WriteLine("Reading");
            }

            using (StreamReader sr = new StreamReader(path, true)) 
            {
                while (sr.Peek() >= 0) 
                {
                    Console.Write((char)sr.Read());
                }

                //Test for the encoding after reading, or at least
                //after the first read.
                Console.WriteLine("The encoding used was {0}.", sr.CurrentEncoding);
                Console.WriteLine();
            }
        } 
        catch (Exception e) 
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
    }
}
// </Snippet1>
