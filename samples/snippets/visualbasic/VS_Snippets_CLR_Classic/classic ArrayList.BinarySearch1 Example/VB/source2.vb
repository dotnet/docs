'<Snippet2>
Imports System
Imports System.Collections

Public Class SimpleStringComparer
    Implements IComparer

    Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
          Dim cmpstr As String = CType(x, String)
          Return cmpstr.CompareTo(CType(y, String))
    End Function
End Class

Public Class MyArrayList
    Inherits ArrayList

    Public Shared Sub Main()
        ' Creates and initializes a new ArrayList.
        Dim coloredAnimals As New MyArrayList()

        coloredAnimals.Add("White Tiger")
        coloredAnimals.Add("Pink Bunny")
        coloredAnimals.Add("Red Dragon")
        coloredAnimals.Add("Green Frog")
        coloredAnimals.Add("Blue Whale")
        coloredAnimals.Add("Black Cat")
        coloredAnimals.Add("Yellow Lion")

        ' BinarySearch requires a sorted ArrayList.
        coloredAnimals.Sort()

        ' Compare results of an iterative search with a binary search
        Dim index As Integer = coloredAnimals.IterativeSearch("White Tiger")
        Console.WriteLine("Iterative search, item found at index: {0}", index)

        index = coloredAnimals.BinarySearch("White Tiger", New SimpleStringComparer())
        Console.WriteLine("Binary search, item found at index:    {0}", index)
    End Sub

    Public Function IterativeSearch(finditem As Object) As Integer
        Dim index As Integer = -1

        For i As Integer = 0 To MyClass.Count - 1
            If finditem.Equals(MyClass.Item(i))
                index = i
                Exit For
            End If
        Next i
        Return index
    End Function
End Class
'
' This code produces the following output.
'
' Iterative search, item found at index: 5
' Binary search, item found at index:    5
'
'</Snippet2>

