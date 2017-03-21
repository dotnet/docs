private void PrintCurrentInputLanguage() {
    textBox1.Text = "The current input language is: " +
       Application.CurrentInputLanguage.Culture.EnglishName;
 }
   