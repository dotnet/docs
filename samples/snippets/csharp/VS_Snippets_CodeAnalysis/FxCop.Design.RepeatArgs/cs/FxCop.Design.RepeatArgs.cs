//<Snippet1>
using System;

namespace DesignLibrary
{
   public class BadRepeatArguments
   {
      // Violates rule: ReplaceRepetitiveArgumentsWithParamsArray.
      public void VariableArguments(object obj1, object obj2, object obj3, object obj4) {}
      public void VariableArguments(object obj1, object obj2, object obj3, object obj4, object obj5) {}
   }

   public class GoodRepeatArguments
   {
       public void VariableArguments(object obj1) {}
       public void VariableArguments(object obj1, object obj2) {}
       public void VariableArguments(object obj1, object obj2, object obj3) {}
       public void VariableArguments(params Object[] arg) {}
   }
}
//</Snippet1>
