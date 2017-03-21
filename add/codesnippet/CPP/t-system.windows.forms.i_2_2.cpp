public:
   void SetNewCurrentLanguage()
   {
      
      // Gets the default, and current languages.
      InputLanguage^ myDefaultLanguage = InputLanguage::DefaultInputLanguage;
      InputLanguage^ myCurrentLanguage = InputLanguage::CurrentInputLanguage;
      textBox1->Text = String::Format( "Current input language is: {0}\nDefault input language is: {1}\n",
         myCurrentLanguage->Culture->EnglishName, myDefaultLanguage->Culture->EnglishName );
      
      // Changes the current input language to the default, and prints the new current language.
      InputLanguage::CurrentInputLanguage = myDefaultLanguage;
      textBox1->Text = String::Format( "{0}Current input language is now: {1}",
         textBox1->Text, myDefaultLanguage->Culture->EnglishName );
   }