' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Text.RegularExpressions

Module RegexUtilities
    Function IsValidEmail(strIn As String) As Boolean
        ' Return true if strIn is in valid email format.
        Return Regex.IsMatch(strIn, _
               "^(?("")(""[^""]+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + _
               "(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$")
    End Function
End Module
' </Snippet3>

' <Snippet4>
Public Class Application
    Public Shared Sub Main()
        Dim emailAddresses() As String = {"david.jones@proseware.com", "d.j@server1.proseware.com", _
                                           "jones@ms1.proseware.com", "j.@server1.proseware.com", _
                                           "j@proseware.com9", "js#internal@proseware.com", _
                                           "j_9@[129.126.118.1]", "j..s@proseware.com", _
                                           "js*@proseware.com", "js@proseware..com", _
                                           "js@proseware.com9", "j.s@server1.proseware.com"}

        For Each emailAddress As String In emailAddresses
            If RegexUtilities.IsValidEmail(emailAddress) Then
                Console.WriteLine("Valid: {0}", emailAddress)
            Else
                Console.WriteLine("Invalid: {0}", emailAddress)
            End If
        Next
    End Sub
End Class
' The example displays the following output:
'       Valid: david.jones@proseware.com
'       Valid: d.j@server1.proseware.com
'       Valid: jones@ms1.proseware.com
'       Invalid: j.@server1.proseware.com
'       Invalid: j@proseware.com9
'       Valid: js#internal@proseware.com
'       Valid: j_9@[129.126.118.1]
'       Invalid: j..s@proseware.com
'       Invalid: js*@proseware.com
'       Invalid: js@proseware..com
'       Invalid: js@proseware.com9
'       Valid: j.s@server1.proseware.com
' </Snippet4>
