' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Imports System.Globalization
Imports System.Text.RegularExpressions

Public Class RegexUtilities

    Public Shared Function IsValidEmail(email As String) As Boolean

        If String.IsNullOrWhiteSpace(email) Then Return False

        ' Use IdnMapping class to convert Unicode domain names.
        Try
            'Examines the domain part of the email and normalizes it.
            Dim DomainMapper =
                Function(match As Match) As String

                    'Use IdnMapping class to convert Unicode domain names.
                    Dim idn = New IdnMapping

                    'Pull out and process domain name (throws ArgumentException on invalid)
                    Dim domainName As String = idn.GetAscii(match.Groups(2).Value)

                    Return match.Groups(1).Value & domainName
                    
                End Function

            'Normalize the domain
            email = Regex.Replace(email, "(@)(.+)$", DomainMapper,
                                  RegexOptions.None, TimeSpan.FromMilliseconds(200))

        Catch e As RegexMatchTimeoutException
            Return False

        Catch e As ArgumentException
            Return False

        End Try

        Try
            Return Regex.IsMatch(email,
                                 "^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                 "(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                                 RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))

        Catch e As RegexMatchTimeoutException
            Return False

        End Try

    End Function

End Class
' </Snippet7>

' <Snippet8>
Public Class Application
   Public Shared Sub Main()
      Dim emailAddresses() As String = {"david.jones@proseware.com", "d.j@server1.proseware.com",
                                       "jones@ms1.proseware.com", "j.@server1.proseware.com",
                                       "j@proseware.com9", "js#internal@proseware.com",
                                       "j_9@[129.126.118.1]", "j..s@proseware.com",
                                       "js*@proseware.com", "js@proseware..com",
                                       "js@proseware.com9", "j.s@server1.proseware.com",
                                       """j\""s\""""@proseware.com", "js@contoso.中国"}

      For Each emailAddress As String In emailAddresses
         If RegexUtilities.IsValidEmail(emailAddress) Then
               Console.WriteLine($"Valid:   {emailAddress}")
         Else
               Console.WriteLine($"Invalid: {emailAddress}")
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
'       Valid: "j\"s\""@proseware.com
'       Valid: js@contoso.中国
' </Snippet8>