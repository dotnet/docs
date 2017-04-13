' <Snippet1>
Imports System.Text

Module Example
    Public Sub Main()
        ' The default constructor does not provide a preamble.
        Dim UTF8NoPreamble As New UTF8Encoding()
        Dim UTF8WithPreamble As New UTF8Encoding(True)
        
        Dim preamble() As Byte
        
        preamble = UTF8NoPreamble.GetPreamble()
        Console.WriteLine("UTF8NoPreamble")
        Console.WriteLine(" preamble length: {0}", preamble.Length)
        Console.Write(" preamble: ")
        ShowArray(preamble)
        Console.WriteLine()
        
        preamble = UTF8WithPreamble.GetPreamble()
        Console.WriteLine("UTF8WithPreamble")
        Console.WriteLine(" preamble length: {0}", preamble.Length)
        Console.Write(" preamble: ")
        ShowArray(preamble)
    End Sub

    Public Sub ShowArray(bytes As Byte())
        For Each b In  bytes
            Console.Write("{0:X2} ", b)
        Next
        Console.WriteLine()
    End Sub
End Module
' The example displays the following output:
'    UTF8NoPreamble
'     preamble length: 0
'     preamble:
'
'    UTF8WithPreamble
'     preamble length: 3
'     preamble: EF BB BF
' </Snippet1>
