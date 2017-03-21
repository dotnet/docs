public:
   void MyCurrentInputLanguage()
   {
      // Gets the current input language  and prints it in a text box.
      InputLanguage^ myCurrentLanguage = InputLanguage::CurrentInputLanguage;
      textBox1->Text = String::Format( "Current input language is: {0}",
         myCurrentLanguage->Culture->EnglishName );
   }