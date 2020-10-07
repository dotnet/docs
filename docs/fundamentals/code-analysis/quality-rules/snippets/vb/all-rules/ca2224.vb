Imports System
Imports System.IO

Namespace ca2224
    '<snippet1>
    ' This class violates the rule.
    Public Class Point

        Public Property X As Integer
        Public Property Y As Integer

        Public Sub New(x As Integer, y As Integer)
            Me.X = x
            Me.Y = y
        End Sub

        Public Overrides Function GetHashCode() As Integer
            Return HashCode.Combine(X, Y)
        End Function

        Public Shared Operator =(pt1 As Point, pt2 As Point) As Boolean
            If pt1 Is Nothing OrElse pt2 Is Nothing Then
                Return False
            End If

            If pt1.GetType() <> pt2.GetType() Then
                Return False
            End If

            Return pt1.X = pt2.X AndAlso pt1.Y = pt2.Y
        End Operator

        Public Shared Operator <>(pt1 As Point, pt2 As Point) As Boolean
            Return Not pt1 = pt2
        End Operator

    End Class
    '</snippet1>
End Namespace

Namespace ca2224_2
    '<snippet2>
    ' This class satisfies the rule.
    Public Class Point

        Public Property X As Integer
        Public Property Y As Integer

        Public Sub New(x As Integer, y As Integer)
            Me.X = x
            Me.Y = y
        End Sub

        Public Overrides Function GetHashCode() As Integer
            Return HashCode.Combine(X, Y)
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean

            If obj = Nothing Then
                Return False
            End If

            If [GetType]() <> obj.GetType() Then
                Return False
            End If

            Dim pt As Point = CType(obj, Point)

            Return X = pt.X AndAlso Y = pt.Y

        End Function

        Public Shared Operator =(pt1 As Point, pt2 As Point) As Boolean
            ' Object.Equals calls Point.Equals(Object).
            Return Object.Equals(pt1, pt2)
        End Operator

        Public Shared Operator <>(pt1 As Point, pt2 As Point) As Boolean
            ' Object.Equals calls Point.Equals(Object).
            Return Not Object.Equals(pt1, pt2)
        End Operator

    End Class
    '</snippet2>
End Namespace
