
//<snippet1>
// Sample for the Environment::NewLine property
using namespace System;
int main()
{
   Console::WriteLine();
   Console::WriteLine( "NewLine: {0}  first line {0}  second line {0}  third line", Environment::NewLine );
}

/*
This example produces the following results:

NewLine:
first line
second line
third line
*/
//</snippet1>
