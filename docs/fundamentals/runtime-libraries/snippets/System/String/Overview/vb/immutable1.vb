' Visual Basic .NET Document
Option Strict On

' <Snippet16>
Imports System.IO
Imports System.Text

Module Example11
    Public Sub Main()
        Dim rnd As New Random()
        Dim sb As New StringBuilder()
        Dim sw As New StreamWriter(".\StringFile.txt",
                                 False, Encoding.Unicode)

        For ctr As Integer = 0 To 1000
            sb.Append(ChrW(rnd.Next(1, &H530)))
            If sb.Length Mod 60 = 0 Then sb.AppendLine()
        Next
        sw.Write(sb.ToString())
        sw.Close()
    End Sub
End Module
' </Snippet16>

