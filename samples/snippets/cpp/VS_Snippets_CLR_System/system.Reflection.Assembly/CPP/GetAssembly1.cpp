// <Snippet12>
using namespace System;
using namespace System::Reflection;

void main()
{
   // Get a Type object.
   Type^ t = int::typeid;
   // Instantiate an Assembly class to the assembly housing the Integer type.
   Assembly^ assem = Assembly::GetAssembly(t);
   // Display the name of the assembly.
   Console::WriteLine("Name: {0}", assem->FullName);
   // Get the location of the assembly using the file: protocol.
   Console::WriteLine("CodeBase: {0}", assem->CodeBase);
}
// The example displays output like the following:
//    Name: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
//    CodeBase: file:///C:/Windows/Microsoft.NET/Framework64/v4.0.30319/mscorlib.dll
// </Snippet12>