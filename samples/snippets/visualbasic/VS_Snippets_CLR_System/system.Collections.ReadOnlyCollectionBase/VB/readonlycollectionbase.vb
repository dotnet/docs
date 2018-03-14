' The following code example implements the ReadOnlyCollectionBase class.

' <Snippet1>
Imports System
Imports System.Collections

Public Class ROCollection
    Inherits ReadOnlyCollectionBase


    Public Sub New(sourceList As IList)
        InnerList.AddRange(sourceList)
    End Sub 'New


    Default Public ReadOnly Property Item(index As Integer) As [Object]
        Get
            Return InnerList(index)
        End Get
    End Property


    Public Function IndexOf(value As [Object]) As Integer
        Return InnerList.IndexOf(value)
    End Function 'IndexOf


    Public Function Contains(value As [Object]) As Boolean
        Return InnerList.Contains(value)
    End Function 'Contains

End Class 'ROCollection 


Public Class SamplesCollectionBase

    Public Shared Sub Main()

        ' Create an ArrayList.
        Dim myAL As New ArrayList()
        myAL.Add("red")
        myAL.Add("blue")
        myAL.Add("yellow")
        myAL.Add("green")
        myAL.Add("orange")
        myAL.Add("purple")

        ' Create a new ROCollection that contains the elements in myAL.
        Dim myCol As New ROCollection(myAL)

        ' Display the contents of the collection using For Each. This is the preferred method.
        Console.WriteLine("Contents of the collection (using For Each):")
        PrintValues1(myCol)

        ' Display the contents of the collection using the enumerator.
        Console.WriteLine("Contents of the collection (using enumerator):")
        PrintValues2(myCol)

        ' Display the contents of the collection using the Count property and the Item property.
        Console.WriteLine("Contents of the collection (using Count and Item):")
        PrintIndexAndValues(myCol)

        ' Search the collection with Contains and IndexOf.
        Console.WriteLine("Contains yellow: {0}", myCol.Contains("yellow"))
        Console.WriteLine("orange is at index {0}.", myCol.IndexOf("orange"))
        Console.WriteLine()

    End Sub 'Main


    ' Uses the Count property and the Item property.
    Public Shared Sub PrintIndexAndValues(myCol As ROCollection)
        Dim i As Integer
        For i = 0 To myCol.Count - 1
            Console.WriteLine("   [{0}]:   {1}", i, myCol(i))
        Next i
        Console.WriteLine()
    End Sub 'PrintIndexAndValues


    ' Uses the For Each statement which hides the complexity of the enumerator.
    ' NOTE: The For Each statement is the preferred way of enumerating the contents of a collection.
    Public Shared Sub PrintValues1(myCol As ROCollection)
        Dim obj As [Object]
        For Each obj In  myCol
            Console.WriteLine("   {0}", obj)
        Next obj
        Console.WriteLine()
    End Sub 'PrintValues1


    ' Uses the enumerator. 
    ' NOTE: The For Each statement is the preferred way of enumerating the contents of a collection.
    Public Shared Sub PrintValues2(myCol As ROCollection)
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
'   red
'   blue
'   yellow
'   green
'   orange
'   purple
'
'Contents of the collection (using enumerator):
'   red
'   blue
'   yellow
'   green
'   orange
'   purple
'
'Contents of the collection (using Count and Item):
'   [0]:   red
'   [1]:   blue
'   [2]:   yellow
'   [3]:   green
'   [4]:   orange
'   [5]:   purple
'
'Contains yellow: True
'orange is at index 4.

' </Snippet1>