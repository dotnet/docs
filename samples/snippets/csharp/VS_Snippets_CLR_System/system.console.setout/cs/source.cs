using System;
using System.IO;

class SetOutSample
{
    public static void Main()
    {
        try {
// <Snippet1>
            Console.WriteLine("Hello World");
            FileStream fs = new FileStream("Test.txt", FileMode.Create);
            // First, save the standard output.
            TextWriter tmp = Console.Out;
            StreamWriter sw = new StreamWriter(fs);
            Console.SetOut(sw);
            Console.WriteLine("Hello file");
            Console.SetOut(tmp);
            Console.WriteLine("Hello World");
            sw.Close();
// </Snippet1>
        } 
        catch (Exception ex)
        {
			Console.WriteLine(ex.Message);
			Console.WriteLine(ex.StackTrace);
		  }
	}
}