Namespace ca2218
    '<snippet1>
    ' This class violates the rule.
    Public Class Point

        Public Property X As Integer
        Public Property Y As Integer

        Public Sub New(x As Integer, y As Integer)
            Me.X = x
            Me.Y = y
        End Sub

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

    End Class
    '</snippet1>
End Namespace

Namespace ca2218_fix
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
            Return X Or Y
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean

            If obj = Nothing Then
                Return False
            End If

            If [GetType]() <> obj.GetType() Then
                Return False
            End If

            Dim pt As Point = CType(obj, Point)

            Return Equals(pt)

        End Function

        Public Overloads Function Equals(pt As Point) As Boolean
            Return X = pt.X AndAlso Y = pt.Y
        End Function

        Public Shared Operator =(pt1 As Point, pt2 As Point) As Boolean
            Return pt1.Equals(pt2)
        End Operator

        Public Shared Operator <>(pt1 As Point, pt2 As Point) As Boolean
            Return Not pt1.Equals(pt2)
        End Operator

    End Class
    '</snippet2>
End Namespace
