//<Snippet1>
using System;

namespace DesignLibrary
{
// Violates rule: DefineAccessorsForAttributeArguments.

   [AttributeUsage(AttributeTargets.All)]
   public sealed class BadCustomAttribute :Attribute 
   {
      string data;

      // Missing the property that corresponds to 
      // the someStringData parameter.

      public BadCustomAttribute(string someStringData)
      {
         data = someStringData;
      }
   }

// Satisfies rule: Attributes should have accessors for all arguments.

   [AttributeUsage(AttributeTargets.All)]
   public sealed class GoodCustomAttribute :Attribute 
   {
      string data;

      public GoodCustomAttribute(string someStringData)
      {
         data = someStringData;
      }
      //The constructor parameter and property
      //name are the same except for case.

      public string SomeStringData
      {
         get 
         {
            return data;
         }
      }
   }
}
//</Snippet1>
