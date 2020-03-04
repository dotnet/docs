
// <Snippet1>
using namespace System;
using namespace System::Reflection;

public ref class FieldInfo_GetFieldFromHandle
{
public:
   String^ x;
   Char y;
   float a;
   int b;
};

int main()
{
   // Get the type of the FieldInfo_GetFieldFromHandle class.
   Type^ myType = FieldInfo_GetFieldFromHandle::typeid;

   // Get the fields of the FieldInfo_GetFieldFromHandle class.
   array<FieldInfo^>^myFieldInfoArray = myType->GetFields();
   Console::WriteLine( "\nThe field information of the declared  fields x, y, a, and b is:\n" );
   RuntimeFieldHandle myRuntimeFieldHandle;
   for ( int i = 0; i < myFieldInfoArray->Length; i++ )
   {
      // Get the RuntimeFieldHandle of myFieldInfoArray.
      myRuntimeFieldHandle = myFieldInfoArray[ i ]->FieldHandle;

      // Call the GetFieldFromHandle method. 
      FieldInfo^ myFieldInfo = FieldInfo::GetFieldFromHandle( myRuntimeFieldHandle );

      // Display the FieldInfo of myFieldInfo.
      Console::WriteLine( " {0}", myFieldInfo );
   }
}
// </Snippet1>
