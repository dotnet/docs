' <Snippet1>
Imports System
Imports System.IO

Public Class SWBuff

    Public Shared Sub Main()
        Dim sb As New FileStream("MyFile.txt", FileMode.OpenOrCreate)
        Dim b As Char() = {"a"c, "b"c, "c"c, "d"c, "e"c, "f"c, "g"c, _
           "h"c, "i"c, "j"c, "k"c, "l"c, "m"c}
        Dim sw As New StreamWriter(sb)
        sw.Write(b, 3, 8)
        sw.Close()
    End Sub
End Class
' </Snippet1>