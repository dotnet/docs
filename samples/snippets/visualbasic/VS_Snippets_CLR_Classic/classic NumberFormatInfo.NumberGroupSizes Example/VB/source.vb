' <Snippet1>
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Class SamplesNumberFormatInfo
    
    Public Shared Sub Main()
        
        ' Creates a new NumberFormatinfo.
        Dim myNfi As New NumberFormatInfo()
        
        ' Takes a long value.
        Dim myInt As Int64 = 123456789012345
        
        ' Displays the value with default formatting.
        Console.WriteLine("Default  " + ControlChars.Tab + ControlChars.Tab _
           + ":" + ControlChars.Tab + "{0}", myInt.ToString("N", myNfi))
        
        ' Displays the value with three elements in the GroupSize array.
        myNfi.NumberGroupSizes = New Integer() {2, 3, 4}
        Console.WriteLine("Grouping ( {0} )" + ControlChars.Tab + ":" _
           + ControlChars.Tab + "{1}", _
           PrintArraySet(myNfi.NumberGroupSizes), myInt.ToString("N", myNfi))
        
        ' Displays the value with zero as the last element in the GroupSize array.
        myNfi.NumberGroupSizes = New Integer() {2, 4, 0}
        Console.WriteLine("Grouping ( {0} )" + ControlChars.Tab + ":" _
           + ControlChars.Tab + "{1}", _
           PrintArraySet(myNfi.NumberGroupSizes), myInt.ToString("N", myNfi))
    End Sub
    
    
    Public Shared Function PrintArraySet(myArr() As Integer) As String
        Dim myStr As String = Nothing
        myStr = myArr(0).ToString()
        Dim i As Integer
        For i = 1 To myArr.Length - 1
            myStr += ", " + myArr(i).ToString()
        Next i
        Return myStr
    End Function
End Class

' This code produces the following output. 
' 
' Default                 :       123,456,789,012,345.00
' Grouping ( 2, 3, 4 )    :       12,3456,7890,123,45.00
' Grouping ( 2, 4, 0 )    :       123456789,0123,45.00 
' </Snippet1>
