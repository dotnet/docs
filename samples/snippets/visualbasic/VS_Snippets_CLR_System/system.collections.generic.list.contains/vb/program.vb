' <Snippet1>
Imports System
Imports System.Collections.Generic

Class Program
    Public Shared Sub Main(ByVal args As String())
        Dim cubes As New List(Of Cube)()

        cubes.Add(New Cube(8, 8, 4))
        cubes.Add(New Cube(8, 4, 8))
        cubes.Add(New Cube(8, 6, 4))

        If cubes.Contains(New Cube(8, 6, 4)) Then
            Console.WriteLine("An equal cube is already in the collection.")
        Else
            Console.WriteLine("Cube can be added.")
        End If

        'Outputs "An equal cube is already in the collection."
    End Sub
End Class

Public Class Cube
    Implements IEquatable(Of Cube)

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

    Public Overloads Function Equals(ByVal other As Cube) _
            As Boolean Implements IEquatable(Of Cube).Equals
        If Me.Height = other.Height And Me.Length = other.Length _
                And Me.Width = other.Width Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
' </Snippet1>