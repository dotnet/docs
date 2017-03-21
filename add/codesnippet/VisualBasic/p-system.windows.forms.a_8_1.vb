 Private Sub PrintCurrentInputLanguage()
    textBox1.Text = "The current input language is: " & _
       Application.CurrentInputLanguage.Culture.EnglishName
 End Sub
   