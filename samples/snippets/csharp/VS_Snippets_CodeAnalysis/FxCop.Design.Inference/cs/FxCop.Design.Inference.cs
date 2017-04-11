//<Snippet1>
using System;

namespace DesignLibrary
{
   public class Inference
   {
      // This method violates the rule.
      public void NotInferredTypeArgument<T>()
      {
         Console.WriteLine(typeof(T));
      }

      // This method satisfies the rule.
      public void InferredTypeArgument<T>(T sameAsTypeParameter)
      {
         Console.WriteLine(sameAsTypeParameter);
      }
   }

   class Test
   {
      static void Main()
      {
         Inference infer = new Inference();
         infer.NotInferredTypeArgument<int>();
         infer.InferredTypeArgument(3);
      }
   }
}
//</Snippet1>
