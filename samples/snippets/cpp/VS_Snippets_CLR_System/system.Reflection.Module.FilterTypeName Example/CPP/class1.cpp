
// <snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Collections;
public ref class MySecondClass{};


// This class does not fit the filter criterion My*.
public ref class YourClass{};

int main()
{
   array<Module^>^moduleArray;
   moduleArray = Assembly::GetExecutingAssembly()->GetModules( false );
   
   // In a simple project with only one module, the module at index
   // 0 will be the module containing these classes.
   Module^ myModule = moduleArray[ 0 ];
   array<Type^>^tArray;
   tArray = myModule->FindTypes( Module::FilterTypeName, "My*" );
   IEnumerator^ myEnum = tArray->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Type^ t = safe_cast<Type^>(myEnum->Current);
      Console::WriteLine( "Found a module beginning with My*: {0}.", t->Name );
   }
}

// </snippet1>
