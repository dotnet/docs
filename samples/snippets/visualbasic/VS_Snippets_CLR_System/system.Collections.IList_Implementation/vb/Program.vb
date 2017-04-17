'<snippet01>
Imports System
Imports System.Collections

Public Class Program

    Shared Sub Main()

        Dim myList As New SimpleList()

        ' Populate the List
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

        ' Remove elements from the list
        Console.WriteLine("Remove elements from the list")
        myList.Remove("six")
        myList.Remove("eight")
        myList.PrintContents()
        Console.WriteLine()

        ' Add an element to the end of the list
        Console.WriteLine("Add an element to the end of the list")
        myList.Add("nine")
        myList.PrintContents()
        Console.WriteLine()

        ' Insert an element into the middle of the list
        Console.WriteLine("Insert an element into the middle of the list")
        myList.Insert(4, "number")
        myList.PrintContents()
        Console.WriteLine()

        ' Check for specific elements in the list
        Console.WriteLine("Check for specific elements in the list")
        Console.WriteLine("List contains 'three': {0}", myList.Contains("three"))
        Console.WriteLine("List contains 'ten': {0}", myList.Contains("ten"))

    End Sub
End Class ' class Program

'<snippet02>
Public Class SimpleList
    Implements IList

    Private _contents(8) As Object
    Private _count As Integer

    Public Sub New()

        _count = 0
    End Sub

    ' IList Members
    Public Function Add(ByVal value As Object) As Integer Implements IList.Add

        If (_count < _contents.Length - 1) Then

            _contents(_count) = value
            _count = _count + 1

            Return (_count - 1)

        Else

            Return -1
        End If
    End Function

    Public Sub Clear() Implements IList.Clear
        _count = 0
    End Sub

    Public Function Contains(ByVal value As Object) As Boolean Implements IList.Contains

        Dim inList As Boolean = False

        Dim i As Integer
        For i = 0 To Count

            If _contents(i) = value Then

                inList = True
                Exit For

            End If

        Next i

        Return inList
    End Function

    Public Function IndexOf(ByVal value As Object) As Integer Implements IList.IndexOf

        Dim itemIndex As Integer = -1

        Dim i As Integer
        For i = 0 To Count

            If _contents(i) = value Then

                itemIndex = i
                Exit For

            End If

        Next i

        Return itemIndex
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal value As Object) Implements IList.Insert

        If (_count + 1) <= (_contents.Length - 1) And (index < Count) And (index >= 0) Then

            _count = _count + 1

            Dim i As Integer
            For i = Count - 1 To index

                _contents(i) = _contents(i - 1)
            Next i

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

        If index >= 0 And index < Count Then

            Dim i As Integer
            For i = index To Count - 1

                _contents(i) = _contents(i + 1)
            Next i
            _count = _count - 1

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

    ' ICollection Members

    Public Sub CopyTo(ByVal array As Array, ByVal index As Integer) Implements ICollection.CopyTo
        Dim j As Integer = index
        Dim i As Integer
        For i = 0 To Count
            array.SetValue(_contents(i), j)
            j = j + 1
        Next i
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

    ' IEnumerable Members
    Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator

        ' Refer to the IEnumerator documentation for an example of
        ' implementing an enumerator.
        Throw New Exception("The method or operation is not implemented.")
    End Function

    Public Sub PrintContents()

        Console.WriteLine("List has a capacity of {0} and currently has {1} elements.", _contents.Length - 1, _count)
        Console.Write("List contents:")

        Dim i As Integer
        For i = 0 To Count

            Console.Write(" {0}", _contents(i))
        Next i

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