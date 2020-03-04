
// <Snippet1>
using namespace System;
using namespace System::Reflection;
int main()
{
   Console::WriteLine( "\nReflection.MemberTypes" );
   MemberTypes Mymembertypes;
   
   // Get the type of a chosen class.
   Type^ Mytype = Type::GetType( "System.Reflection.ReflectionTypeLoadException" );
   
   // Get the MemberInfo array.
   array<MemberInfo^>^Mymembersinfoarray = Mytype->GetMembers();
   
   // Get and display the name and the MemberType for each member.
   System::Collections::IEnumerator^ enum0 = Mymembersinfoarray->GetEnumerator();
   while ( enum0->MoveNext() )
   {
      MemberInfo^ Mymemberinfo = safe_cast<MemberInfo^>(enum0->Current);
      Mymembertypes = Mymemberinfo->MemberType;
      Console::WriteLine( "The member {0} of {1} is a {2}.", Mymemberinfo->Name, Mytype, Mymembertypes );
   }

   return 0;
}

// </Snippet1>
