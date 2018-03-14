' <Snippet1>
Imports System.Globalization

Module Example
    Public Sub Main()
        ' Creates a new NumberFormatinfo.
        Dim nfi As New NumberFormatInfo()
        
        ' Define a negative value.
        Dim value As Int64 = -1234
        
        ' Display the value with default formatting.
        Console.WriteLine("{0,-20} {1,-10}", "Default:", 
                          value.ToString("N", nfi))
        
        ' Display the value with other patterns.
        For i As Integer = 0 To 4
            nfi.NumberNegativePattern = i
            Console.WriteLine("{0,-20} {1,-10}", 
                              String.Format("Pattern {0}:", 
                                            nfi.NumberNegativePattern), 
                              value.ToString("N", nfi))
        Next 
    End Sub
End Module
' The example displays the following output:
'       Default:             -1,234.00
'       Pattern 0:           (1,234.00)
'       Pattern 1:           -1,234.00
'       Pattern 2:           - 1,234.00
'       Pattern 3:           1,234.00-
'       Pattern 4:           1,234.00 -
' </Snippet1>
