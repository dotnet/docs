
//<snippet1>
// Sample for the Environment::StackTrace property
using namespace System;
int main()
{
   Console::WriteLine();
   Console::WriteLine( "StackTrace: ' {0}'", Environment::StackTrace );
}

/*
This example produces the following results:

StackTrace: '   at System::Environment::GetStackTrace(Exception e)
at System::Environment::GetStackTrace(Exception e)
at System::Environment::get_StackTrace()
at Sample::Main()'
*/
//</snippet1>
