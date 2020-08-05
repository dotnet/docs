' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Globalization
Imports System.Text.RegularExpressions

Public Class RegexUtilities
    Dim invalid As Boolean = False

    public Function IsValidEmail(strIn As String) As Boolean
        invalid = False
        If String.IsNullOrEmpty(strIn) Then Return False

        ' Use IdnMapping class to convert Unicode domain names.
        Try
            strIn = Regex.Replace(strIn, "(@)(.+)$", AddressOf Me.DomainMapper,
                                  RegexOptions.None, TimeSpan.FromMilliseconds(200))
        Catch e As RegexMatchTimeoutException
            Return False
        End Try

        If invalid Then Return False

        ' Return true if strIn is in valid email format.
        Try
            Return Regex.IsMatch(strIn, _
                   "^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + _
                   "(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,24}))$",
                   RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))
        Catch e As RegexMatchTimeoutException
            Return False
        End Try
    End Function

    Private Function DomainMapper(match As Match) As String
        ' IdnMapping class with default property values.
        Dim idn As New IdnMapping()

        Dim domainName As String = match.Groups(2).Value
        Try
            domainName = idn.GetAscii(domainName)
        Catch e As ArgumentException
            invalid = True
        End Try
        Return match.Groups(1).Value + domainName
    End Function
End Class
' </Snippet5>

' <Snippet6>
Public Class Application
    Public Shared Sub Main()
        Dim util As New RegexUtilities()
        Dim emailAddresses() As String = {"david.jones@proseware.com", "d.j@server1.proseware.com", _
                                           "jones@ms1.proseware.com", "j.@server1.proseware.com", _
                                           "j@proseware.com9", "js#internal@proseware.com", _
                                           "j_9@[129.126.118.1]", "j..s@proseware.com", _
                                           "js*@proseware.com", "js@proseware..com", _
                                           "js@proseware.com9", "j.s@server1.proseware.com"}

        For Each emailAddress As String In emailAddresses
            If util.IsValidEmail(emailAddress) Then
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
'       Valid: j@proseware.com9
'       Valid: js#internal@proseware.com
'       Valid: j_9@[129.126.118.1]
'       Invalid: j..s@proseware.com
'       Invalid: js*@proseware.com
'       Invalid: js@proseware..com
'       Valid: js@proseware.com9
'       Valid: j.s@server1.proseware.com
' </Snippet6>
