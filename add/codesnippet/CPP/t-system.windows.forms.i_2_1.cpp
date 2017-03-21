public:
   void GetLanguages()
   {
      // Gets the list of installed languages.
      for each ( InputLanguage^ lang in InputLanguage::InstalledInputLanguages )
      {
         textBox1->Text = String::Concat( textBox1->Text, lang->Culture->EnglishName, "\n" );
      }
   }