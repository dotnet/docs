using System;

public class Example
{
   public static void Main()
   {
      // <Snippet1>
      AppContext.SetSwitch("Switch.AmazingLib.ThrowOnException", true);
      // </Snippet1>
   }
}


// <Snippet2>
public class AmazingLib
{
   private bool shouldThrow;

   public void PerformAnOperation()
   {
      if (!AppContext.TryGetSwitch("Switch.AmazingLib.ThrowOnException", out shouldThrow)) { 
         // This is the case where the switch value was not set by the application. 
         // The library can choose to get the value of shouldThrow by other means. 
         // If no overrides or default values are specified, the value should be 'false'. 
         // A false value implies the latest behavior.
      }

      // The library can use the value of shouldThrow to throw exceptions or not.
      if (shouldThrow) {
         // old code
      }
      else {
          // new code
      }
   }
}
// </Snippet2>
