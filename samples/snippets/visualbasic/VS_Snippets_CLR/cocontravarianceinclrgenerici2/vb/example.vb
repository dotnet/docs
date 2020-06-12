'<Snippet1>
Imports System.Collections.Generic

MustInherit Class Shape
    Public MustOverride ReadOnly Property Area As Double
End Class

Class Circle
    Inherits Shape

    Private r As Double
    Public Sub New(ByVal radius As Double)
        r = radius
    End Sub
    Public ReadOnly Property Radius As Double
        Get
            Return r
        End Get
    End Property
    Public Overrides ReadOnly Property Area As Double
        Get
            Return Math.Pi * r * r
        End Get
    End Property
End Class

Class ShapeAreaComparer
    Implements System.Collections.Generic.IComparer(Of Shape)

    Private Function AreaComparer(ByVal a As Shape, ByVal b As Shape) As Integer _
            Implements System.Collections.Generic.IComparer(Of Shape).Compare
        If a Is Nothing Then Return If(b Is Nothing, 0, -1)
        Return If(b Is Nothing, 1, a.Area.CompareTo(b.Area))
    End Function
End Class

Class Program
    Shared Sub Main()
        ' You can pass ShapeAreaComparer, which implements IComparer(Of Shape),
        ' even though the constructor for SortedSet(Of Circle) expects 
        ' IComparer(Of Circle), because type parameter T of IComparer(Of T)
        ' is contravariant.
        Dim circlesByArea As New SortedSet(Of Circle)(New ShapeAreaComparer()) _
            From {New Circle(7.2), New Circle(100), Nothing, New Circle(.01)}

        For Each c As Circle In circlesByArea
            Console.WriteLine(If(c Is Nothing, "Nothing", "Circle with area " & c.Area))
        Next
    End Sub
End Class

' This code example produces the following output:
'
'Nothing
'Circle with area 0.000314159265358979
'Circle with area 162.860163162095
'Circle with area 31415.9265358979
'</Snippet1>
