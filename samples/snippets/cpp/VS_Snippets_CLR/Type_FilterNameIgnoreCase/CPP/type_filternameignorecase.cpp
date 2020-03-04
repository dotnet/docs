
// <Snippet1>
using namespace System;
using namespace System::Collections;
using namespace System::Reflection;
using namespace System::Security;
int main()
{
   try
   {
      MemberFilter^ myFilter = Type::FilterNameIgnoreCase;
      Type^ myType = System::String::typeid;
      array<MemberInfo^>^myMemberinfo1 = myType->FindMembers( static_cast<MemberTypes>(MemberTypes::Constructor | MemberTypes::Method), static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::Static | BindingFlags::Instance), myFilter, "C*" );
      IEnumerator^ myEnum = myMemberinfo1->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         MemberInfo^ myMemberinfo2 = safe_cast<MemberInfo^>(myEnum->Current);
         Console::Write( "\n {0}", myMemberinfo2->Name );
         MemberTypes Mymembertypes = myMemberinfo2->MemberType;
         Console::WriteLine( " is a {0}", Mymembertypes );
      }
   }
   catch ( ArgumentNullException^ e ) 
   {
      Console::Write( "ArgumentNullException : {0}", e->Message );
   }
   catch ( SecurityException^ e ) 
   {
      Console::Write( "SecurityException : {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::Write( "Exception : {0}", e->Message );
   }
}
// </Snippet1>
