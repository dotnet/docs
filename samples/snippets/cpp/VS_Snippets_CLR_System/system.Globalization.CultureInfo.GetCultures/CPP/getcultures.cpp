
// The following code example displays several properties of the neutral cultures.
// <snippet1>
using namespace System;
using namespace System::Globalization;
int main()
{
   
   // Displays several properties of the neutral cultures.
   Console::WriteLine( "CULTURE ISO ISO WIN DISPLAYNAME                              ENGLISHNAME" );
   System::Collections::IEnumerator^ enum0 = CultureInfo::GetCultures( CultureTypes::NeutralCultures )->GetEnumerator();
   while ( enum0->MoveNext() )
   {
      CultureInfo^ ci = safe_cast<CultureInfo^>(enum0->Current);
      Console::Write( "{0,-7}", ci->Name );
      Console::Write( " {0,-3}", ci->TwoLetterISOLanguageName );
      Console::Write( " {0,-3}", ci->ThreeLetterISOLanguageName );
      Console::Write( " {0,-3}", ci->ThreeLetterWindowsLanguageName );
      Console::Write( " {0,-40}", ci->DisplayName );
      Console::WriteLine( " {0,-40}", ci->EnglishName );
   }
}

/*
This code produces the following output.  This output has been cropped for brevity.

CULTURE ISO ISO WIN DISPLAYNAME                              ENGLISHNAME
ar      ar  ara ARA Arabic                                   Arabic                                  
bg      bg  bul BGR Bulgarian                                Bulgarian                               
ca      ca  cat CAT Catalan                                  Catalan                                 
zh-Hans zh  zho CHS Chinese (Simplified)                     Chinese (Simplified)                    
cs      cs  ces CSY Czech                                    Czech                                   
da      da  dan DAN Danish                                   Danish                                  
de      de  deu DEU German                                   German                                  
el      el  ell ELL Greek                                    Greek                                   
en      en  eng ENU English                                  English                                 
es      es  spa ESP Spanish                                  Spanish                                 
fi      fi  fin FIN Finnish                                  Finnish                                 
zh      zh  zho CHS Chinese                                  Chinese                                 
zh-Hant zh  zho CHT Chinese (Traditional)                    Chinese (Traditional)                   
zh-CHS  zh  zho CHS Chinese (Simplified) Legacy              Chinese (Simplified) Legacy             
zh-CHT  zh  zho CHT Chinese (Traditional) Legacy             Chinese (Traditional) Legacy            

*/
// </snippet1>
