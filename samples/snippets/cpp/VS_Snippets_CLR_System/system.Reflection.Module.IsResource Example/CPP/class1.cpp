
//<snippet1>
using namespace System;
using namespace System::Reflection;
int main()
{
   array<Module^>^moduleArray;
   moduleArray = Assembly::GetExecutingAssembly()->GetModules( false );
   
   //In a simple project with only one module, the module at index
   // 0 will be the module containing this class.
   Module^ myModule = moduleArray[ 0 ];
   Console::WriteLine( "myModule->IsResource() = {0}", myModule->IsResource() );
}

//</snippet1>
