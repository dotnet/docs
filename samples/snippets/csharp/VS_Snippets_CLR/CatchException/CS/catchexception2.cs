//<snippet3>
using System;
using System.IO;

public class ProcessFile
{
    public static void Main()
    {
        try
        {
            StreamReader sr = File.OpenText("data.txt");
            Console.WriteLine("The first line of this file is {0}", sr.ReadLine());
	    sr.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred: '{0}'", e);
        }
    }
}
//</snippet3>
