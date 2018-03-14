Imports System
Imports System.Collections
Imports System.Collections.Specialized

Public Class SimpleOD
    Implements IOrderedDictionary
    Private itemlist As ArrayList

    Public Sub New(ByVal numItems As Integer)
        itemlist = New ArrayList(numItems)
    End Sub

    Public Function IndexOfKey(ByVal key As Object) As Integer
        Dim i As Integer
        For i = 0 To itemlist.Count - 1
            If CType(itemlist(i), DictionaryEntry).Key = key Then
                Return i
            End If
        Next i

        ' key not found, return -1.
        Return -1
    End Function

    ' IOrderedDictionary Members
    Public Function GetEnumerator() As IDictionaryEnumerator _
        Implements IOrderedDictionary.GetEnumerator

        Return New ODEnum(itemlist)
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal key As Object, _
        ByVal value As Object) Implements IOrderedDictionary.Insert

        If Not IndexOfKey(key) = -1 Then
            Throw New ArgumentException("An element with the same key already exists in the collection.")
        End If
        itemlist.Insert(index, New DictionaryEntry(key, value))
    End Sub

    Public Sub RemoveAt(ByVal index As Integer) _
        Implements IOrderedDictionary.RemoveAt

        itemlist.RemoveAt(index)
    End Sub

    Public Property Item(ByVal index As Integer) As Object _
        Implements IOrderedDictionary.Item

        Get
            Return CType(itemlist(index), DictionaryEntry).Value
        End Get
        Set(ByVal value As Object)
            Dim key As Object = CType(itemlist(index), DictionaryEntry).Key
            itemlist(index) = New DictionaryEntry(key, value)
        End Set
    End Property

    ' IDictionary Members
    Public Function IDictionaryGetEnumerator() As IDictionaryEnumerator _
    Implements IDictionary.GetEnumerator

        Return New ODEnum(itemlist)
    End Function

    Public Property Item(ByVal key As Object) As Object _
        Implements IDictionary.Item

        Get
            Return CType(itemlist(IndexOfKey(key)), DictionaryEntry).Value
        End Get
        Set(ByVal value)
            itemlist(IndexOfKey(key)) = New DictionaryEntry(key, value)
        End Set
    End Property


    Public Sub Add(ByVal key As Object, ByVal value As Object) _
        Implements IDictionary.Add

        If Not IndexOfKey(key) = -1 Then
            Throw New ArgumentException("An element with the same key already exists in the collection.")
        End If

        itemlist.Add(New DictionaryEntry(key, value))
    End Sub

    Public Sub Clear() Implements IDictionary.Clear
        itemlist.Clear()
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
            Dim KeyCollection As ArrayList = New ArrayList(itemlist.Count)
            Dim i As Integer
            For i = 0 To itemlist.Count
                KeyCollection(i) = CType(itemlist(i), DictionaryEntry).Key
            Next i
            Return KeyCollection
        End Get
    End Property

    Public Sub Remove(ByVal key As Object) _
        Implements IDictionary.Remove

        itemlist.RemoveAt(IndexOfKey(key))
    End Sub

    Public ReadOnly Property Values() As ICollection _
        Implements IDictionary.Values
        Get
            Dim ValueCollection As ArrayList = New ArrayList(itemlist.Count)
            Dim i As Integer
            For i = 0 To itemlist.Count
                ValueCollection(i) = CType(itemlist(i), DictionaryEntry).Value
            Next i
            Return ValueCollection
        End Get
    End Property

    ' ICollection Members
    Public Sub CopyTo(ByVal array As Array, ByVal index As Integer) _
    Implements ICollection.CopyTo

        itemlist.CopyTo(Array, index)
    End Sub

    Public ReadOnly Property Count() As Integer _
        Implements ICollection.Count

        Get
            Return itemlist.Count
        End Get
    End Property

    Public ReadOnly Property IsSynchronized() As Boolean _
        Implements ICollection.IsSynchronized

        Get
            Return itemlist.IsSynchronized
        End Get
    End Property

    Public ReadOnly Property SyncRoot() As Object _
        Implements ICollection.SyncRoot

        Get
            Return itemlist.SyncRoot
        End Get
    End Property

    ' IEnumerable Members
    Public Function IEnumerableGetEnumerator() As IEnumerator _
        Implements IEnumerable.GetEnumerator

        Return New ODEnum(itemlist)
    End Function
End Class

Public Class OdEnum
    Implements IDictionaryEnumerator

    Public itemlist As ArrayList

    ' Enumerators are positioned before the first element
    ' until the first MoveNext() call.
    Dim position As Integer = -1

    Public Sub New(ByVal list As ArrayList)
        itemlist = list
    End Sub

    Public Function MoveNext() As Boolean _
        Implements IEnumerator.MoveNext

        position = position + 1
        Return (position < itemlist.Count)
    End Function

    Public Sub Reset() _
        Implements IEnumerator.Reset

        position = -1
    End Sub

    Public ReadOnly Property Current() As Object _
        Implements IEnumerator.Current

        Get
            Try
                Return itemlist(position)
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
                Return CType(itemlist(position), DictionaryEntry).Key
            Catch e As IndexOutOfRangeException
                Throw New InvalidOperationException()
            End Try
        End Get
    End Property

    Public ReadOnly Property Value() As Object _
        Implements IDictionaryEnumerator.Value

        Get
            Try
                Return CType(itemlist(position), DictionaryEntry).Value
            Catch e As IndexOutOfRangeException
                Throw New InvalidOperationException()
            End Try
        End Get
    End Property
End Class

Class App
    Shared Sub Main()
        Dim index as Integer = 1

        Dim myOrderedDictionary As New SimpleOD(2)
        myOrderedDictionary.Add("Way", "ToGo")
        myOrderedDictionary.Add("Far", "Out")

        Dim obj As Object
        '<snippet04>
        obj = myOrderedDictionary(index)
        '</snippet04>
        Dim de As DictionaryEntry
        '<snippet03>
        For Each de In myOrderedDictionary
            '...
        Next
        '</snippet03>
    End Sub
End Class
