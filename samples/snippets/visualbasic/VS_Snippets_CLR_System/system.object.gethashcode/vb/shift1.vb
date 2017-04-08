' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Public Structure Point
    Private x As Integer
    Private y As Integer

    Public Sub New(x As Integer, y As Integer)
       Me.x = x
       Me.y = y
    End Sub
    
    Public Overrides Function Equals(obj As Object) As Boolean
       If Not TypeOf obj Is Point Then Return False
       
       Dim p As Point = CType(obj, Point)
       Return x = p.x And y = p.y
    End Function
    
    Public Overrides Function GetHashCode() As Integer 
        Return ShiftAndWrap(x.GetHashCode(), 2) XOr y.GetHashCode()
    End Function 
    
    Private Function ShiftAndWrap(value As Integer, positions As Integer) As Integer
        positions = positions And &h1F
      
        ' Save the existing bit pattern, but interpret it as an unsigned integer.
        Dim number As UInteger = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0)
        ' Preserve the bits to be discarded.
        Dim wrapped AS UInteger = number >> (32 - positions)
        ' Shift and wrap the discarded bits.
        Return BitConverter.ToInt32(BitConverter.GetBytes((number << positions) Or wrapped), 0)
    End Function
End Structure 

Module Example
   Public Sub Main()
        Dim pt As New Point(5, 8)
        Console.WriteLine(pt.GetHashCode())
        
        pt = New Point(8, 5)
        Console.WriteLine(pt.GetHashCode())
   End Sub
End Module
' The example displays the following output:
'       28
'       37
' </Snippet5>

Public Class Utility
   ' <Snippet4>
   Public Function ShiftAndWrap(value As Integer, positions As Integer) As Integer
      positions = positions And &h1F
      
      ' Save the existing bit pattern, but interpret it as an unsigned integer.
      Dim number As UInteger = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0)
      ' Preserve the bits to be discarded.
      Dim wrapped AS UInteger = number >> (32 - positions)
      ' Shift and wrap the discarded bits.
      Return BitConverter.ToInt32(BitConverter.GetBytes((number << positions) Or wrapped), 0)
   End Function
   ' </Snippet4>
End Class
