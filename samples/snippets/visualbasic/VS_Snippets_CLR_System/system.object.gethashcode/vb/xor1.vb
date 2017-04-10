' <Snippet2>
' A type that represents a 2-D point.
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
        Return x Xor y
    End Function 
End Structure 

Public Module Example
   Public Sub Main() 
      Dim pt As New Point(5, 8)
      Console.WriteLine(pt.GetHashCode())
        
      pt = New Point(8, 5)
      Console.WriteLine(pt.GetHashCode())
   End Sub 
End Module   
' </Snippet2>

