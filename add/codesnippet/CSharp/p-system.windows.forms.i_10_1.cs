 public void MyCurrentInputLanguage() {
    // Gets the current input language  and prints it in a text box.
    InputLanguage myCurrentLanguage = InputLanguage.CurrentInputLanguage;
    textBox1.Text = "Current input language is: " +
        myCurrentLanguage.Culture.EnglishName;
 }
