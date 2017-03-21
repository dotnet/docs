public:
   void MyDefaultInputLanguage()
   {
      // Gets the default input language  and prints it in a text box.
      InputLanguage^ myDefaultLanguage = InputLanguage::DefaultInputLanguage;
      textBox1->Text = String::Format( "Default input language is: {0}",
         myDefaultLanguage->Culture->EnglishName );
   }