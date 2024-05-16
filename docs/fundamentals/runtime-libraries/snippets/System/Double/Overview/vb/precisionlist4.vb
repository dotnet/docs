' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Imports System.IO

Module Example12
    Public Sub Main()
        Dim sw As New StreamWriter(".\Doubles.dat")
        Dim values() As Double = {2.2 / 1.01, 1.0 / 3, Math.PI}
        For ctr As Integer = 0 To values.Length - 1
            sw.Write(values(ctr).ToString())
            If ctr <> values.Length - 1 Then sw.Write("|")
        Next
        sw.Close()

        Dim restoredValues(values.Length - 1) As Double
        Dim sr As New StreamReader(".\Doubles.dat")
        Dim temp As String = sr.ReadToEnd()
        Dim tempStrings() As String = temp.Split("|"c)
        For ctr As Integer = 0 To tempStrings.Length - 1
            restoredValues(ctr) = Double.Parse(tempStrings(ctr))
        Next

        For ctr As Integer = 0 To values.Length - 1
            Console.WriteLine("{0} {2} {1}", values(ctr),
                           restoredValues(ctr),
                           If(values(ctr).Equals(restoredValues(ctr)), "=", "<>"))
        Next
    End Sub
End Module
' The example displays the following output:
'       2.17821782178218 <> 2.17821782178218
'       0.333333333333333 <> 0.333333333333333
'       3.14159265358979 <> 3.14159265358979
' </Snippet7>
