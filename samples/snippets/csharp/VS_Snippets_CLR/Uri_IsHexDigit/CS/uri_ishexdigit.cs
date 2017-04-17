/* 
   System.Uri.IsHexDigit
   
	The following program reads a string from console and determines whether the
	specified character is valid hexadecimal digit.
*/

using System;
class MyIsHexDigitSample
{
	public static void Main()
	{
		try
		{
            // <Snippet1>
			Console.Write("Type a string : ");
			string myString = Console.ReadLine();
			for (int i = 0; i < myString.Length; i ++)
               if(Uri.IsHexDigit(myString[i]))
                  Console.WriteLine("{0} is a hexadecimal digit.", myString[i]); 
               else
                  Console.WriteLine("{0} is not a hexadecimal digit.", myString[i]); 
            // The example produces output like the following:
            //    Type a string : 3f5EaZ
            //    3 is a hexadecimal digit.
            //    f is a hexadecimal digit.
            //    5 is a hexadecimal digit.
            //    E is a hexadecimal digit.
            //    a is a hexadecimal digit.
            //    Z is not a hexadecimal digit.            
            // </Snippet1>
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
	} 
}
// ***** Output *****
/*

*/