Imports System.Collections.Generic
Imports System.Runtime.CompilerServices

Public Class Example
    Public Shared Sub Main()
        Dim redBox As New Box(8, 8, 4)
        Dim blueBox As New Box(6, 8, 4)
        Dim greenBox As New Box(4, 8, 8)

        Dim boxes As Box() = { redBox, blueBox, greenBox }

        Dim boxToFind As New Box(4, 8, 8)

        Dim foundByDimension = boxes.FindFirst(boxToFind)

        Console.WriteLine($"Found box {foundByDimension} by dimension.")

        Dim foundByVolume = boxes.FindFirst(boxToFind, New BoxEqVolume())

        Console.WriteLine($"Found box {foundByVolume} by volume.")
    End Sub

    Private Shared Sub PrintBoxCollection(boxes As Dictionary(Of Box, String))
        For Each kvp As KeyValuePair(Of Box, String) In boxes
            Console.WriteLine($"{kvp.Key.Height} x {kvp.Key.Length} x {kvp.Key.Width} - {kvp.Value}")
        Next
    End Sub
End Class

Public Module CollectionExtensions
    <Extension()> 
    Public Function FindFirst(Of T)(
        collection As IEnumerable(Of T), itemToFind As T, Optional comparer As IEqualityComparer(Of T) = Nothing)

        comparer = If(comparer, EqualityComparer(Of T).Default)

        For Each item In collection
            If comparer.Equals(item, itemToFind)
                Return item
            End IF
        Next

        Throw New InvalidOperationException("No matching item found.")
    End Function
End Module

Public Class BoxEqVolume
    Inherits EqualityComparer(Of Box)

    Public Overrides Function GetHashCode(box As Box) As Integer
        Return box.Volume.GetHashCode()
    End Function

    Public Overrides Function Equals(b1 As Box, b2 As Box) As Boolean
        If b1 Is b2 Then
            Return True
        End If

        If b1 Is Nothing OrElse b2 Is Nothing Then
            Return False
        End If

        Return b1.Volume = b2.Volume
    End Function
End Class

Public Class Box
    Implements IEquatable(Of Box)

    Public Sub New(height As Integer, length As Integer, width As Integer)
        Me.Height = height
        Me.Length = length
        Me.Width = width
    End Sub

    Public ReadOnly Property Height() As Integer
    Public ReadOnly Property Length() As Integer
    Public ReadOnly Property Width() As Integer

    Public ReadOnly Property Volume() As Integer
        Get
            Return Height * Length * Width
        End Get
    End Property

    Public Overloads Function Equals(other As Box) As Boolean Implements IEquatable(Of Box).Equals
        If other Is Nothing Then
            Return False
        End If

        Return Me.Height = other.Height AndAlso Me.Length = other.Length AndAlso
            Me.Width = other.Width
    End Function

    Public Overrides Function Equals(other As Object) As Boolean
        Return Equals(TryCast(other, Box))
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return (Height, Length, Width).GetHashCode()
    End Function

    Public Overrides Function ToString() As String
        Return $"{Height} x {Length} x {Width}"
    End Function
End Class
' This example produces the following output:
'  
' Found box 4 x 8 x 8 by dimension.
' Found box 8 x 8 x 4 by volume.
