    ' Returns whether the specified name contains 
    ' all valid character types.
    Public Function IsValidName(ByVal name As String) As Boolean Implements INameCreationService.IsValidName
        Dim i As Integer
        For i = 0 To name.Length - 1
            Dim ch As Char = name.Chars(i)
            Dim uc As UnicodeCategory = [Char].GetUnicodeCategory(ch)
            Select Case uc
                Case UnicodeCategory.UppercaseLetter, UnicodeCategory.LowercaseLetter, UnicodeCategory.TitlecaseLetter, UnicodeCategory.DecimalDigitNumber
                Case Else
                    Return False
            End Select
        Next i
        Return True
    End Function