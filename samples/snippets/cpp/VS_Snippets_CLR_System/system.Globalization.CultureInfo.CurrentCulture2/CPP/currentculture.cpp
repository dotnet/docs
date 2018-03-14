
// <snippet11>
using namespace System;
using namespace System::Globalization;
using namespace System::Threading;

int main()
{
   // Display the name of the current thread culture.
   Console::WriteLine("CurrentCulture is {0}.", CultureInfo::CurrentCulture->Name);
   
   // Change the current culture to th-TH.
   CultureInfo::CurrentCulture = gcnew CultureInfo("th-TH",false);
   Console::WriteLine("CurrentCulture is now {0}.", CultureInfo::CurrentCulture->Name);
   
   // Displays the name of the CurrentUICulture of the current thread.
   Console::WriteLine("CurrentUICulture is {0}.", CultureInfo::CurrentCulture->Name);
   
   // Changes the CurrentUICulture of the current thread to ja-JP.
   CultureInfo::CurrentUICulture = gcnew CultureInfo("ja-JP",false);
   Console::WriteLine("CurrentUICulture is now {0}.", CultureInfo::CurrentCulture->Name);
}
// The example displays the following output:
//       CurrentCulture is en-US.
//       CurrentCulture is now th-TH.
//       CurrentUICulture is en-US.
//       CurrentUICulture is now ja-JP.
// </snippet11>
