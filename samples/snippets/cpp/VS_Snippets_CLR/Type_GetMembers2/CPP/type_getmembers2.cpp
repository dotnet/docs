
// System::Type::GetMembers(BindingFlags)
/*
This program demonstrates 'GetMembers(BindingFlags)' method of
System::Type Class. This will get all the public instance members
declared or inherited by this type and displays the members to
the console.
*/
using namespace System;
using namespace System::Reflection;
using namespace System::Security;

// <Snippet1>
ref class MyClass
{
public:
   int * myInt;
   String^ myString;
   MyClass(){}

   void Myfunction(){}

};

int main()
{
   try
   {
      MyClass^ MyObject = gcnew MyClass;
      array<MemberInfo^>^myMemberInfo;
      
      // Get the type of the class 'MyClass'.
      Type^ myType = MyObject->GetType();
      
      // Get the public instance members of the class 'MyClass'.
      myMemberInfo = myType->GetMembers( static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::Instance) );
      Console::WriteLine( "\nThe public instance members of class '{0}' are : \n", myType );
      for ( int i = 0; i < myMemberInfo->Length; i++ )
      {
         
         // Display name and type of the member of 'MyClass'.
         Console::WriteLine( "'{0}' is a {1}", myMemberInfo[ i ]->Name, myMemberInfo[ i ]->MemberType );

      }
   }
   catch ( SecurityException^ e ) 
   {
      Console::WriteLine( "SecurityException : {0}", e->Message );
   }


      //Output:
      //The public instance members of class 'MyClass' are :

      //'Myfunction' is a Method
      //'ToString' is a Method
      //'Equals' is a Method
      //'GetHashCode' is a Method
      //'GetType' is a Method
      //'.ctor' is a Constructor
      //'myInt' is a Field
      //'myString' is a Field

}

// </Snippet1>
