' REDMOND\glennha
' <Snippet1>
Imports System
Imports System.Drawing
Imports System.Collections.Generic

Public Class Example

    Public Shared Sub Main()

        Dim lpf As New List(Of PointF)

        lpf.Add(New PointF(27.8, 32.62))
        lpf.Add(New PointF(99.3, 147.273))
        lpf.Add(New PointF(7.5, 1412.2))

        Console.WriteLine()
        For Each p As PointF In lpf
            Console.WriteLine(p)
        Next

        Dim lp As List(Of Point) = lpf.ConvertAll( _
            New Converter(Of PointF, Point)(AddressOf PointFToPoint))

        Console.WriteLine()
        For Each p As Point In lp
            Console.WriteLine(p)
        Next

    End Sub

    Public Shared Function PointFToPoint(ByVal pf As PointF) _
        As Point

        Return New Point(CInt(pf.X), CInt(pf.Y))
    End Function
End Class

' This code example produces the following output:
'
'{X=27.8, Y=32.62}
'{X=99.3, Y=147.273}
'{X=7.5, Y=1412.2}
'
'{X=28,Y=33}
'{X=99,Y=147}
'{X=8,Y=1412}
' </Snippet1>