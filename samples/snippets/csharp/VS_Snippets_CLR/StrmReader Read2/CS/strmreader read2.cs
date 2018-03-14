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
                //This is an arbitrary size for this example.
                char[] c = null;

                while (sr.Peek() >= 0) 
                {
                    c = new char[5];
                    sr.Read(c, 0, c.Length);
                    //The output will look odd, because
                    //only five characters are read at a time.
                    Console.WriteLine(c);
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
