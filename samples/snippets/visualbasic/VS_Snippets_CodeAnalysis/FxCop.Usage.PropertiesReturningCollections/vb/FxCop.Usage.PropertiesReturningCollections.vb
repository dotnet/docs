'<Snippet1>
Imports System
Imports System.Collections

Namespace UsageLibrary

   Public Class WritableCollection
    
      Dim strings As ArrayList

      Property SomeStrings As ArrayList
         Get
            Return strings
         End Get

         ' Violates the rule.
         Set
            strings = Value
         End Set
      End Property

      Sub New()
         strings = New ArrayList( _
            New String() {"IEnumerable", "ICollection", "IList"} )
      End Sub

   End Class

   Class ViolatingVersusPreferred

      Shared Sub Main()
         Dim newCollection As New ArrayList( _
            New String() {"a", "new", "collection"} )

         ' strings is directly replaced with newCollection.
         Dim collection As New WritableCollection()
         collection.SomeStrings = newCollection

         ' newCollection is added to the cleared strings collection.
         collection.SomeStrings.Clear()
         collection.SomeStrings.AddRange(newCollection)
      End Sub

   End Class

End Namespace
'</Snippet1>
