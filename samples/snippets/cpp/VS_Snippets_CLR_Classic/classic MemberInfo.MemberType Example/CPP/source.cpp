
// <Snippet1>
using namespace System;
using namespace System::Reflection;
int main()
{
   Console::WriteLine( "\nReflection.MemberInfo" );
   
   // Get the Type and MemberInfo.
   Type^ MyType = Type::GetType( "System.Reflection.PropertyInfo" );
   array<MemberInfo^>^Mymemberinfoarray = MyType->GetMembers();
   
   // Get the MemberType method and display the elements.
   Console::Write( "\nThere are {0} members in ", Mymemberinfoarray->GetLength( 0 ) );
   Console::Write( "{0}.", MyType->FullName );
   for ( int counter = 0; counter < Mymemberinfoarray->Length; counter++ )
   {
      Console::Write( "\n{0}. {1} Member type - {2}", counter, Mymemberinfoarray[ counter ]->Name, Mymemberinfoarray[ counter ]->MemberType );

   }
   return 0;
}

// </Snippet1>
