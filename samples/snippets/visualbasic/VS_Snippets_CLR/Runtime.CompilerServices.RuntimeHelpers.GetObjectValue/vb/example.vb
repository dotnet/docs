'<snippet1>
Imports System.Runtime.CompilerServices

' Declare a value type.
Structure Point2I

    Dim x As Integer
    Dim y As Integer
End Structure

Module Program

    Sub Main(ByVal args() As String)


        ' Allocate an unboxed Point2I (not on the heap).
        Dim pnt As Point2I
        pnt.x = 0
        pnt.y = 0

        ' Box the value.  (Put it in the heap.)
        Dim objPntr As Object = RuntimeHelpers.GetObjectValue(pnt)
    End Sub


End Module
'</snippet1>