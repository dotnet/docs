
// <Snippet1>
using namespace System;
using namespace System::Reflection;
ref class MyFindMembersClass
{
public:
   static void Test()
   {
      Object^ objTest = gcnew Object;
      Type^ objType = objTest->GetType();
      array<MemberInfo^>^arrayMemberInfo;
      try
      {
         
         //Find all static or public methods in the Object class that match the specified name.
         arrayMemberInfo = objType->FindMembers( MemberTypes::Method, static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::Static | BindingFlags::Instance), gcnew MemberFilter( DelegateToSearchCriteria ), "ReferenceEquals" );
         for ( int index = 0; index < arrayMemberInfo->Length; index++ )
            Console::WriteLine( "Result of FindMembers -\t {0}", String::Concat( arrayMemberInfo[ index ], "\n" ) );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Exception : {0}", e );
      }

   }

   static bool DelegateToSearchCriteria( MemberInfo^ objMemberInfo, Object^ objSearch )
   {
      
      // Compare the name of the member function with the filter criteria.
      if ( objMemberInfo->Name->Equals( objSearch->ToString() ) )
            return true;
      else
            return false;
   }

};

int main()
{
   MyFindMembersClass::Test();
}

// </Snippet1>
