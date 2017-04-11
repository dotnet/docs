' <Snippet1>
'Imports System.Collections
Imports System.Collections.Generic

Module Program
    Dim boxes As Dictionary(Of Box, [String])

    Public Sub Main(ByVal args As String())

        Dim boxDim As New BoxSameDimensions()
        boxes = New Dictionary(Of Box, String)(boxDim)

        Console.WriteLine("Boxes equality by dimensions:")
        Dim redBox As New Box(8, 4, 8)
        Dim greenBox As New Box(8, 6, 8)
        Dim blueBox As New Box(8, 4, 8)
        Dim yellowBox As New Box(8, 8, 8)
        AddBox(redBox, "red")
        AddBox(greenBox, "green")
        AddBox(blueBox, "blue")
        AddBox(yellowBox, "yellow")

        Console.WriteLine()
        Console.WriteLine("Boxes equality by volume:")

        Dim boxVolume As New BoxSameVolume()
        boxes = New Dictionary(Of Box, String)(boxVolume)
        Dim pinkBox As New Box(8, 4, 8)
        Dim orangeBox As New Box(8, 6, 8)
        Dim purpleBox As New Box(4, 8, 8)
        Dim brownBox As New Box(8, 8, 4)
        AddBox(pinkBox, "pink")
        AddBox(orangeBox, "orange")
        AddBox(purpleBox, "purple")
        AddBox(brownBox, "brown")
    End Sub

    Public Sub AddBox(ByVal bx As Box, ByVal name As String)
        Try
            boxes.Add(bx, name)
            Console.WriteLine("Added {0}, Count = {1}, HashCode = {2}", _
                              name, boxes.Count.ToString(), bx.GetHashCode())
        Catch generatedExceptionName As ArgumentException
            Console.WriteLine("A box equal to {0} is already in the collection.", name)
        End Try
    End Sub
End Module

Public Class Box
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
End Class

Class BoxSameDimensions : Inherits EqualityComparer(Of Box)
    Public Overloads Overrides Function Equals(ByVal b1 As Box, _
                                      ByVal b2 As Box) As Boolean
        If b1 Is Nothing AndAlso b2 Is Nothing Then
           Return True
        Else If b1 Is Nothing OrElse b2 Is Nothing Then
           Return False
        End If

        If b1.Height = b2.Height AndAlso b1.Length = b2.Length _
                                 AndAlso b1.Width = b2.Width Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Overloads Overrides Function GetHashCode(ByVal bx As Box) As Integer
        Dim hCode As Integer = bx.Height Xor bx.Length Xor bx.Width
        Return hCode.GetHashCode()
    End Function
End Class

Class BoxSameVolume : Inherits EqualityComparer(Of Box)
    Public Overloads Overrides Function Equals(ByVal b1 As Box, _
                                          ByVal b2 As Box) As Boolean
        If b1 Is Nothing AndAlso b2 Is Nothing Then
           Return True
        Else If b1 Is Nothing OrElse b2 Is Nothing Then
           Return False
        End If

        If b1.Height * b1.Width * b1.Length = _
                                b2.Height * b2.Width * b2.Length Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Overloads Overrides Function GetHashCode(ByVal bx As Box) As Integer
        Dim hCode As Integer = bx.Height * bx.Length * bx.Width
        Return hCode.GetHashCode()
    End Function
End Class
' This example produces the following output:
' * 
'    Boxes equality by dimensions:
'    Added red, Count = 1, HashCode = 46104728
'    Added green, Count = 2, HashCode = 12289376
'    A box equal to blue is already in the collection.
'    Added yellow, Count = 3, HashCode = 43495525
'
'    Boxes equality by volume:
'    Added pink, Count = 1, HashCode = 55915408
'    Added orange, Count = 2, HashCode = 33476626
'    A box equal to purple is already in the collection.
'    A box equal to brown is already in the collection.
' * 
' 
' </Snippet1>

