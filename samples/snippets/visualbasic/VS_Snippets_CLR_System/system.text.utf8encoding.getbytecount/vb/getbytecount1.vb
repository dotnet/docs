' <Snippet1>
Imports System.Text

Module Example
    Public Sub Main()
        Dim chars As String = "UTF8 Encoding Example"
        Dim utf8 As Encoding = Encoding.UTF8

        Console.WriteLine("Bytes needed to encode '{0}':", chars)
        Console.WriteLine("   Maximum:         {0}",
                          utf8.GetMaxByteCount(chars.Length))
        Console.WriteLine("   Actual:          {0}",
                          utf8.GetByteCount(chars))
        Console.WriteLine("   Actual with BOM: {0}",
                          utf8.GetByteCount(chars) + utf8.GetPreamble().Length)
    End Sub
End Module
' The example displays the following output:
'       Bytes needed to encode 'UTF8 Encoding Example':
'          Maximum:         66
'          Actual:          21
'          Actual with BOM: 24
' </Snippet1>
