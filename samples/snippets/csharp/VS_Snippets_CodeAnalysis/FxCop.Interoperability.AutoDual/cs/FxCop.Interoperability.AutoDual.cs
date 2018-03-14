//<Snippet1>
using System;
using System.Runtime.InteropServices;

[assembly: ComVisible(true)]
namespace InteroperabilityLibrary
{
   // This violates the rule.
   [ClassInterface(ClassInterfaceType.AutoDual)]
   public class DualInterface
   {
      public void SomeMethod() {}
   }

   public interface IExplicitInterface
   {
      void SomeMethod();
   }

   [ClassInterface(ClassInterfaceType.None)]
   public class ExplicitInterface : IExplicitInterface
   {
      public void SomeMethod() {}
   }
}
//</Snippet1>
