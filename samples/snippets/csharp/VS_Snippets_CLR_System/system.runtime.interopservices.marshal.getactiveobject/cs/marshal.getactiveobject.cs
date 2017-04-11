//<snippet1>

using System;
using System.Runtime.InteropServices;

class MainFunction
{
    static void Main()
        {
        Console.WriteLine("\nSample: C# System.Runtime.InteropServices.Marshal.GetActiveObject.cs\n"); 

        GetObj(1, "Word.Application");
        GetObj(2, "Excel.Application");
        }

    static void GetObj(int i, String progID)
	{
        Object obj = null;

        Console.WriteLine("\n" +i+") Object obj = GetActiveObject(\"" + progID + "\")");
        try
           { obj = Marshal.GetActiveObject(progID); }
        catch (Exception e)
           {
           Write2Console("\n   Failure: obj did not get initialized\n" + 
                         "   Exception = " +e.ToString().Substring(0,43), 0); 
           }
 
        if (obj != null)
           { Write2Console("\n   Success: obj = " + obj.ToString(), 1 ); }
	}

         
    static void Write2Console(String s, int color)
        {
        Console.ForegroundColor = color == 1? ConsoleColor.Green : ConsoleColor.Red;
        Console.WriteLine(s); 
        Console.ForegroundColor = ConsoleColor.Gray;
	}
}

/*
Expected Output:

Sample: C# System.Runtime.InteropServices.Marshal.GetActiveObject.cs

1) Object obj = GetActiveObject("Word.Application")

   Success: obj = System.__ComObject

2) Object obj = GetActiveObject("Excel.Application")

   Failure: obj did not get initialized
   Exception = System.Runtime.InteropServices.COMException
*/

//</snippet1>