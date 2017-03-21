void GetPublicInstanceMethodMemberInfo()
{
   String^ myString = "GetMember_String_MemberType_BindingFlag";
   Type^ myType = myString->GetType();
   
   // Get the public instance methods for myString starting with the letter C.
   array<MemberInfo^>^myMembers = myType->GetMember( "C*", MemberTypes::Method, static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::Instance) );
   if ( myMembers->Length > 0 )
   {
      Console::WriteLine( "\nThe public instance method(s) starting with the letter C for type {0}:", myType );
      for ( int index = 0; index < myMembers->Length; index++ )
         Console::WriteLine( "Member {0}: {1}", index + 1, myMembers[ index ] );
   }
   else
      Console::WriteLine( "No members match the search criteria." );
}