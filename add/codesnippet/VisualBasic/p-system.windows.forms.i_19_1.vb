 Public Sub MyDefaultInputLanguage()
    ' Gets the default input language  and prints it in a text box.
    Dim myDefaultLanguage As InputLanguage = InputLanguage.DefaultInputLanguage
    textBox1.Text = "Default input language is: " & _
        myDefaultLanguage.Culture.EnglishName
 End Sub
