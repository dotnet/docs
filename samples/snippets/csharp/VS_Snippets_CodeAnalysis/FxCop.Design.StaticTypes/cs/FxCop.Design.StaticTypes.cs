//<Snippet1>
using System;

namespace DesignLibrary
{
   public class NoInstancesNeeded
   {
      // Violates rule: StaticHolderTypesShouldNotHaveConstructors.
      // Uncomment the following line to correct the violation.
      // private NoInstancesNeeded() {}

      public static void Method1() {}
      public static void Method2() {}
   }
}
//</Snippet1>
