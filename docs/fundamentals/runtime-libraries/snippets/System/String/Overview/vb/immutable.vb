' Visual Basic .NET Document
Option Strict On

' <Snippet15>
Imports System.IO
Imports System.Text

Module Example10
    Public Sub Main()
        Dim rnd As New Random()

        Dim str As String = String.Empty
        Dim sw As New StreamWriter(".\StringFile.txt",
                           False, Encoding.Unicode)

        For ctr As Integer = 0 To 1000
            str += ChrW(rnd.Next(1, &H530))
            If str.Length Mod 60 = 0 Then str += vbCrLf
        Next
        sw.Write(str)
        sw.Close()
    End Sub
End Module
' </Snippet15>


