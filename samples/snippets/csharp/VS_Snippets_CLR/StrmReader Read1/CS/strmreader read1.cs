// <Snippet1>
using System;
using System.IO;

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

            using (StreamWriter sw = new StreamWriter(path)) 
            {
                sw.WriteLine("This");
                sw.WriteLine("is some text");
                sw.WriteLine("to test");
                sw.WriteLine("Reading");
            }

            using (StreamReader sr = new StreamReader(path)) 
            {
                while (sr.Peek() >= 0) 
                {
                    Console.Write((char)sr.Read());
                }
            }
        } 
        catch (Exception e) 
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
    }
}
// </Snippet1>
