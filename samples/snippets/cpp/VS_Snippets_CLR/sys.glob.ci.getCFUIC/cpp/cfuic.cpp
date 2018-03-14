//<snippet1>
// This example demonstrates the GetConsoleFallbackUICulture() method
using namespace System;
using namespace System::Globalization;

int main()
{
    CultureInfo^ ci = gcnew CultureInfo("ar-DZ");
    Console::WriteLine("Culture name: . . . . . . . . . {0}", ci->Name);
    Console::WriteLine("Console fallback UI culture:. . {0}",
        ci->GetConsoleFallbackUICulture()->Name);
}
/*
This code example produces the following results:

Culture name: . . . . . . . . . ar-DZ
Console fallback UI culture:. . fr-FR

*/
//</snippet1>
