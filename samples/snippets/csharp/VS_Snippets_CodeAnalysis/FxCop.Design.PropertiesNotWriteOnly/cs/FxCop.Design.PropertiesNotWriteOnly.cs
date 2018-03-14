//<Snippet1>
using System;

namespace DesignLibrary
{
   public class BadClassWithWriteOnlyProperty
   {
      string someName;

      // Violates rule PropertiesShouldNotBeWriteOnly.
      public string Name 
      { 
         set 
         { 
            someName = value; 
         } 
      }
   }

   public class GoodClassWithReadWriteProperty
   {
      string someName;

      public string Name 
      { 
         get 
         { 
            return someName; 
         } 
         set 
         { 
            someName = value; 
         } 
      }
   }
}
//</Snippet1>
