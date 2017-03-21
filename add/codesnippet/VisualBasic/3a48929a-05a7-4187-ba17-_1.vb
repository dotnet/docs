    ' Throws an exception if the specified name does not contain 
    ' all valid character types.
    Public Sub ValidateName(ByVal name As String) Implements INameCreationService.ValidateName
        Dim i As Integer
        For i = 0 To name.Length - 1
            Dim ch As Char = name.Chars(i)
            Dim uc As UnicodeCategory = [Char].GetUnicodeCategory(ch)
            Select Case uc
                Case UnicodeCategory.UppercaseLetter, UnicodeCategory.LowercaseLetter, UnicodeCategory.TitlecaseLetter, UnicodeCategory.DecimalDigitNumber
                Case Else
                    Throw New Exception("The name '" + name + "' is not a valid identifier.")
            End Select
        Next i
    End Sub