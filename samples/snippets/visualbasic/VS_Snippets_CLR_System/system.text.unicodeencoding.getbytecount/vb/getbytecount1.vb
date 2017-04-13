' <Snippet1>
Imports System.Text

Module Example
    Public Sub Main()
        Dim chars As String = "UTF-16 Encoding Example"
        Dim unicode As Encoding = Encoding.Unicode

        Console.WriteLine("Bytes needed to encode '{0}':", chars)
        Console.WriteLine("   Maximum:         {0}",
                          unicode.GetMaxByteCount(chars.Length))
        Console.WriteLine("   Actual:          {0}",
                          unicode.GetByteCount(chars))
        Console.WriteLine("   Actual with BOM: {0}",
                          unicode.GetByteCount(chars) + unicode.GetPreamble().Length)
    End Sub
End Module
' The example displays the following output:
'       Bytes needed to encode 'UTF-16 Encoding Example':
'          Maximum:         48
'          Actual:          46
'          Actual with BOM: 48
' </Snippet1>
