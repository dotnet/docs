Option Explicit On
Option Strict On

Class Class5d9a918f6c1f41a3a019b5c2b8ce0381

    ' 5d9a918f-6c1f-41a3-a019-b5c2b8ce0381
    ' Walkthrough: Validate That Passwords Are Complex (Visual Basic)
    ' <snippet1>
    ''' <summary>Determines if a password is sufficiently complex.</summary>
    ''' <param name="pwd">Password to validate</param>
    ''' <param name="minLength">Minimum number of password characters.</param>
    ''' <param name="numUpper">Minimum number of uppercase characters.</param>
    ''' <param name="numLower">Minimum number of lowercase characters.</param>
    ''' <param name="numNumbers">Minimum number of numeric characters.</param>
    ''' <param name="numSpecial">Minimum number of special characters.</param>
    ''' <returns>True if the password is sufficiently complex.</returns>
    Function ValidatePassword(ByVal pwd As String, 
        Optional ByVal minLength As Integer = 8, 
        Optional ByVal numUpper As Integer = 2, 
        Optional ByVal numLower As Integer = 2, 
        Optional ByVal numNumbers As Integer = 2, 
        Optional ByVal numSpecial As Integer = 2) As Boolean

        ' Replace [A-Z] with \p{Lu}, to allow for Unicode uppercase letters.
        Dim upper As New System.Text.RegularExpressions.Regex("[A-Z]")
        Dim lower As New System.Text.RegularExpressions.Regex("[a-z]")
        Dim number As New System.Text.RegularExpressions.Regex("[0-9]")
        ' Special is "none of the above".
        Dim special As New System.Text.RegularExpressions.Regex("[^a-zA-Z0-9]")

        ' Check the length.
        If Len(pwd) < minLength Then Return False
        ' Check for minimum number of occurrences.
        If upper.Matches(pwd).Count < numUpper Then Return False
        If lower.Matches(pwd).Count < numLower Then Return False
        If number.Matches(pwd).Count < numNumbers Then Return False
        If special.Matches(pwd).Count < numSpecial Then Return False

        ' Passed all checks.
        Return True
    End Function

    Sub TestValidatePassword()
        Dim password As String = "Password"
        ' Demonstrate that "Password" is not complex.
        MsgBox(password & " is complex: " & ValidatePassword(password))

        password = "Z9f%a>2kQ"
        ' Demonstrate that "Z9f%a>2kQ" is not complex.
        MsgBox(password & " is complex: " & ValidatePassword(password))
    End Sub
    ' </snippet1>

    ' ae7d4b29-3436-4032-bdbf-4650eb1c8e19
    ' How to: Validate Strings That Represent Dates or Times (Visual Basic)
    Public Sub Method2()
        ' <snippet2>
        Dim isValidDate As Boolean = IsDate("01/01/03")
        Dim isValidTime As Boolean = IsDate("9:30 PM")
        ' </snippet2>
    End Sub

    ' c629e979-9129-48fa-99b2-aff12d1cd4d7
    ' How to: Validate Strings That Represent E-Mail Addresses (Visual Basic)
    ' <snippet3>
    Function ValidateEmail(ByVal email As String) As Boolean
        Dim emailRegex As New System.Text.RegularExpressions.Regex( 
            "^(?<user>[^@]+)@(?<host>.+)$")
        Dim emailMatch As System.Text.RegularExpressions.Match = 
           emailRegex.Match(email)
        Return emailMatch.Success
    End Function
    ' </snippet3>

    ' f673462d-57b7-4120-b13a-6a7592f7ab2c
    ' How to: Validate File Names and Paths in Visual Basic
    ' <snippet4>
    Function IsValidFileNameOrPath(ByVal name As String) As Boolean
        ' Determines if the name is Nothing.
        If name Is Nothing Then
            Return False
        End If

        ' Determines if there are bad characters in the name.
        For Each badChar As Char In System.IO.Path.GetInvalidPathChars
            If InStr(name, badChar) > 0 Then
                Return False
            End If
        Next

        ' The name passes basic validation.
        Return True
    End Function
    ' </snippet4>

End Class


