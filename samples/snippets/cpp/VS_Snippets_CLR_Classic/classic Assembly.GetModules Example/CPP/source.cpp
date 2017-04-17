
// <Snippet1>
using namespace System;
using namespace System::Reflection;
int main()
{
   Assembly^ mainAssembly = Assembly::GetExecutingAssembly();
   Console::WriteLine( "The executing assembly is {0}.", mainAssembly );
   array<Module^>^mods = mainAssembly->GetModules();
   Console::WriteLine( "\tModules in the assembly:" );
   for ( int i = 0; i < mods->Length; i++ )
      Console::WriteLine( "\t{0}", mods[ i ] );
}

// </Snippet1>
