//<Snippet1>
using System;

namespace DesignLibrary
{
// Violates rule: MarkAttributesWithAttributeUsage.

   public sealed class BadCodeMaintainerAttribute :Attribute 
   {
      string developer;

      public BadCodeMaintainerAttribute(string developerName)
      {
         developer = developerName;
      }
      public string DeveloperName
      {
         get 
         {
            return developer;
         }
      }
   }
// Satisfies rule: Attributes specify AttributeUsage.

   // The attribute is valid for type-level targets.
   [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate)]
   public sealed class GoodCodeMaintainerAttribute :Attribute 
   {
      string developer;

      public GoodCodeMaintainerAttribute(string developerName)
      {
         developer = developerName;
      }
      public string DeveloperName
      {
         get 
         {
            return developer;
         }
      }
   }
}
//</Snippet1>
