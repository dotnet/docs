
// <Snippet1>
using namespace System;
using namespace System::Reflection;
int main()
{
   Console::WriteLine( "\nReflection.MethodInfo" );
   
   // Get the Type and MethodInfo.
   Type^ MyType = Type::GetType( "System.Reflection.FieldInfo" );
   MethodInfo^ Mymethodinfo = MyType->GetMethod( "GetValue" );
   Console::Write( "\n{0}.{1}", MyType->FullName, Mymethodinfo->Name );
   
   // Get and display the ReturnType.
   Console::Write( "\nReturnType = {0}", Mymethodinfo->ReturnType );
   return 0;
}

// </Snippet1>
