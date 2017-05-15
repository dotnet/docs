' <Snippet1>
Imports System.Collections
Imports System.Collections.Generic

Class Program
    Public Shared Sub Main(ByVal args() As String)

        Dim bxList As BoxCollection = New BoxCollection()

        bxList.Add(New Box(10, 4, 6))
        bxList.Add(New Box(4, 6, 10))
        bxList.Add(New Box(6, 10, 4))
        bxList.Add(New Box(12, 8, 10))

        ' Same dimensions. Cannot be added:
        bxList.Add(New Box(10, 4, 6))

        ' Test the Remove method.
        Display(bxList)
        Console.WriteLine("Removing 6x10x4")
        bxList.Remove(New Box(6, 10, 4))
        Display(bxList)

        ' Test the Contains method
        Dim BoxCheck As Box = New Box(8, 12, 10)
        Console.WriteLine("Contains {0}x{1}x{2} by dimensions: {3}", BoxCheck.Height.ToString(),
            BoxCheck.Length.ToString(), BoxCheck.Width.ToString(), bxList.Contains(BoxCheck).ToString())

        ' Test the Contains method overload with a specified equality comparer.
        Console.WriteLine("Contains {0}x{1}x{2} by volume: {3}", BoxCheck.Height.ToString(),
            BoxCheck.Length.ToString(), BoxCheck.Width.ToString(),
            bxList.Contains(BoxCheck, New BoxSameVol()).ToString())

    End Sub

    ' <Snippet2>
    Public Shared Sub Display(ByVal bxList As BoxCollection)
        Console.WriteLine(vbLf & "Height" & vbTab & "Length" & vbTab & "Width" & vbTab & "Hash Code")
        For Each bx As Box In bxList
            Console.WriteLine("{0}" & vbTab & "{1}" & vbTab & "{2}" & vbTab & "{3}", bx.Height.ToString(), bx.Length.ToString(), bx.Width.ToString(), bx.GetHashCode().ToString())
        Next
        Console.WriteLine()
    End Sub
    ' </Snippet2>
End Class

Public Class Box : Implements IEquatable(Of Box)
    Public Sub New(ByVal h As Integer, ByVal l As Integer, ByVal w As Integer)
        Me.Height = h
        Me.Length = l
        Me.Width = w
    End Sub

    Private _Height As Integer
    Public Property Height() As Integer
        Get
            Return _Height
        End Get
        Set(ByVal value As Integer)
            _Height = value
        End Set
    End Property

    Private _Length As Integer
    Public Property Length() As Integer
        Get
            Return _Length
        End Get
        Set(ByVal value As Integer)
            _Length = value
        End Set
    End Property

    Private _Width As Integer
    Public Property Width() As Integer
        Get
            Return _Width
        End Get
        Set(ByVal value As Integer)
            _Width = value
        End Set
    End Property

    Public Overloads Function Equals(ByVal other As Box) As Boolean Implements IEquatable(Of Box).Equals
        Dim BoxSameDim = New BoxSameDimensions()
        If BoxSameDim.Equals(Me, other) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        Return MyBase.Equals(obj)
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return MyBase.GetHashCode()
    End Function
End Class

Public Class BoxCollection : Implements ICollection(Of Box)
    ' The generic enumerator obtained from IEnumerator<Box> by GetEnumerator can also
    ' be used with the non-generic IEnumerator. To avoid a naming conflict, 
    ' the non-generic IEnumerable method is explicitly implemented.

    Public Function GetEnumerator() As IEnumerator(Of Box) _
        Implements IEnumerable(Of Box).GetEnumerator

        Return New BoxEnumerator(Me)
    End Function

    Private Function GetEnumerator1() As IEnumerator _
        Implements IEnumerable.GetEnumerator

        Return Me.GetEnumerator()
    End Function

    ' The inner collection to store objects.
    Private innerCol As List(Of Box)

    Public Sub New()
        innerCol = New List(Of Box)
    End Sub

    ' Adds an index to the collection.
    Default Public Property Item(ByVal index As Integer) As Box
        Get
            'If index <> -1 Then
            Return CType(innerCol(index), Box)
            'End If
            'Return Nothing
        End Get
        Set(ByVal Value As Box)
            innerCol(index) = Value
        End Set
    End Property

    ' Determines if an item is in the collection
    ' by using the BoxSameDimensions equality comparer.
    Public Function Contains(ByVal item As Box) As Boolean _
            Implements ICollection(Of Box).Contains
        Dim found As Boolean = False

        Dim bx As Box
        For Each bx In innerCol
            If New BoxSameDimensions().Equals(bx, item) Then
                found = True
            End If
        Next

        Return found
    End Function

    ' Determines if an item is in the 
    ' collection by using a specified equality comparer.
    Public Function Contains(ByVal item As Box, _
    	ByVal comp As EqualityComparer(Of Box)) As Boolean
        Dim found As Boolean = False

        Dim bx As Box
        For Each bx In innerCol
            If comp.Equals(bx, item) Then
                found = True
            End If
        Next

        Return found
    End Function

    ' Adds an item if it is not already in the collection
    ' as determined by calling the Contains method.
    Public Sub Add(ByVal item As Box) _
        Implements ICollection(Of Box).Add

        If Not Me.Contains(item) Then
            innerCol.Add(item)
        Else
            Console.WriteLine("A box with {0}x{1}x{2} dimensions was already added to the collection.",
                item.Height.ToString(), item.Length.ToString(), item.Width.ToString())
        End If
    End Sub

    Public Sub Clear() Implements ICollection(Of Box).Clear
        innerCol.Clear()
    End Sub

    Public Sub CopyTo(array As Box(), arrayIndex As Integer) _
            Implements ICollection(Of Box).CopyTo
        If array Is Nothing Then
           Throw New ArgumentNullException("The array cannot be null.")
        Else If arrayIndex < 0 Then
           Throw New ArgumentOutOfRangeException("The starting array index cannot be negative.")
        Else If Count > array.Length - arrayIndex + 1 Then
           Throw New ArgumentException("The destination array has fewer elements than the collection.")
        End If
        
        For i As Integer = 0 To innerCol.Count - 1
            array(i + arrayIndex) = innerCol(i)
        Next
    End Sub

    Public ReadOnly Property Count() As Integer _
            Implements ICollection(Of Box).Count
        Get
            Return innerCol.Count
        End Get
    End Property

    Public ReadOnly Property IsReadOnly() As Boolean _
           Implements ICollection(Of Box).IsReadOnly
        Get
            Return False
        End Get
    End Property

    Public Function Remove(ByVal item As Box) As Boolean _
            Implements ICollection(Of Box).Remove
        Dim result As Boolean = False

        ' Iterate the inner collection to 
        ' find the box to be removed.

        Dim i As Integer
        For i = 0 To innerCol.Count - 1

            Dim curBox As Box = CType(innerCol(i), Box)

            If New BoxSameDimensions().Equals(curBox, item) Then
                innerCol.RemoveAt(i)
                result = True
                Exit For
            End If
        Next
        Return result
    End Function
