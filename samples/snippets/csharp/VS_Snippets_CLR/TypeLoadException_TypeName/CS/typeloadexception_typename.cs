// System.TypeLoadException.TypeName;System.TypeLoadException.Message

/* This program demonstrates the 'TypeName' and 'Message' properties
   of the 'TypeLoadException' class. It attempts to load a 
   non-existent type from the mscorlib assembly which throws an 
   exception. This exception is caught and the TypeName and Message 
   values are displayed.
*/

// <Snippet1>
// <Snippet2>
using System;
using System.Reflection;

public class TypeLoadException_TypeName
{
   public static void Main() 
   {
      // Get a reference to the assembly mscorlib.dll, which is always
      // loaded. (System.String is defined in mscorlib.)
      Assembly mscorlib = typeof(string).Assembly;

      try 
      {
         Console.WriteLine("Attempting to load a type that does not exist in mscorlib.");
         // The boolean parameter causes an exception to be thrown if the
         // type is not found.
         Type myType = mscorlib.GetType("System.NonExistentType", true);
      }  
      catch (TypeLoadException ex) 
      {
         // Display the name of the type that was not found, and the 
         // exception message.
         Console.WriteLine("TypeLoadException was caught. Type = '{0}'.", 
             ex.TypeName);
         Console.WriteLine("Error Message = '{0}'", ex.Message);
      }  
   }
}
/*
 This code example produces output similar to the following:

Attempting to load a type that does not exist in mscorlib.
TypeLoadException was caught. Type = 'System.NonExistentType'
Error Message = 'Could not load type System.NonExistentType from assembly mscorl
ib, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b77a5c561934e089.'
 */
// </Snippet2>
// </Snippet1>
