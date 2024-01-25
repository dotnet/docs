﻿' <Snippet1>
Class Point
    Protected x, y As Integer
    
    Public Sub New() 
        Me.x = 0
        Me.y = 0
    End Sub
    
    Public Sub New(x As Integer, y As Integer) 
        Me.x = x
        Me.y = y
    End Sub 

    Public Overrides Function Equals(obj As Object) As Boolean 
        ' Check for null and compare run-time types.
        If obj Is Nothing OrElse Not Me.GetType().Equals(obj.GetType()) Then
           Return False
        Else
           Dim p As Point = DirectCast(obj, Point)
           Return x = p.x AndAlso y = p.y
        End If
    End Function 

    Public Overrides Function GetHashCode() As Integer 
        Return (x << 2) XOr y
    End Function

    Public Overrides Function ToString() As String
        Return String.Format("Point({0}, {1})", x, y)
    End Function
End Class

Class Point3D : Inherits Point
    Private z As Integer
    
    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal z As Integer) 
        MyBase.New(x, y) 
        Me.z = Z
    End Sub

    Public Overrides Function Equals(ByVal obj As Object) As Boolean 
        Dim pt3 As Point3D = TryCast(obj, Point3D)
        If pt3 Is Nothing Then
           Return False
        Else
           Return MyBase.Equals(CType(pt3, Point)) AndAlso z = pt3.Z  
        End If
    End Function
    
    Public Overrides Function GetHashCode() As Integer 
        Return (MyBase.GetHashCode() << 2) XOr z
    End Function 
    
    Public Overrides Function ToString() As String
        Return String.Format("Point({0}, {1}, {2})", x, y, z)
    End Function
End Class 

Module Example
    Public Sub Main() 
        Dim point2D As New Point(5, 5)
        Dim point3Da As New Point3D(5, 5, 2)
        Dim point3Db As New Point3D(5, 5, 2)
        Dim point3Dc As New Point3D(5, 5, -1)
        
        Console.WriteLine("{0} = {1}: {2}", 
                          point2D, point3Da, point2D.Equals(point3Da))
        Console.WriteLine("{0} = {1}: {2}", 
                          point2D, point3Db, point2D.Equals(point3Db))        
        Console.WriteLine("{0} = {1}: {2}", 
                          point3Da, point3Db, point3Da.Equals(point3Db))
        Console.WriteLine("{0} = {1}: {2}", 
                          point3Da, point3Dc, point3Da.Equals(point3Dc))
    End Sub  
End Module 
' The example displays the following output
'       Point(5, 5) = Point(5, 5, 2): False
'       Point(5, 5) = Point(5, 5, 2): False
'       Point(5, 5, 2) = Point(5, 5, 2): True
'       Point(5, 5, 2) = Point(5, 5, -1): False
' </Snippet1>