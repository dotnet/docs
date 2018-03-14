'<snippet00>
Imports System
Imports System.Collections
Imports System.Collections.Specialized

'<snippet01>
Public Class People
    Implements IOrderedDictionary
    Private _people As ArrayList

    Public Sub New(ByVal numItems As Integer)
        _people = New ArrayList(numItems)
    End Sub

    Public Function IndexOfKey(ByVal key As Object) As Integer
        Dim i As Integer
        For i = 0 To _people.Count - 1
            If CType(_people(i), DictionaryEntry).Key = key Then
                Return i
            End If
        Next i

        ' key not found, return -1.
        Return -1
    End Function

    ' IOrderedDictionary Members
    Public Function GetEnumerator() As IDictionaryEnumerator _
        Implements IOrderedDictionary.GetEnumerator

        Return New PeopleEnum(_people)
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal key As Object, _
        ByVal value As Object) Implements IOrderedDictionary.Insert

        If Not IndexOfKey(key) = -1 Then
            Throw New ArgumentException("An element with the same key already exists in the collection.")
        End If
        _people.Insert(index, New DictionaryEntry(key, value))
    End Sub

    Public Sub RemoveAt(ByVal index As Integer) _
        Implements IOrderedDictionary.RemoveAt

        _people.RemoveAt(index)
    End Sub

    Public Property Item(ByVal index As Integer) As Object _
        Implements IOrderedDictionary.Item

        Get
            Return CType(_people(index), DictionaryEntry).Value
        End Get
        Set(ByVal value As Object)
            Dim key As Object = CType(_people(index), DictionaryEntry).Key
            _people(index) = New DictionaryEntry(key, value)
        End Set
    End Property

    ' IDictionary Members
    Public Function IDictionaryGetEnumerator() As IDictionaryEnumerator _
    Implements IDictionary.GetEnumerator

        Return New PeopleEnum(_people)
    End Function

    Public Property Item(ByVal key As Object) As Object _
        Implements IDictionary.Item

        Get
            Return CType(_people(IndexOfKey(key)), DictionaryEntry).Value
        End Get
        Set(ByVal value)
            _people(IndexOfKey(key)) = New DictionaryEntry(key, value)
        End Set
    End Property


    Public Sub Add(ByVal key As Object, ByVal value As Object) _
        Implements IDictionary.Add

        If Not IndexOfKey(key) = -1 Then
            Throw New ArgumentException("An element with the same key already exists in the collection.")
        End If

        _people.Add(New DictionaryEntry(key, value))
    End Sub

    Public Sub Clear() Implements IDictionary.Clear
        _people.Clear()
    End Sub

    Public Function Contains(ByVal key As Object) As Boolean _
        Implements IDictionary.Contains

        If IndexOfKey(key) = -1 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public ReadOnly Property IsFixedSize() As Boolean _
        Implements IDictionary.IsFixedSize

        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property IsReadOnly() As Boolean _
        Implements IDictionary.IsReadOnly
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property Keys() As ICollection _
        Implements IDictionary.Keys
        Get
            Dim KeyCollection As ArrayList = New ArrayList(_people.Count)
            Dim i As Integer
            For i = 0 To _people.Count - 1
                KeyCollection.Add( CType(_people(i), DictionaryEntry).Key )
            Next i
            Return KeyCollection
        End Get
    End Property

    Public Sub Remove(ByVal key As Object) _
        Implements IDictionary.Remove

        _people.RemoveAt(IndexOfKey(key))
    End Sub

    Public ReadOnly Property Values() As ICollection _
        Implements IDictionary.Values
        Get
            Dim ValueCollection As ArrayList = New ArrayList(_people.Count)
            Dim i As Integer
            For i = 0 To _people.Count - 1
                ValueCollection.Add( CType(_people(i), DictionaryEntry).Value )
            Next i
            Return ValueCollection
        End Get
    End Property

    ' ICollection Members
    Public Sub CopyTo(ByVal array As Array, ByVal index As Integer) _
    Implements ICollection.CopyTo

        _people.CopyTo(Array, index)
    End Sub

    Public ReadOnly Property Count() As Integer _
        Implements ICollection.Count

        Get
            Return _people.Count
        End Get
    End Property

    Public ReadOnly Property IsSynchronized() As Boolean _
        Implements ICollection.IsSynchronized

        Get
            Return _people.IsSynchronized
        End Get
    End Property

    Public ReadOnly Property SyncRoot() As Object _
        Implements ICollection.SyncRoot

        Get
            Return _people.SyncRoot
        End Get
    End Property

    ' IEnumerable Members
    Public Function IEnumerableGetEnumerator() As IEnumerator _
        Implements IEnumerable.GetEnumerator

        Return New PeopleEnum(_people)
    End Function
End Class

Public Class PeopleEnum
    Implements IDictionaryEnumerator

    Public _people As ArrayList

    ' Enumerators are positioned before the first element
    ' until the first MoveNext() call.
    Dim position As Integer = -1

    Public Sub New(ByVal list As ArrayList)
        _people = list
    End Sub

    Public Function MoveNext() As Boolean _
        Implements IEnumerator.MoveNext

        position = position + 1
        Return (position < _people.Count)
    End Function

    Public Sub Reset() _
        Implements IEnumerator.Reset

        position = -1
    End Sub

    Public ReadOnly Property Current() As Object _
        Implements IEnumerator.Current

        Get
            Try
                Return _people(position)
            Catch e As IndexOutOfRangeException
                Throw New InvalidOperationException()
            End Try
        End Get
    End Property

    Public ReadOnly Property Entry() As DictionaryEntry _
        Implements IDictionaryEnumerator.Entry
        Get
            Return CType(Current, DictionaryEntry)
        End Get
    End Property

    Public ReadOnly Property Key() As Object _
        Implements IDictionaryEnumerator.Key

        Get
            Try
                Return CType(_people(position), DictionaryEntry).Key
            Catch e As IndexOutOfRangeException
                Throw New InvalidOperationException()
            End Try
        End Get
    End Property

    Public ReadOnly Property Value() As Object _
        Implements IDictionaryEnumerator.Value

        Get
            Try
                Return CType(_people(position), DictionaryEntry).Value
            Catch e As IndexOutOfRangeException
                Throw New InvalidOperationException()
            End Try
        End Get
    End Property
End Class
'</snippet01>

Class App
    Shared Sub Main()
        Dim peopleCollection As People = New People(3)
        peopleCollection.Add("John", "Smith")
        peopleCollection.Add("Jim", "Johnson")
        peopleCollection.Add("Sue", "Rabon")

        Console.WriteLine("Displaying the entries in peopleCollection:")
        Dim de As DictionaryEntry
        For Each de In peopleCollection
            Console.WriteLine("{0} {1}", de.Key, de.Value)
        Next

        Console.WriteLine()
        Console.WriteLine("Displaying the entries in the modified peopleCollection:")
        'peopleCollection("Jim") = "Jackson"
        peopleCollection.Remove("Sue")
        peopleCollection.Insert(0, "Fred", "Anderson")

        For Each de In peopleCollection
            Console.WriteLine("{0} {1}", de.Key, de.Value)
        Next
    End Sub
End Class
' This code produces output similar to the following:
' 
' Displaying the entries in peopleCollection:
' John Smith
' Jim Johnson
' Sue Rabon
' 
' Displaying the entries in the modified peopleCollection:
' Fred Anderson
' John Smith
' Jim Jackson
'</snippet00>