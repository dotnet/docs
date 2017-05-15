'<Snippet1>
Imports System
Imports System.Collections
Imports System.Collections.Generic

Public Class Example
    Public Shared Sub Main()
        Dim bxd As New BoxEqDimensions()
        Dim bxv As New BoxEqVolume()

        Dim boxesByDim As New Dictionary(Of Box, String)(bxd)
        Dim boxesByVol As New Dictionary(Of Box, String)(bxv)

        Try
            Dim redBox As New Box(8, 8, 4)
            Dim blueBox As New Box(6, 8, 4)
            Dim greenBox As New Box(4, 8, 8)

            Console.WriteLine("Adding boxes by Dimension")

            boxesByDim.Add(redBox, "red")
            boxesByDim.Add(blueBox, "blue")
            boxesByDim.Add(greenBox, "green")

            PrintBoxCollection(boxesByDim)

            Console.WriteLine(vbLf & "Adding boxes by Volume")

            boxesByDim.Add(redBox, "red")
            boxesByDim.Add(blueBox, "blue")
            boxesByDim.Add(greenBox, "green")



            PrintBoxCollection(boxesByVol)
        Catch argEx As ArgumentException
            Console.WriteLine(argEx.Message)
        End Try
    End Sub
    Private Shared Sub PrintBoxCollection(ByVal boxes As Dictionary(Of Box, String))
        For Each kvp As KeyValuePair(Of Box, String) In boxes
            Console.WriteLine("{0} x {1} x {2} - {3}", kvp.Key.Height.ToString(), kvp.Key.Length.ToString(), kvp.Key.Width.ToString(), kvp.Value)
        Next
    End Sub
End Class
Public Class BoxEqDimensions
    Inherits EqualityComparer(Of Box)
    Public Overloads Overrides Function GetHashCode(ByVal bx As Box) As Integer
        Dim hCode As Integer = bx.Height Xor bx.Length Xor bx.Width
        Return hCode.GetHashCode()
    End Function

    Public Overloads Overrides Function Equals(ByVal b1 As Box, ByVal b2 As Box) As Boolean
        Return EqualityComparer(Of Box).[Default].Equals(b1, b2)
    End Function
End Class


Public Class BoxEqVolume
    Inherits EqualityComparer(Of Box)
    Public Overloads Overrides Function GetHashCode(ByVal bx As Box) As Integer
        Dim hCode As Integer = bx.Height Xor bx.Length Xor bx.Width
        Return hCode.GetHashCode()
    End Function

    Public Overloads Overrides Function Equals(ByVal b1 As Box, ByVal b2 As Box) As Boolean
        If b1.Height * b1.Width * b1.Length = b2.Height * b2.Width * b2.Length Then
            Return True
        Else
            Return False
        End If
    End Function
End Class

Public Class Box
    Implements IEquatable(Of Box)

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

        If Me.Height = other.Height And Me.Length = other.Length And Me.Width = other.Width Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
' This example produces the following output:
'  
' Adding boxes by Dimension
' 8 x 8 x 4 - red
' 6 x 8 x 4 - blue
' 4 x 8 x 8 - green
'
' Adding boxes by Volume
' An item with the same key has already been added.
' 
' </Snippet1>