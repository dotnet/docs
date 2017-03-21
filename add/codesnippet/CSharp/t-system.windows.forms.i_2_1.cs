public void GetLanguages() {
    // Gets the list of installed languages.
    foreach(InputLanguage lang in InputLanguage.InstalledInputLanguages) {
       textBox1.Text += lang.Culture.EnglishName + '\n';
    }
}