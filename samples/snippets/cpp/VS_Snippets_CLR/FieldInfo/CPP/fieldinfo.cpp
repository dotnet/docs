
// <Snippet1>
using namespace System;
using namespace System::Reflection;
public ref class FieldInfoClass
{
public:
   int myField1;

protected:
   String^ myField2;
};

int main()
{
   array<FieldInfo^>^myFieldInfo;
   Type^ myType = FieldInfoClass::typeid;

   // Get the type and fields of FieldInfoClass.
   myFieldInfo = myType->GetFields( static_cast<BindingFlags>(BindingFlags::NonPublic | BindingFlags::Instance | BindingFlags::Public) );
   Console::WriteLine( "\nThe fields of FieldInfoClass are \n" );

   // Display the field information of FieldInfoClass.
   for ( int i = 0; i < myFieldInfo->Length; i++ )
   {
      Console::WriteLine( "\nName            : {0}", myFieldInfo[ i ]->Name );
      Console::WriteLine( "Declaring Type  : {0}", myFieldInfo[ i ]->DeclaringType );
      Console::WriteLine( "IsPublic        : {0}", myFieldInfo[ i ]->IsPublic );
      Console::WriteLine( "MemberType      : {0}", myFieldInfo[ i ]->MemberType );
      Console::WriteLine( "FieldType       : {0}", myFieldInfo[ i ]->FieldType );
      Console::WriteLine( "IsFamily        : {0}", myFieldInfo[ i ]->IsFamily );
   }
}
// </Snippet1>
