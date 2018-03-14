//<snippet1>
// This example demonstrates the NativeDigits property.

using namespace System;
using namespace System::Globalization;
using namespace System::Threading;

int main()
{
    CultureInfo^ currentCI = Thread::CurrentThread->CurrentCulture;
    NumberFormatInfo^ nfi = currentCI->NumberFormat;
    array<String^>^ nativeDigitList = nfi->NativeDigits;

    Console::WriteLine("The native digits for the {0} culture are:",
        currentCI->Name);

    for each (String^ nativeDigit in nativeDigitList)
    {
        Console::Write("\"{0}\" ", nativeDigit);
    }

    Console::WriteLine();
}
/*
This code example produces the following results:

The native digits for the en-US culture are:
"0" "1" "2" "3" "4" "5" "6" "7" "8" "9"

*/
//</snippet1>
