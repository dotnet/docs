'<Snippet1>
Imports System

Namespace DesignLibrary

   Public Class Inference

      ' This method violates the rule.
      Sub NotInferredTypeArgument(Of T)()

         Console.WriteLine(GetType(T))

      End Sub
   
      ' This method satisfies the rule.
      Sub InferredTypeArgument(Of T)(sameAsTypeParameter As T)

         Console.WriteLine(sameAsTypeParameter)

      End Sub

   End Class

   Class Test
   
      Shared Sub Main()
      
         Dim infer As New Inference()
         infer.NotInferredTypeArgument(Of Integer)()
         infer.InferredTypeArgument(3)

      End Sub

   End Class

End Namespace
'</Snippet1>
