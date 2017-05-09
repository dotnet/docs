
using namespace System;

int main()
{
   // <Snippet1>
   DateTime july28 = DateTime(2009, 7, 28, 5, 23, 15, 16);
   array<String^>^july28Formats = july28.GetDateTimeFormats();
   
   // Print [Out] july28* in all DateTime formats using the default culture.
   System::Collections::IEnumerator^ myEnum = july28Formats->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      String^ format = safe_cast<String^>(myEnum->Current);
      System::Console::WriteLine( format );
   }
   // </Snippet1>
   
   // <Snippet2>
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
   // </Snippet2>
}
