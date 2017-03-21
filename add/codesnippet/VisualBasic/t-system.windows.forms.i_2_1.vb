    Public Sub GetLanguages()
        ' Gets the list of installed languages.
        Dim lang As InputLanguage
        For Each lang In  InputLanguage.InstalledInputLanguages
            textBox1.Text &= lang.Culture.EnglishName & ControlChars.Cr
        Next lang
    End Sub 'GetLanguages
    