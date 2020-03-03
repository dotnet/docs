
// <Snippet1>
using namespace System;
using namespace System::Reflection;
int main()
{
   Console::WriteLine( "\nReflection.MethodBase" );
   
   // Get the types.
   Type^ MyType1 = Type::GetType( "System.Runtime.Serialization.Formatter" );
   Type^ MyType2 = Type::GetType( "System.Reflection.MethodBase" );
   
   // Get and display the methods.
   MethodBase^ Mymethodbase1 = MyType1->GetMethod( "WriteInt32", static_cast<BindingFlags>(BindingFlags::NonPublic | BindingFlags::Instance) );
   MethodBase^ Mymethodbase2 = MyType2->GetMethod( "GetCurrentMethod", static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::Static) );
   Console::Write( "\nMymethodbase = {0}", Mymethodbase1 );
   if ( Mymethodbase1->IsAbstract )
      Console::Write( "\nMymethodbase is an abstract method." );
   else
      Console::Write( "\nMymethodbase is not an abstract method." );

   Console::Write( "\n\nMymethodbase = {0}", Mymethodbase2 );
   if ( Mymethodbase2->IsAbstract )
      Console::Write( "\nMymethodbase is an abstract method." );
   else
      Console::Write( "\nMymethodbase is not an abstract method." );

   return 0;
}

// </Snippet1>
