// CatchNonClsCompliantException.cs
using System;

namespace SecurityLibrary
{
   class HandlesExceptions
   {
      void CatchAllExceptions()
      {
         try
         {
            ThrowsExceptions.ThrowNonClsException();
         }
         catch(Exception e)
         {
            // Remove some permission.
            Console.WriteLine("CLS compliant exception caught");
         }
         catch
         {
            // Remove the same permission as above.
            Console.WriteLine("Non-CLS compliant exception caught.");
         }
      }

      static void Main()
      {
         HandlesExceptions handleExceptions = new HandlesExceptions();
         handleExceptions.CatchAllExceptions();
      }
   }
}