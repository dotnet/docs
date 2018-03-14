'Types:System.Object Vendor: Richter
' <snippet1>
' The Point class is derived from System.Object.
Class Point
    Public x, y As Integer
    
    Public Sub New(ByVal x As Integer, ByVal y As Integer) 
        Me.x = x
        Me.y = y
    End Sub
    
    '<snippet2>
    Public Overrides Function Equals(ByVal obj As Object) As Boolean 
        ' If Me and obj do not refer to the same type, then they are not equal.
        Dim objType As Type = obj.GetType()
        Dim meType  As Type = Me.GetType()
        If Not objType.Equals(meType) Then
            Return False
        End If 
        ' Return true if  x and y fields match.
        Dim other As Point = CType(obj, Point)
        Return Me.x = other.x AndAlso Me.y = other.y
    End Function 
    '</snippet2>

    '<snippet3>
    ' Return the XOR of the x and y fields.
    Public Overrides Function GetHashCode() As Integer 
        Return (x << 1) XOr y
    End Function 
    '</snippet3>

    '<snippet4>
    ' Return the point's value as a string.
    Public Overrides Function ToString() As String 
        Return String.Format("({0}, {1})", x, y)
    End Function
    '</snippet4>

    '<snippet5>
    ' Return a copy of this point object by making a simple field copy.
    Public Function Copy() As Point 
        Return CType(Me.MemberwiseClone(), Point)
    End Function
End Class  
    '</snippet5>

NotInheritable Public Class App
    Shared Sub Main() 
        ' Construct a Point object.
        Dim p1 As New Point(1, 2)
        
        ' Make another Point object that is a copy of the first.
        Dim p2 As Point = p1.Copy()
        
        ' Make another variable that references the first Point object.
        Dim p3 As Point = p1
        
        '<snippet6>
        ' The line below displays false because p1 and p2 refer to two different objects.
        Console.WriteLine([Object].ReferenceEquals(p1, p2))
        '</snippet6>

        '<snippet7>
        ' The line below displays true because p1 and p2 refer to two different objects 
        ' that have the same value.
        Console.WriteLine([Object].Equals(p1, p2))
        '</snippet7>

        ' The line below displays true because p1 and p3 refer to one object.
        Console.WriteLine([Object].ReferenceEquals(p1, p3))
        
        '<snippet8> 
        ' The line below displays: p1's value is: (1, 2)
        Console.WriteLine("p1's value is: {0}", p1.ToString())
    
    End Sub
        '</snippet8>
End Class
' This example produces the following output:
'
' False
' True
' True
' p1's value is: (1, 2)
'
'</snippet1>