End Class

' <Snippet3>
' Defines the enumerator for the Boxes collection.
' (Some prefer this class nested in the collection class.)
Public Class BoxEnumerator
    Implements IEnumerator(Of Box)
    Private _collection As BoxCollection
    Private curIndex As Integer
    Private curBox As Box


    Public Sub New(ByVal collection As BoxCollection)
        MyBase.New()
        _collection = collection
        curIndex = -1
        curBox = Nothing

    End Sub

    Private Property Box As Box
    Public Function MoveNext() As Boolean _
        Implements IEnumerator(Of Box).MoveNext
        curIndex = curIndex + 1
        If curIndex = _collection.Count Then
            ' Avoids going beyond the end of the collection.
            Return False
        Else
            'Set current box to next item in collection.
            curBox = _collection(curIndex)
        End If
        Return True
    End Function

    Public Sub Reset() _
        Implements IEnumerator(Of Box).Reset
        curIndex = -1
    End Sub

    Public Sub Dispose() _
        Implements IEnumerator(Of Box).Dispose

    End Sub

    Public ReadOnly Property Current() As Box _
        Implements IEnumerator(Of Box).Current

        Get
            If curBox Is Nothing Then
                Throw New InvalidOperationException()
            End If

            Return curBox
        End Get
    End Property

    Private ReadOnly Property Current1() As Object _
        Implements IEnumerator.Current

        Get
            Return Me.Current
        End Get
    End Property
End Class

' Defines two boxes as equal if they have the same dimensions.
Public Class BoxSameDimensions
    Inherits EqualityComparer(Of Box)

    Public Overrides Function Equals(ByVal b1 As Box, ByVal b2 As Box) As Boolean
        If b1.Height = b2.Height And b1.Length = b2.Length And b1.Width = b2.Width Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Overrides Function GetHashCode(ByVal bx As Box) As Integer
        Dim hCode As Integer = bx.Height ^ bx.Length ^ bx.Width
        Return hCode.GetHashCode()
    End Function
End Class
'</Snippet3>

' Defines two boxes as equal if they have the same volume.
Public Class BoxSameVol
    Inherits EqualityComparer(Of Box)

    Public Overrides Function Equals(ByVal b1 As Box, ByVal b2 As Box) As Boolean
        If (b1.Height * b1.Length * b1.Width) _
            = (b2.Height * b2.Length * b2.Width) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Overrides Function GetHashCode(ByVal bx As Box) As Integer
        Dim hCode As Integer = bx.Height ^ bx.Length ^ bx.Width
        Console.WriteLine("HC: {0}", hCode.GetHashCode())
        Return hCode.GetHashCode()
    End Function
End Class


'  This code example displays the following output:
'  ================================================
'
'  A box with 10x4x6 dimensions was already added to the collection.
'
'  Height  Length  Width   Hash Code
'  10      4       6       46104728
'  4       6       10      12289376
'  6       10      4       43495525
'  12      8       10      55915408
'
'  Removing 6x10x4
'
'  Height  Length  Width   Hash Code
'  10      4       6       46104728
'  4       6       10      12289376
'  12      8       10      55915408
'
'  Contains 8x12x10 by dimensions: False
'  Contains 8x12x10 by volume: True
'
'</Snippet1>


