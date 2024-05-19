' Visual Basic .NET Document
Option Strict On

' <Snippet18>
Imports System.IO

Module Example12
    Public Sub Main()
        Dim sw As New StreamWriter(".\Singles.dat")
        Dim values() As Single = {3.2 / 1.11, 1.0 / 3, CSng(Math.PI)}
        For ctr As Integer = 0 To values.Length - 1
            sw.Write("{0:G9}{1}", values(ctr),
                  If(ctr < values.Length - 1, "|", ""))
        Next
        sw.Close()

        Dim restoredValues(values.Length - 1) As Single
        Dim sr As New StreamReader(".\Singles.dat")
        Dim temp As String = sr.ReadToEnd()
        Dim tempStrings() As String = temp.Split("|"c)
        For ctr As Integer = 0 To tempStrings.Length - 1
            restoredValues(ctr) = Single.Parse(tempStrings(ctr))
        Next

        For ctr As Integer = 0 To values.Length - 1
            Console.WriteLine("{0} {2} {1}", values(ctr),
                           restoredValues(ctr),
                           If(values(ctr).Equals(restoredValues(ctr)), "=", "<>"))
        Next
    End Sub
End Module
' The example displays the following output:
'       2.882883 = 2.882883
'       0.3333333 = 0.3333333
'       3.141593 = 3.141593
' </Snippet18>
