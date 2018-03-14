' <Snippet1>
Imports System.Text

Class Example
    Public Shared Sub Main()
        Dim utf8 As New UTF8Encoding()
        Dim utf8ThrowException As New UTF8Encoding(False, True)
        
        ' Create an array with two high surrogates in a row (\uD801, \uD802).
        Dim chars() As Char = {"a"c, "b"c, "c"c, ChrW(&hD801), ChrW(&hD802), "d"c}
        
        ' The following method call will not throw an exception.
        Dim bytes As Byte() = utf8.GetBytes(chars)
        ShowArray(bytes)
        Console.WriteLine()
        
        Try
            ' The following method call will throw an exception.
            bytes = utf8ThrowException.GetBytes(chars)
            ShowArray(bytes)
        Catch e As EncoderFallbackException
            Console.WriteLine("{0} exception{2}Message:{2}{1}",
                              e.GetType().Name, e.Message, vbCrLf)
        End Try
    End Sub
    
    
    Public Shared Sub ShowArray(theArray As Array)
        For Each o In theArray
            Console.Write("{0:X2} ", o)
        Next
        Console.WriteLine()
    End Sub
End Class
' The example displays the following output:
'    61 62 63 EF BF BD EF BF BD 64
'
'    EncoderFallbackException exception
'    Message:
'    Unable to translate Unicode character \uD801 at index 3 to specified code page.
' </Snippet1>
