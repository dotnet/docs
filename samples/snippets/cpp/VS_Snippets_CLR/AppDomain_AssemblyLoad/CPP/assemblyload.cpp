
// <Snippet1>
using namespace System;
using namespace System::Reflection;
ref class Test
{
public:
   static void MyAssemblyLoadEventHandler( Object^ sender, AssemblyLoadEventArgs^ args )
   {
      Console::WriteLine( "ASSEMBLY LOADED: {0}", args->LoadedAssembly->FullName );
      Console::WriteLine();
   }

};

void PrintLoadedAssemblies( AppDomain^ domain )
{
   Console::WriteLine( "LOADED ASSEMBLIES:" );
   System::Collections::IEnumerator^ myEnum = domain->GetAssemblies()->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Assembly^ a = safe_cast<Assembly^>(myEnum->Current);
      Console::WriteLine( a->FullName );
   }

   Console::WriteLine();
}

int main()
{
   AppDomain^ currentDomain = AppDomain::CurrentDomain;
   currentDomain->AssemblyLoad += gcnew AssemblyLoadEventHandler( Test::MyAssemblyLoadEventHandler );
   PrintLoadedAssemblies( currentDomain );
   
   // Lists mscorlib and this assembly
   // You must supply a valid fully qualified assembly name here.
   currentDomain->CreateInstance( "System.Windows.Forms, Version, Culture, PublicKeyToken", "System.Windows.Forms.TextBox" );
   
   // Loads System, System::Drawing, System::Windows::Forms
   PrintLoadedAssemblies( currentDomain );
   
   // Lists all five assemblies
}

// </Snippet1>
