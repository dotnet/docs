
// <Snippet1>
using namespace System;
using namespace System::Reflection;
int main()
{
   Console::WriteLine( "\nReflection.PropertyInfo" );
   
   // Get the type and PropertyInfo.
   Type^ MyType = Type::GetType( "System.Reflection.MemberInfo" );
   PropertyInfo^ Mypropertyinfo = MyType->GetProperty( "Name" );
   
   // Read and display the MemberType property.
   Console::Write( "\nMemberType = {0}", Mypropertyinfo->MemberType );
   return 0;
}

// </Snippet1>
