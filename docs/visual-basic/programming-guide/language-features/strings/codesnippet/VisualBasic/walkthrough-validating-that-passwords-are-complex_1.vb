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