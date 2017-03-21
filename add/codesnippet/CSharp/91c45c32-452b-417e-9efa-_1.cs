 public void SetNewCurrentLanguage() {
    // Gets the default, and current languages.
    InputLanguage myDefaultLanguage = InputLanguage.DefaultInputLanguage;
    InputLanguage myCurrentLanguage = InputLanguage.CurrentInputLanguage;
    textBox1.Text = "Current input language is: " +
        myCurrentLanguage.Culture.EnglishName + '\n';
    textBox1.Text += "Default input language is: " +
        myDefaultLanguage.Culture.EnglishName + '\n';
 
    //Print the new current input language.
    InputLanguage myCurrentLanguage2 = InputLanguage.CurrentInputLanguage;
    textBox1.Text += "New current input language is: " +
        myCurrentLanguage2.Culture.EnglishName;
}
