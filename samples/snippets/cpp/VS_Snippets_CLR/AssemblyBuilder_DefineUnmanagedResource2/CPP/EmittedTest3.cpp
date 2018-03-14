/*
   Supporting file for AssemblyBuilder_DefineUnmanagedResource2.cs
   Note : Calls  EmitClass class from 'MyEmitTestAssembly.dll' using reflection emit.
*/

#using "MyEmitTestAssembly.dll"

using namespace System;

static void CallEmitMethod()
{
   EmitClass^ myEmit = gcnew EmitClass;
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
      Console::WriteLine( "Unable to load EmitClass type " +
         "from MyEmitTestAssembly.dll!" );
   }
}
