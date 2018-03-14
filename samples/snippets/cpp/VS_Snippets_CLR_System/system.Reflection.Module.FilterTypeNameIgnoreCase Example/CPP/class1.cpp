
// <snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Collections;
public ref class MyMainClass{};

public ref class MySecondClass{};


// This class does not fit the filter criteria my*.
public ref class YourClass{};

int main()
{
   array<Module^>^moduleArray;
   moduleArray = Assembly::GetExecutingAssembly()->GetModules( false );
   
   // In a simple project with only one module, the module at index
   // 0 will be the module containing these classes.
   Module^ myModule = moduleArray[ 0 ];
   array<Type^>^tArray;
   tArray = myModule->FindTypes( Module::FilterTypeNameIgnoreCase, "my*" );
   IEnumerator^ myEnum = tArray->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Type^ t = safe_cast<Type^>(myEnum->Current);
      Console::WriteLine( "Found a module beginning with my*: {0}", t->Name );
   }
}

// </snippet1>
