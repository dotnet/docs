// <Snippet2>
using namespace System;
using namespace System::Globalization;

void main()
{
   DateTime localDate = DateTime::Now;
   array<String^>^ cultureNames = { "en-US", "en-GB", "fr-FR",
                                    "de-DE", "ru-RU" };

   for each (String^ cultureName in cultureNames) {
      CultureInfo^ culture = gcnew CultureInfo(cultureName);
      Console::WriteLine("{0}: {1}", cultureName,
                         localDate.ToString(culture));
   }
}
// The example displays the following output:
//       en-US: 6/19/2015 10:03:06 AM
//       en-GB: 19/06/2015 10:03:06
//       fr-FR: 19/06/2015 10:03:06
//       de-DE: 19.06.2015 10:03:06
//       ru-RU: 19.06.2015 10:03:06
// </Snippet2>