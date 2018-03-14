// <Snippet13>
using System;

[assembly: CLSCompliant(true)]

public class ErrorClass
{ 
   string msg;
   
   public ErrorClass(string errorMessage)
   {
      msg = errorMessage;
   }
   
   public string Message
   {
      get { return msg; }
   }
}

public static class StringUtilities
{
   public static string[] SplitString(this string value, int index)
   {
      if (index < 0 | index > value.Length) {
         ErrorClass badIndex = new ErrorClass("The index is not within the string.");
         throw badIndex;
      }
      string[] retVal = { value.Substring(0, index - 1), 
                          value.Substring(index) };
      return retVal;
   }
}
// Compilation produces a compiler error like the following:
//    Exceptions1.cs(26,16): error CS0155: The type caught or thrown must be derived from
//            System.Exception
// </Snippet13>

public class Example
{
   public static void Main()
   {


   }
}
