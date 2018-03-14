
//<snippet1>
// Sample for the Environment::MachineName property
using namespace System;
int main()
{
   Console::WriteLine();
   
   //  <-- Keep this information secure! -->
   Console::WriteLine( "MachineName: {0}", Environment::MachineName );
}

/*
This example produces the following results:
(Any result that is lengthy, specific to the machine on which this sample was tested, or reveals information that should remain secure, has been omitted and marked S"!---OMITTED---!".)

MachineName: !---OMITTED---!
*/
//</snippet1>
