

#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Reflection;
using namespace System::Windows::Forms;

// <Snippet1>
int main()
{
   Console::WriteLine( "\nReflection.MethodBase" );
   
   //Get the MethodBase of a method.
   //Get the type
   Type^ MyType = Type::GetType( "System.MulticastDelegate" );
   
   //Get and display the method
   MethodBase^ Mymethodbase = MyType->GetMethod( "RemoveImpl", static_cast<BindingFlags>(BindingFlags::NonPublic | BindingFlags::Instance) );
   Console::Write( "\nMymethodbase = {0}", Mymethodbase );
   bool Myispublic = Mymethodbase->IsPublic;
   if ( Myispublic )
      Console::Write( "\nMymethodbase is a public method" );
   else
      Console::Write( "\nMymethodbase is not a public method" );

   return 0;
}

/*
Produces the following output

Reflection.MethodBase
Mymethodbase = System.Delegate RemoveImpl (System.Delegate)
Mymethodbase is not a public method
*/
// </Snippet1>
