 public void MyLayoutName() {
    // Gets the current input language.
    InputLanguage myCurrentLanguage = InputLanguage.CurrentInputLanguage;
 
    if(myCurrentLanguage != null) 
       textBox1.Text = "Layout: " + myCurrentLanguage.LayoutName;
    else
       textBox1.Text = "There is no current language";
 }
