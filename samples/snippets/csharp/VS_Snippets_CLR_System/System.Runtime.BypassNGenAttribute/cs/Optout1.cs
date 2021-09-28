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
   [AttributeUsage(AttributeTargets.Method |
                   AttributeTargets.Constructor |
                   AttributeTargets.Property)]
   public class BypassNGenAttribute : Attribute
   {
   }
}
// </Snippet1>
