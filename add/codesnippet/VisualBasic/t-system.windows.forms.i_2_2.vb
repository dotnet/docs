    Public Sub SetNewCurrentLanguage()
        ' Gets the default, and current languages.
        Dim myDefaultLanguage As InputLanguage = InputLanguage.DefaultInputLanguage
        Dim myCurrentLanguage As InputLanguage = InputLanguage.CurrentInputLanguage
        textBox1.Text = "Current input language is: " & _
            myCurrentLanguage.Culture.EnglishName & ControlChars.Cr
            
        textBox1.Text &= "Default input language is: " & _
            myDefaultLanguage.Culture.EnglishName & ControlChars.Cr
        
        ' Changes the current input language to the default, and prints the new current language.
        InputLanguage.CurrentInputLanguage = myDefaultLanguage
        textBox1.Text &= "Current input language is now: " & _
            myDefaultLanguage.Culture.EnglishName
    End Sub 'SetNewCurrentLanguage