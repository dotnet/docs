
//<snippet1>
using namespace System;
using namespace System::Collections;

int main()
{
   Console::WriteLine( "GetEnvironmentVariables: " );
   for each (DictionaryEntry^ de in Environment::GetEnvironmentVariables())
      Console::WriteLine( " {0} = {1}", de->Key, de->Value );
}
// Output from the example is not shown, since it is:
//    Lengthy.
//    Specific to the machine on which the example is run.
//    May reveal information that should remain secure.
//</snippet1>
