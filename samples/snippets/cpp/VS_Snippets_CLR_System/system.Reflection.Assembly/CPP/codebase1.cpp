// <Snippet1>
using namespace System;
using namespace System::Reflection;

void main()
{
   // Instantiate a target object.
   int integer1 = 1632;
   // Instantiate an Assembly class to the assembly housing the Integer type.
   Assembly^ systemAssembly = integer1.GetType()->Assembly;
   // Get the location of the assembly using the file: protocol.
   Console::WriteLine("CodeBase = {0}", systemAssembly->CodeBase);
}
// The example displays output like the following:
//   CodeBase = file:///C:/Windows/Microsoft.NET/Framework64/v4.0.30319/mscorlib.dll
// </Snippet1>