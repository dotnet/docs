Imports System.IO
Imports System.Threading

Public Class ca2022
    ' <Snippet1>
    Shared Sub M(stream As Stream, buffer As Byte())
        ' CA2022 violation.
        stream.Read(buffer, 0, buffer.Length)

        ' Fix for the violation.
        stream.ReadExactly(buffer)
    End Sub
    ' </Snippet1>

End Class
