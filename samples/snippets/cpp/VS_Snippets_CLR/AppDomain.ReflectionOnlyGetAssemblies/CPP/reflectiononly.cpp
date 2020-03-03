
//<Snippet1>
using namespace System;
using namespace System::Reflection;

#using <System.dll>

using namespace System::Timers;
using namespace System::Collections;
int main()
{
   
   // Get the assembly display name for System.dll, the assembly 
   // that contains System.Timers.Timer. Note that this causes
   // System.dll to be loaded into the execution context.
   //
   String^ displayName = Timer::typeid->Assembly->FullName;
   
   // Load System.dll into the reflection-only context. Note that 
   // if you obtain the display name (for example, by running this
   // example program), and enter it as a literal string in the 
   // preceding line of code, you can load System.dll into the 
   // reflection-only context without loading it into the execution 
   // context.
   Assembly::ReflectionOnlyLoad( displayName );
   
   // Display the assemblies loaded into the execution and 
   // reflection-only contexts. System.dll appears in both contexts.
   //
   Console::WriteLine( L"------------- Execution Context --------------" );
   IEnumerator^ myEnum = AppDomain::CurrentDomain->GetAssemblies()->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Assembly^ a = safe_cast<Assembly^>(myEnum->Current);
      Console::WriteLine( L"\t{0}", a->GetName() );
   }

   Console::WriteLine( L"------------- Reflection-only Context --------------" );
   IEnumerator^ myEnum1 = AppDomain::CurrentDomain->ReflectionOnlyGetAssemblies()->GetEnumerator();
   while ( myEnum1->MoveNext() )
   {
      Assembly^ a = safe_cast<Assembly^>(myEnum1->Current);
      Console::WriteLine( L"\t{0}", a->GetName() );
   }
}

//</Snippet1>
