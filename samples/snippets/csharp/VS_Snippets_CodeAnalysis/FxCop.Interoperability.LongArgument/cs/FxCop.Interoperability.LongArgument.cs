//<Snippet1>
using System;
using System.Runtime.InteropServices;

[assembly: ComVisible(false)]
namespace InteroperabilityLibrary
{
   [ComVisible(true)]
   public class SomeClass
   {
      public void LongArgument(long argument) {} 
   }
}
//</Snippet1>
