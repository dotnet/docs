' <Snippet1>
Imports System.Text

Module Example
    Public Sub Main()
        Dim chars As String = "UTF-32 Encoding Example"
        Dim enc As Encoding = Encoding.UTF32

        Console.WriteLine("Bytes needed to encode '{0}':", chars)
        Console.WriteLine("   Maximum:         {0}",
                          enc.GetMaxByteCount(chars.Length))
        Console.WriteLine("   Actual:          {0}",
                          enc.GetByteCount(chars))
        Console.WriteLine("   Actual with BOM: {0}",
                          enc.GetByteCount(chars) + enc.GetPreamble().Length)
    End Sub
End Module
' The example displays the following output:
'       Bytes needed to encode 'UTF-32 Encoding Example':
'          Maximum:         96
'          Actual:          92
'          Actual with BOM: 96
' </Snippet1>
