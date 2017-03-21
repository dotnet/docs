public:
   void MyCulture()
   {
      // Gets the current input language.
      InputLanguage^ myCurrentLanguage = InputLanguage::CurrentInputLanguage;
      
      // Gets the culture for the language  and prints it.
      CultureInfo^ myCultureInfo = myCurrentLanguage->Culture;
      textBox1->Text = myCultureInfo->EnglishName;
   }