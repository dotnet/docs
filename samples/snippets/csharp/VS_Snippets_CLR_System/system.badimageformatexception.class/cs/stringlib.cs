// <Snippet2>
using System;

public class StringLib
{
   private string[] exceptionList = { "a", "an", "the", "in", "on", "of" };
   private char[] separators = { ' ' };
   
   public string ToProperCase(string title)
   {
      bool isException = false;	
      
      string[] words = title.Split( separators, StringSplitOptions.RemoveEmptyEntries);
      string[] newWords = new string[words.Length];
		
      for (int ctr = 0; ctr <= words.Length - 1; ctr++)
      {
         isException = false;

         foreach (string exception in exceptionList)
         {
            if (words[ctr].Equals(exception) && ctr > 0)
            {
               isException = true;
               break;
            }
         }
         
         if (! isException)
            newWords[ctr] = words[ctr].Substring(0, 1).ToUpper() + words[ctr].Substring(1);
         else
            newWords[ctr] = words[ctr];	 
      }	
      return String.Join(" ", newWords); 			
   }
}
// Attempting to load the StringLib.dll assembly produces the following output:
//    Unhandled Exception: System.BadImageFormatException: 
//                         The format of the file 'StringLib.dll' is invalid.
// </Snippet2>
