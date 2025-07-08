' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example1
    Public Sub Main()
        Dim values() As Short = {Int16.MinValue, -27, 0, 1042, Int16.MaxValue}
        Console.WriteLine("{0,10}  {1,10}", "Decimal", "Hex")
        Console.WriteLine()
        For Each value As Short In values
            Dim formatString As String = String.Format("{0,10:G}: {0,10:X}", value)
            Console.WriteLine(formatString)
        Next
    End Sub
End Module
' The example displays the following output:
'       Decimal         Hex
'    
'        -32768:       8000
'           -27:       FFE5
'             0:          0
'          1042:        412
'         32767:       7FFF
' </Snippet1>
