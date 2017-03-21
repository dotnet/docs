using namespace System;
using namespace System::Security;
using namespace System::Reflection;

// forward declarations:
void GetMemberInfo();
void GetPublicStaticMemberInfo();
void GetPublicInstanceMethodMemberInfo();
int main()
{
   try
   {
      GetMemberInfo();
      GetPublicStaticMemberInfo();
      GetPublicInstanceMethodMemberInfo();
   }
   catch ( ArgumentNullException^ e ) 
   {
      Console::WriteLine( "ArgumentNullException occurred." );
      Console::WriteLine( "Source: {0}", e->Source );
      Console::WriteLine( "Message: {0}", e->Message );
   }
   catch ( NotSupportedException^ e ) 
   {
      Console::WriteLine( "NotSupportedException occurred." );
      Console::WriteLine( "Source: {0}", e->Source );
      Console::WriteLine( "Message: {0}", e->Message );
   }
   catch ( SecurityException^ e ) 
   {
      Console::WriteLine( "SecurityException occurred." );
      Console::WriteLine( "Source: {0}", e->Source );
      Console::WriteLine( "Message: {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception occurred." );
      Console::WriteLine( "Source: {0}", e->Source );
      Console::WriteLine( "Message: {0}", e->Message );
   }

}

void GetMemberInfo()
{
   String^ myString = "GetMember_String";
   Type^ myType = myString->GetType();
   
   // Get the members for myString starting with the letter C.
   array<MemberInfo^>^myMembers = myType->GetMember( "C*" );
   if ( myMembers->Length > 0 )
   {
      Console::WriteLine( "\nThe member(s) starting with the letter C for type {0}:", myType );
      for ( int index = 0; index < myMembers->Length; index++ )
         Console::WriteLine( "Member {0}: {1}", index + 1, myMembers[ index ] );
   }
   else
      Console::WriteLine( "No members match the search criteria." );
}