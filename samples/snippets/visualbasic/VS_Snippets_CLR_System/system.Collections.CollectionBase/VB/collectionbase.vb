' The following code example implements the CollectionBase class and uses that implementation to create a collection of Int16 objects.

' <Snippet1>
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
      Dim myI16 As New Int16Collection()

      ' Adds elements to the collection.
      myI16.Add( 1 )
      myI16.Add( 2 )
      myI16.Add( 3 )
      myI16.Add( 5 )
      myI16.Add( 7 )

      ' Display the contents of the collection using For Each. This is the preferred method.
      Console.WriteLine("Contents of the collection (using For Each):")
      PrintValues1(myI16)
      
      ' Display the contents of the collection using the enumerator.
      Console.WriteLine("Contents of the collection (using enumerator):")
      PrintValues2(myI16)
      
      ' Display the contents of the collection using the Count property and the Item property.
      Console.WriteLine("Initial contents of the collection (using Count and Item):")
      PrintIndexAndValues(myI16)
      
      ' Searches the collection with Contains and IndexOf.
      Console.WriteLine("Contains 3: {0}", myI16.Contains(3))
      Console.WriteLine("2 is at index {0}.", myI16.IndexOf(2))
      Console.WriteLine()
      
      ' Inserts an element into the collection at index 3.
      myI16.Insert(3, 13)
      Console.WriteLine("Contents of the collection after inserting at index 3:")
      PrintIndexAndValues(myI16)
      
      ' Gets and sets an element using the index.
      myI16(4) = 123
      Console.WriteLine("Contents of the collection after setting the element at index 4 to 123:")
      PrintIndexAndValues(myI16)
      
      ' Removes an element from the collection.
      myI16.Remove(2)

      ' Display the contents of the collection using the Count property and the Item property.
      Console.WriteLine("Contents of the collection after removing the element 2:")
      PrintIndexAndValues(myI16)

    End Sub 'Main


    ' Uses the Count property and the Item property.
    Public Shared Sub PrintIndexAndValues(myCol As Int16Collection)
      Dim i As Integer
      For i = 0 To myCol.Count - 1
          Console.WriteLine("   [{0}]:   {1}", i, myCol(i))
      Next i
      Console.WriteLine()
    End Sub 'PrintIndexAndValues


    ' Uses the For Each statement which hides the complexity of the enumerator.
    ' NOTE: The For Each statement is the preferred way of enumerating the contents of a collection.
    Public Shared Sub PrintValues1(myCol As Int16Collection)
      Dim i16 As Int16
      For Each i16 In  myCol
          Console.WriteLine("   {0}", i16)
      Next i16
      Console.WriteLine()
    End Sub 'PrintValues1


    ' Uses the enumerator. 
    ' NOTE: The For Each statement is the preferred way of enumerating the contents of a collection.
    Public Shared Sub PrintValues2(myCol As Int16Collection)
      Dim myEnumerator As System.Collections.IEnumerator = myCol.GetEnumerator()
      While myEnumerator.MoveNext()
          Console.WriteLine("   {0}", myEnumerator.Current)
      End While
      Console.WriteLine()
    End Sub 'PrintValues2

End Class 'SamplesCollectionBase


'This code produces the following output.
'
'Contents of the collection (using For Each):
'   1
'   2
'   3
'   5
'   7
'
'Contents of the collection (using enumerator):
'   1
'   2
'   3
'   5
'   7
'
'Initial contents of the collection (using Count and Item):
'   [0]:   1
'   [1]:   2
'   [2]:   3
'   [3]:   5
'   [4]:   7
'
'Contains 3: True
'2 is at index 1.
'
'Contents of the collection after inserting at index 3:
'   [0]:   1
'   [1]:   2
'   [2]:   3
'   [3]:   13
'   [4]:   5
'   [5]:   7
'
'Contents of the collection after setting the element at index 4 to 123:
'   [0]:   1
'   [1]:   2
'   [2]:   3
'   [3]:   13
'   [4]:   123
'   [5]:   7
'
'Contents of the collection after removing the element 2:
'   [0]:   1
'   [1]:   3
'   [2]:   13
'   [3]:   123
'   [4]:   7

' </Snippet1>