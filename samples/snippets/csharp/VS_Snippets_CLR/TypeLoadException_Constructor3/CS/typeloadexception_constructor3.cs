// System.TypeLoadException.TypeLoadException

/* This program demonstrates the 'TypeLoadException(string,Exception)'
   constructor of 'TypeLoadException' class. It attempts to call a 
   non-existent method located in NonExistentDLL.dll, which will 
   throw an exception. A new exception is thrown with this exception
   as an inner exception.*/

// <Snippet1>

using System;
using System.Runtime.InteropServices;

public class TypeLoadException_Constructor3
{
   public static void Main() 
   {
      Console.WriteLine("Calling a method in a non-existent DLL which triggers a TypeLoadException.");
      try 
      {
         TypeLoadExceptionDemoClass.GenerateException();
      }  
      catch (TypeLoadException e)
      {
         Console.WriteLine ("TypeLoadException: \n\tError Message = " + e.Message);
         Console.WriteLine ("TypeLoadException: \n\tInnerException Message = " + e.InnerException.Message );
      }  
      catch (Exception e)
      {
         Console.WriteLine ("Exception: \n\tError Message = " + e.Message);
      }
   }
}

class TypeLoadExceptionDemoClass
{ 
   // A call to this method will raise a TypeLoadException.
   [DllImport("NonExistentDLL.DLL", EntryPoint="MethodNotExists")]
   public static extern void NonExistentMethod();

   public static void GenerateException() 
   {
      try 
      {
         NonExistentMethod();
      }
      catch (TypeLoadException e) 
      {
         // Rethrow exception with the exception as inner exception
         throw new TypeLoadException("This exception was raised due to a call to an invalid method.", e);
      }
   }
}
// </Snippet1>
