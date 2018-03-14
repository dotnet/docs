/*
   Supporting file for AssemblyBuilder_DefineUnmanagedResource2.cs
   Note : Calls  EmitClass class from 'MyEmitTestAssembly.dll' using reflection emit.
*/

using System;

public class MyAssemblyResourceApplication 
{
   public static void Main() 
   {
      try
      {
         CallEmitMethod();
      }
      catch(TypeLoadException)
      {
         Console.WriteLine("Unable to load EmitClass type " +
            "from MyEmitTestAssembly.dll!");
      }
   }

   private static void CallEmitMethod()
   {
      EmitClass myEmit = new EmitClass();
      Console.WriteLine(myEmit.Display());
   }
}