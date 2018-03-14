
// <Snippet2>
using System;
using System.Runtime;

public class ExampleClass
{
   [BypassNGen]
   public void ToJITCompile()
   {
   }
}
// </Snippet2>

// <Snippet1>
namespace System.Runtime
{
   public class BypassNGenAttribute : Attribute 
   {
   }   
}
// </Snippet1>
