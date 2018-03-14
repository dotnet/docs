' The following code example implements the CollectionBase class and uses that implementation to create a collection of Int16 objects.

Imports System
Imports System.Collections


Public Class Int16Collection
   Inherits CollectionBase


   Default Public Property Item(index As Integer) As Int16
      Get
         Return CType(List(index), Int16)
      End Get
      Set
         List(index) = value
      End Set
   End Property


   Public Function Add(value As Int16) As Integer
      Return List.Add(value)
   End Function 'Add

   Public Function IndexOf(value As Int16) As Integer
      Return List.IndexOf(value)
   End Function 'IndexOf


   Public Sub Insert(index As Integer, value As Int16)
      List.Insert(index, value)
   End Sub 'Insert


   Public Sub Remove(value As Int16)
      List.Remove(value)
   End Sub 'Remove


   Public Function Contains(value As Int16) As Boolean
      ' If value is not of type Int16, this will return false.
      Return List.Contains(value)
   End Function 'Contains


   Protected Overrides Sub OnInsert(index As Integer, value As Object)
      ' Insert additional code to be run only when inserting values.
   End Sub 'OnInsert


   Protected Overrides Sub OnRemove(index As Integer, value As Object)
      ' Insert additional code to be run only when removing values.
   End Sub 'OnRemove


   Protected Overrides Sub OnSet(index As Integer, oldValue As Object, newValue As Object)
      ' Insert additional code to be run only when setting values.
   End Sub 'OnSet


   Protected Overrides Sub OnValidate(value As Object)
      If Not GetType(System.Int16).IsAssignableFrom(value.GetType()) Then
         Throw New ArgumentException("value must be of type Int16.", "value")
      End If
   End Sub 'OnValidate 

End Class 'Int16Collection


Public Class SamplesCollectionBase
    Public Shared Sub Main()
        ' Creates and initializes a new CollectionBase.
        Dim myCollectionBase As New Int16Collection()

        ' Adds elements to the collection.
        myCollectionBase.Add( 1 )
        myCollectionBase.Add( 2 )
        myCollectionBase.Add( 3 )
        myCollectionBase.Add( 5 )
        myCollectionBase.Add( 7 )

        ' <Snippet2>
        ' Get the ICollection interface from the CollectionBase
        ' derived class.
        Dim myCollection As ICollection = myCollectionBase
        SyncLock myCollection.SyncRoot
            For Each item As Object In myCollection
                ' Insert your code here.
            Next item
        End SyncLock
        ' </Snippet2>
    End Sub
End Class
