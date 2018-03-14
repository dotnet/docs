' <Snippet1>
Imports System.Collections.Generic

Module Example
   Public Sub Main()

      Dim boxEqC As New BoxEqualityComparer()

      Dim boxes As New Dictionary(Of Box, String)(boxEqC)

      Dim redBox = New Box(4, 3, 4)
      AddBox(boxes, redBox, "red")

      Dim blueBox = new Box(4, 3, 4)
      AddBox(boxes, blueBox, "blue")

      Dim greenBox = new Box(3, 4, 3)
      AddBox(boxes, greenBox, "green")
      Console.WriteLine()

      Console.WriteLine("The dictionary contains {0} Box objects.",
                        boxes.Count)
   End Sub

   Private Sub AddBox(dict As Dictionary(Of Box, String), box As Box, name As String)
      Try
         dict.Add(box, name)
      Catch e As ArgumentException
         Console.WriteLine("Unable to add {0}: {1}", box, e.Message)
      End Try
   End Sub
End Module

Public Class Box
    Private _Height As Integer
    Private _Length As Integer
    Private _Width As Integer

    Public Sub New(ByVal h As Integer, ByVal l As Integer,
                                        ByVal w As Integer)
        Me.Height = h
        Me.Length = l
        Me.Width = w
    End Sub

    Public Property Height() As Integer
        Get
            Return _Height
        End Get
        Set(ByVal value As Integer)
            _Height = value
        End Set
    End Property

    Public Property Length() As Integer
        Get
            Return _Length
        End Get
        Set(ByVal value As Integer)
            _Length = value
        End Set
    End Property

    Public Property Width() As Integer
        Get
            Return _Width
        End Get
        Set(ByVal value As Integer)
            _Width = value
        End Set
    End Property

    Public Overrides Function ToString() As String
       Return String.Format("({0}, {1}, {2})", _Height, _Length, _Width)
    End Function
End Class

Class BoxEqualityComparer
    Implements IEqualityComparer(Of Box)

    Public Overloads Function Equals(ByVal b1 As Box, ByVal b2 As Box) _
                   As Boolean Implements IEqualityComparer(Of Box).Equals

        If b1 Is Nothing AndAlso b2 Is Nothing Then
            Return True
        ElseIf b1 Is Nothing Or b2 Is Nothing Then
            Return False
        ElseIf b1.Height = b2.Height AndAlso b1.Length =
                b2.Length AndAlso b1.Width = b2.Width Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Overloads Function GetHashCode(ByVal bx As Box) _
                As Integer Implements IEqualityComparer(Of Box).GetHashCode
        Dim hCode As Integer = bx.Height Xor bx.Length Xor bx.Width
        Return hCode.GetHashCode()
    End Function

End Class
' The example displays the following output:
'    Unable to add (4, 3, 4): An item with the same key has already been added.
'
'    The dictionary contains 2 Box objects.
' </Snippet1>