
// System::Type::GetMembers()
/*
This program demonstrates GetMembers() method of System::Type Class.
Get the members (properties, methods, fields, events, and so on)
of the class 'MyClass' and displays the same to the console.
*/
using namespace System;
using namespace System::Reflection;
using namespace System::Security;

// <Snippet1>
ref class MyClass
{
public:
   int myInt;
   String^ myString;
   MyClass(){}

   void Myfunction(){}

};

int main()
{
   try
   {
      MyClass^ myObject = gcnew MyClass;
      array<MemberInfo^>^myMemberInfo;
      
      // Get the type of 'MyClass'.
      Type^ myType = myObject->GetType();
      
      // Get the information related to all public members of 'MyClass'.
      myMemberInfo = myType->GetMembers();
      Console::WriteLine( "\nThe members of class '{0}' are :\n", myType );
      for ( int i = 0; i < myMemberInfo->Length; i++ )
      {
         
         // Display name and type of the concerned member.
         Console::WriteLine( "'{0}' is a {1}", myMemberInfo[ i ]->Name, myMemberInfo[ i ]->MemberType );

      }
   }
   catch ( SecurityException^ e ) 
   {
      Console::WriteLine( "Exception : {0}", e->Message );
   }

}

// </Snippet1>
