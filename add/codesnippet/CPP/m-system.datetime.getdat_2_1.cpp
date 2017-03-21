   DateTime juil28 = DateTime(2009, 7, 28, 5, 23, 15, 16);
   IFormatProvider^ culture = gcnew System::Globalization::CultureInfo("fr-FR", true );
   
   // Get the short date formats using the S"fr-FR" culture.
   array<String^>^frenchJuly28Formats = juil28.GetDateTimeFormats(culture );
   
   // Print [Out] july28* in all DateTime formats using fr-FR culture.
   System::Collections::IEnumerator^ myEnum2 = frenchJuly28Formats->GetEnumerator();
   while ( myEnum2->MoveNext() )
   {
      String^ format = safe_cast<String^>(myEnum2->Current);
      System::Console::WriteLine(format );
   }