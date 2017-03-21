 public void MyDefaultInputLanguage() {
    // Gets the default input language  and prints it in a text box.
    InputLanguage myDefaultLanguage = InputLanguage.DefaultInputLanguage;
    textBox1.Text = "Default input language is: " + myDefaultLanguage.Culture.EnglishName;
 }
