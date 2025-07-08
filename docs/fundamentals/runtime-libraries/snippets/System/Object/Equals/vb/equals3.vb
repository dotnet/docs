' <Snippet1>
Class Rectangle 
    Private a, b As Point
    
    Public Sub New(ByVal upLeftX As Integer, ByVal upLeftY As Integer, _
                   ByVal downRightX As Integer, ByVal downRightY As Integer) 
        Me.a = New Point(upLeftX, upLeftY)
        Me.b = New Point(downRightX, downRightY)
    End Sub 
    
    Public Overrides Function Equals(ByVal obj As [Object]) As Boolean 
        ' Performs an equality check on two rectangles (Point object pairs).
        If obj Is Nothing OrElse Not [GetType]().Equals(obj.GetType()) Then
            Return False
        End If
        Dim r As Rectangle = CType(obj, Rectangle)
        Return a.Equals(r.a) AndAlso b.Equals(r.b)
    End Function

    Public Overrides Function GetHashCode() As Integer 
        Return Tuple.Create(a, b).GetHashCode()
    End Function 

    Public Overrides Function ToString() As String
       Return String.Format("Rectangle({0}, {1}, {2}, {3})",
                            a.x, a.y, b.x, b.y) 
    End Function
End Class 

Class Point
    Friend x As Integer
    Friend y As Integer
    
    Public Sub New(ByVal X As Integer, ByVal Y As Integer) 
        Me.x = X
        Me.y = Y
    End Sub 

    Public Overrides Function Equals(ByVal obj As [Object]) As Boolean 
        ' Performs an equality check on two points (integer pairs).
        If obj Is Nothing OrElse Not [GetType]().Equals(obj.GetType()) Then
            Return False
        Else
           Dim p As Point = CType(obj, Point)
           Return x = p.x AndAlso y = p.y
        End If
    End Function 
    
    Public Overrides Function GetHashCode() As Integer 
        Return Tuple.Create(x, y).GetHashCode()
    End Function 
End Class  

Class Example
    Public Shared Sub Main() 
        Dim r1 As New Rectangle(0, 0, 100, 200)
        Dim r2 As New Rectangle(0, 0, 100, 200)
        Dim r3 As New Rectangle(0, 0, 150, 200)
        
        Console.WriteLine("{0} = {1}: {2}", r1, r2, r1.Equals(r2))
        Console.WriteLine("{0} = {1}: {2}", r1, r3, r1.Equals(r3))
        Console.WriteLine("{0} = {1}: {2}", r2, r3, r2.Equals(r3))
    End Sub 
End Class 
' The example displays the following output:
'    Rectangle(0, 0, 100, 200) = Rectangle(0, 0, 100, 200): True
'    Rectangle(0, 0, 100, 200) = Rectangle(0, 0, 150, 200): False
'    Rectangle(0, 0, 100, 200) = Rectangle(0, 0, 150, 200): False
' </Snippet1>