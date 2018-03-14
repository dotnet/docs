// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      string value;
      bool toDelete = false;
      
      // Check whether the environment variable exists.
      value = Environment.GetEnvironmentVariable("Test1");
      // If necessary, create it.
      if (value == null) {
         Environment.SetEnvironmentVariable("Test1", "Value1");
         toDelete = true;
         
         // Now retrieve it.
         value = Environment.GetEnvironmentVariable("Test1");
      }
      // Display the value.
      Console.WriteLine("Test1: {0}\n", value);
      
      // Confirm that the value can only be retrieved from the process
      // environment block.
      Console.WriteLine("Attempting to retrieve Test1 from:");
      foreach (EnvironmentVariableTarget enumValue in 
                         Enum.GetValues(typeof(EnvironmentVariableTarget))) {
         value = Environment.GetEnvironmentVariable("Test1", enumValue);
         Console.WriteLine("   {0}: {1}", enumValue, 
                           value != null ? value : "not found");
      }
      Console.WriteLine();
      
      // If we've created it, now delete it.
      if (toDelete) { 
         Environment.SetEnvironmentVariable("Test1", null);
         // Confirm the deletion.
         if (Environment.GetEnvironmentVariable("Test1") == null)
            Console.WriteLine("Test1 has been deleted.");
      }         
   }
}
// The example displays the following output:
//       Test1: Value1
//       
//       Attempting to retrieve Test1 from:
//          Process: Value1
//          User: not found
//          Machine: not found
//       
//       Test1 has been deleted.
// </Snippet2>
