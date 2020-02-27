// <Snippet3>
using namespace System;
using namespace System::Globalization;

void main()
{
   DateTime localDate = DateTime::Now;
   DateTime utcDate = DateTime::UtcNow;
   array<String^>^ cultureNames = { "en-US", "en-GB", "fr-FR",
                                    "de-DE", "ru-RU" } ;

   for each (String^ cultureName in cultureNames) {
      CultureInfo^ culture = gcnew CultureInfo(cultureName);
      Console::WriteLine("{0}:", culture->NativeName);
      Console::WriteLine("   Local date and time: {0}, {1:G}",
                         localDate.ToString(culture), localDate.Kind);
      Console::WriteLine("   UTC date and time: {0}, {1:G}\n",
                         utcDate.ToString(culture), utcDate.Kind);
   }
}
// The example displays the following output:
//       English (United States):
//          Local date and time: 6/19/2015 10:35:50 AM, Local
//          UTC date and time: 6/19/2015 5:35:50 PM, Utc
//
//       English (United Kingdom):
//          Local date and time: 19/06/2015 10:35:50, Local
//          UTC date and time: 19/06/2015 17:35:50, Utc
//
//       français (France):
//          Local date and time: 19/06/2015 10:35:50, Local
//          UTC date and time: 19/06/2015 17:35:50, Utc
//
//       Deutsch (Deutschland):
//          Local date and time: 19.06.2015 10:35:50, Local
//          UTC date and time: 19.06.2015 17:35:50, Utc
//
//       русский (Россия):
//          Local date and time: 19.06.2015 10:35:50, Local
//          UTC date and time: 19.06.2015 17:35:50, Utc
// </Snippet3>

