public void SetNewCurrentLanguage() {
    // Gets the default, and current languages.
    InputLanguage myDefaultLanguage = InputLanguage.DefaultInputLanguage;
    InputLanguage myCurrentLanguage = InputLanguage.CurrentInputLanguage;
    textBox1.Text = "Current input language is: " + myCurrentLanguage.Culture.EnglishName + '\n';
    textBox1.Text += "Default input language is: " + myDefaultLanguage.Culture.EnglishName + '\n';
 
    // Changes the current input language to the default, and prints the new current language.
    InputLanguage.CurrentInputLanguage = myDefaultLanguage;
    textBox1.Text += "Current input language is now: " + myDefaultLanguage.Culture.EnglishName;
}