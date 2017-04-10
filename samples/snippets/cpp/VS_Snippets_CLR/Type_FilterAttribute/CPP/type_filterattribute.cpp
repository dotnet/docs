
// <Snippet1>
using namespace System;
using namespace System::Collections;
using namespace System::Reflection;
using namespace System::Security;
int main()
{
   try
   {
      MemberFilter^ myFilter = Type::FilterAttribute;
      Type^ myType = System::String::typeid;
      array<MemberInfo^>^myMemberInfoArray = myType->FindMembers( static_cast<MemberTypes>(MemberTypes::Constructor | MemberTypes::Method), static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::Static | BindingFlags::Instance), myFilter, MethodAttributes::SpecialName );
      IEnumerator^ myEnum = myMemberInfoArray->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         MemberInfo^ myMemberinfo = safe_cast<MemberInfo^>(myEnum->Current);
         Console::Write( "\n {0}", myMemberinfo->Name );
         Console::Write( " is a {0}", myMemberinfo->MemberType );
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
