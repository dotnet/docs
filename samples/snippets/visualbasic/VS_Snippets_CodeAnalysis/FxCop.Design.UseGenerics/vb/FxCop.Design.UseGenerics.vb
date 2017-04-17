'<Snippet1>
Imports System

Namespace DesignLibrary

   Public NotInheritable Class ReferenceParameters
   
      Private Sub New()
      End Sub

      ' This method violates the rule.
      Public Shared Sub Swap( _  
         ByRef object1 As Object, ByRef object2 As Object)

         Dim temp As Object = object1
         object1 = object2
         object2 = temp

      End Sub

      ' This method satifies the rule.
      Public Shared Sub GenericSwap(Of T)( _ 
         ByRef reference1 As T, ByRef reference2 As T)
      
         Dim temp As T = reference1
         reference1 = reference2
         reference2 = temp

      End Sub

   End Class

   Class Test
   
      Shared Sub Main()
      
         Dim string1 As String = "Swap"
         Dim string2 As String = "It"

         Dim object1 As Object = DirectCast(string1, Object)
         Dim object2 As Object = DirectCast(string2, Object)
         ReferenceParameters.Swap(object1, object2)
         string1 = DirectCast(object1, String)
         string2 = DirectCast(object2, String)
         Console.WriteLine("{0} {1}", string1, string2)

         ReferenceParameters.GenericSwap(string1, string2)
         Console.WriteLine("{0} {1}", string1, string2)

      End Sub

   End Class

End Namespace
'</Snippet1>
