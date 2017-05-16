' REDMOND\glennha
' <Snippet1>
Imports System.Drawing
Imports System.Collections.Generic

Public Class Example
    Public Shared Sub Main()
        ' Create an array of PointF objects.
        Dim apf() As PointF = { _
            New PointF(27.8, 32.62), _
            New PointF(99.3, 147.273), _
            New PointF(7.5, 1412.2)  }

        ' Display each element in the PointF array.
        Console.WriteLine()
        For Each p As PointF In apf
            Console.WriteLine(p)
        Next
        
        ' Convert each PointF element to a Point object.
        Dim ap() As Point = Array.ConvertAll(apf, _
            New Converter(Of PointF, Point)(AddressOf PointFToPoint))

        ' Display each element in the Point array.
        Console.WriteLine()
        For Each p As Point In ap
            Console.WriteLine(p)
        Next
    End Sub

    Public Shared Function PointFToPoint(ByVal pf As PointF) _
        As Point

        Return New Point(CInt(pf.X), CInt(pf.Y))
    End Function
End Class
' The example produces the following output:
'       {X=27.8, Y=32.62}
'       {X=99.3, Y=147.273}
'       {X=7.5, Y=1412.2}
'       
'       {X=28,Y=33}
'       {X=99,Y=147}
'       {X=8,Y=1412}
' </Snippet1>
