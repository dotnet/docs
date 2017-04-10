'<Snippet1>
Imports System
Imports System.Collections.Generic

Namespace DesignLibrary

   Public Class IntegerCollections
   
      Sub NonNestedCollection(collection As ICollection(Of Integer))
      
         For Each I As Integer In DirectCast( _ 
            collection, IEnumerable(Of Integer))

            Console.WriteLine(I)

         Next 

      End Sub

      ' This method violates the rule.
      Sub NestedCollection( _ 
         outerCollection As ICollection(Of ICollection(Of Integer)))
      
         For Each innerCollection As ICollection(Of Integer) In _ 
            DirectCast(outerCollection, _ 
                       IEnumerable(Of ICollection(Of Integer)))

            For Each I As Integer In _ 
               DirectCast(innerCollection, IEnumerable(Of Integer))

               Console.WriteLine(I)

            Next

         Next
 
      End Sub

   End Class

   Class Test
   
      Shared Sub Main()
      
         Dim collections As New IntegerCollections()

         Dim integerListA As New List(Of Integer)()
         integerListA.Add(1)
         integerListA.Add(2)
         integerListA.Add(3)

         collections.NonNestedCollection(integerListA)

         Dim integerListB As New List(Of Integer)()
         integerListB.Add(4)
         integerListB.Add(5)
         integerListB.Add(6)

         Dim integerListC As New List(Of Integer)()
         integerListC.Add(7)
         integerListC.Add(8)
         integerListC.Add(9)

         Dim nestedIntegerLists As New List(Of ICollection(Of Integer))()
         nestedIntegerLists.Add(integerListA)
         nestedIntegerLists.Add(integerListB)
         nestedIntegerLists.Add(integerListC)

         collections.NestedCollection(nestedIntegerLists)

      End Sub

   End Class

End Namespace
'</Snippet1>
