
// The following code example determines which cultures using the Chinese language are neutral cultures.
// <snippet1>
using namespace System;
using namespace System::Globalization;
int main()
{
   
   // Lists the cultures that use the Chinese language and determines if each is a neutral culture.
   System::Collections::IEnumerator^ enum0 = CultureInfo::GetCultures( CultureTypes::AllCultures )->GetEnumerator();
   while ( enum0->MoveNext() )
   {
      CultureInfo^ ci = safe_cast<CultureInfo^>(enum0->Current);
      if ( ci->TwoLetterISOLanguageName->Equals( "zh" ) )
      {
         Console::Write( "{0,-7} {1,-40}", ci->Name, ci->EnglishName );
         if ( ci->IsNeutralCulture )
         {
            Console::WriteLine( ": neutral" );
         }
         else
         {
            Console::WriteLine( ": specific" );
         }
      }
   }
}

/*
This code produces the following output.

zh-Hans Chinese (Simplified)                    : neutral
zh-TW   Chinese (Traditional, Taiwan)           : specific
zh-CN   Chinese (Simplified, PRC)               : specific
zh-HK   Chinese (Traditional, Hong Kong S.A.R.) : specific
zh-SG   Chinese (Simplified, Singapore)         : specific
zh-MO   Chinese (Traditional, Macao S.A.R.)     : specific
zh      Chinese                                 : neutral
zh-Hant Chinese (Traditional)                   : neutral
zh-CHS  Chinese (Simplified) Legacy             : neutral
zh-CHT  Chinese (Traditional) Legacy            : neutral

*/
// </snippet1>
