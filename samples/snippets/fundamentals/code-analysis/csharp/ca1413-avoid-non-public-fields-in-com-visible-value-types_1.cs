using System;
using System.Runtime.InteropServices;

[assembly: ComVisible(false)]
namespace InteroperabilityLibrary
{
   [ComVisible(true)]
   public struct SomeStruct
   {
      internal int SomeValue;
   }
}