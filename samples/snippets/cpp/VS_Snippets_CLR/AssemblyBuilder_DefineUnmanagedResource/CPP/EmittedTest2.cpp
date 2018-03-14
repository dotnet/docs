
#using "MyEmitTestAssembly.dll"

//   Note : Calls  EmitClass class from 'MyEmitTestAssembly.dll' using reflection emit.
using namespace System;
static void CallEmitMethod()
{
   EmitClass ^ myEmit = gcnew EmitClass();
   Console::WriteLine( myEmit->Display() );
}

int main()
{
   try
   {
      CallEmitMethod();
   }
   catch ( TypeLoadException^ ) 
   {
      Console::WriteLine(  "Unable to load EmitClass type "
       "from MyEmitTestAssembly.dll!" );
   }
}
