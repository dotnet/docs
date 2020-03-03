'<snippet01>
Imports System.Collections

Public Class Program
    Shared Sub Main()

        Dim myList As New SimpleList()

        ' Populate the List.
        Console.WriteLine("Populate the List")
        myList.Add("one")
        myList.Add("two")
        myList.Add("three")
        myList.Add("four")
        myList.Add("five")
        myList.Add("six")
        myList.Add("seven")
        myList.Add("eight")
        myList.PrintContents()
        Console.WriteLine()

        ' Remove elements from the list.
        Console.WriteLine("Remove elements from the list")
        myList.Remove("six")
        myList.Remove("eight")
        myList.PrintContents()
        Console.WriteLine()

        ' Add an element to the end of the list.
        Console.WriteLine("Add an element to the end of the list")
        myList.Add("nine")
        myList.PrintContents()
        Console.WriteLine()

        ' Insert an element into the middle of the list.
        Console.WriteLine("Insert an element into the middle of the list")
        myList.Insert(4, "number")
        myList.PrintContents()
        Console.WriteLine()

        ' Check for specific elements in the list.
        Console.WriteLine("Check for specific elements in the list")
        Console.WriteLine($"List contains 'three': {myList.Contains("three")}")
        Console.WriteLine($"List contains 'ten': {myList.Contains("ten")}")
    End Sub
End Class

'<snippet02>
Public Class SimpleList
    Implements IList

    Private _contents(7) As Object
    Private _count As Integer

    Public Sub New()

        _count = 0
    End Sub

    ' IList members.
    Public Function Add(ByVal value As Object) As Integer Implements IList.Add
        If _count < _contents.Length Then
            _contents(_count) = value
            _count += 1

            Return _count - 1
        End If

        Return -1
    End Function

    Public Sub Clear() Implements IList.Clear
        _count = 0
    End Sub

    Public Function Contains(ByVal value As Object) As Boolean Implements IList.Contains
        For i As Integer = 0 To Count - 1
            If _contents(i) = value Then Return True
        Next

        Return False
    End Function

    Public Function IndexOf(ByVal value As Object) As Integer Implements IList.IndexOf
        For i As Integer = 0 To Count - 1
            If _contents(i) = value Then Return i
        Next
        Return -1
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal value As Object) Implements IList.Insert

        If _count + 1 <= _contents.Length AndAlso index < Count AndAlso index >= 0 Then
            _count += 1

            For i As Integer = Count - 1 To index Step -1
                _contents(i) = _contents(i - 1)
            Next
            _contents(index) = value
        End If
    End Sub

    Public ReadOnly Property IsFixedSize() As Boolean Implements IList.IsFixedSize
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property IsReadOnly() As Boolean Implements IList.IsReadOnly
        Get
            Return False
        End Get
    End Property

    Public Sub Remove(ByVal value As Object) Implements IList.Remove
        RemoveAt(IndexOf(value))
    End Sub

    Public Sub RemoveAt(ByVal index As Integer) Implements IList.RemoveAt

        if index >= 0 AndAlso index < Count Then
            for i As Integer = index To Count - 2
                _contents(i) = _contents(i + 1)
            Next
            _count -= 1
        End If
    End Sub

    Public Property Item(ByVal index As Integer) As Object Implements IList.Item
        Get
            Return _contents(index)
        End Get

        Set(ByVal value As Object)
            _contents(index) = value
        End Set
    End Property

    ' ICollection members.
    Public Sub CopyTo(ByVal array As Array, ByVal index As Integer) Implements ICollection.CopyTo
        For i As Integer = 0 To Count - 1
            array.SetValue(_contents(i), index)
            index += 1
        Next
    End Sub

    Public ReadOnly Property Count() As Integer Implements ICollection.Count
        Get
            Return _count
        End Get
    End Property

    Public ReadOnly Property IsSynchronized() As Boolean Implements ICollection.IsSynchronized
        Get
            Return False
        End Get
    End Property

    ' Return the current instance since the underlying store is not
    ' publicly available.
    Public ReadOnly Property SyncRoot() As Object Implements ICollection.SyncRoot
        Get
            Return Me
        End Get
    End Property

    ' IEnumerable members.
    Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator

        ' Refer to the IEnumerator documentation for an example of
        ' implementing an enumerator.
        Throw New NotImplementedException("The method or operation is not implemented.")
    End Function

    Public Sub PrintContents()
        Console.WriteLine($"List has a capacity of {_contents.Length} and currently has {_count} elements.")
        Console.Write("List contents:")

        For i As Integer = 0 To Count - 1
            Console.Write($" {_contents(i)}")
        Next

        Console.WriteLine()
    End Sub
End Class
'</snippet02>

' This code produces output similar to the following:
' Populate the List:
' List has a capacity of 8 and currently has 8 elements.
' List contents: one two three four five six seven eight
'
' Remove elements from the list:
' List has a capacity of 8 and currently has 6 elements.
' List contents: one two three four five seven
'
' Add an element to the end of the list:
' List has a capacity of 8 and currently has 7 elements.
' List contents: one two three four five seven nine
'
' Insert an element into the middle of the list:
' List has a capacity of 8 and currently has 8 elements.
' List contents: one two three four number five seven nine
'
' Check for specific elements in the list:
' List contains "three": True
' List contains "ten": False
'</snippet01>