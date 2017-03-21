 Public Sub MyCulture()
    ' Gets the current input language.
    Dim myCurrentLanguage As InputLanguage = InputLanguage.CurrentInputLanguage
        
    ' Gets the culture for the language  and prints it.
    Dim myCultureInfo As CultureInfo = myCurrentLanguage.Culture
    textBox1.Text = myCultureInfo.EnglishName
 End Sub
