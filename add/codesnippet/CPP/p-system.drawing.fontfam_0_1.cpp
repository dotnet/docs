private:
   void PopulateListBoxWithFonts()
   {
      listBox1->Width = 200;
      listBox1->Location = Point(40,120);
      System::Collections::IEnumerator^ myEnum = FontFamily::Families->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         FontFamily^ oneFontFamily = safe_cast<FontFamily^>(myEnum->Current);
         listBox1->Items->Add( oneFontFamily->Name );
      }
   }