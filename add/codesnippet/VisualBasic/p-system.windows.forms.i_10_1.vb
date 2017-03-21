 Public Sub MyCurrentInputLanguage()
    ' Gets the current input language  and prints it in a text box.
    Dim myCurrentLanguage As InputLanguage = InputLanguage.CurrentInputLanguage
    textBox1.Text = "Current input language is: " & _
        myCurrentLanguage.Culture.EnglishName
 End Sub
