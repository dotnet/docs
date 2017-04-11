// <Snippet2>
using namespace System;
using namespace System::Globalization;

void main()
{
    int value = -16325;
    // Display value using the invariant culture.
    Console::WriteLine(value.ToString(CultureInfo::InvariantCulture));
    // Display value using the en-GB culture.
    Console::WriteLine(value.ToString(CultureInfo::CreateSpecificCulture("en-GB")));
    // Display value using the de-DE culture.
    Console::WriteLine(value.ToString(CultureInfo::CreateSpecificCulture("de-DE")));
}
// The example displays the following output:
//       -16325
//       -16325
//       -16325
// </Snippet2>
   


