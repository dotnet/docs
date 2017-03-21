   DateTime july28 = DateTime(2009, 7, 28, 5, 23, 15, 16);
   array<String^>^july28Formats = july28.GetDateTimeFormats();
   
   // Print [Out] july28* in all DateTime formats using the default culture.
   System::Collections::IEnumerator^ myEnum = july28Formats->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      String^ format = safe_cast<String^>(myEnum->Current);
      System::Console::WriteLine( format );
   }