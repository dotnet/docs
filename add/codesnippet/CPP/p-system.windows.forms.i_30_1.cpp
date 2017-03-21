public:
   void MyLayoutName()
   {
      // Gets the current input language.
      InputLanguage^ myCurrentLanguage = InputLanguage::CurrentInputLanguage;

      if ( myCurrentLanguage != nullptr )
      {
         textBox1->Text = String::Format( "Layout: {0}", myCurrentLanguage->LayoutName );
      }
      else
      {
         textBox1->Text = "There is no current language";
      }
   }