' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim pattern As String = "(Mr\.? |Mrs\.? |Miss |Ms\.? )"
        Dim names() As String = {"Mr. Henry Hunt", "Ms. Sara Samuels", _
                                  "Abraham Adams", "Ms. Nicole Norris"}
        For Each name As String In names
            Console.WriteLine(Regex.Replace(name, pattern, String.Empty))
        Next
    End Sub
End Module
' The example displays the following output:
'    Henry Hunt
'    Sara Samuels
'    Abraham Adams
'    Nicole Norris
' </Snippet2>
