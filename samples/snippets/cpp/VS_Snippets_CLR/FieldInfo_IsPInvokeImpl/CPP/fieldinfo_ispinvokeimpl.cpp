
// <Snippet1>
using namespace System;
using namespace System::Reflection;

public ref class Fieldinfo_IsPinvoke
{
public:
   String^ myField;
   Fieldinfo_IsPinvoke()
   {
      myField = "A public field";
   }
};

int main()
{
   Fieldinfo_IsPinvoke^ myObject = gcnew Fieldinfo_IsPinvoke;

   // Get the Type and FieldInfo.
   Type^ myType1 = Fieldinfo_IsPinvoke::typeid;
   FieldInfo^ myFieldInfo = myType1->GetField( "myField", static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::Instance) );

   // Display the name, field and the PInvokeImpl attribute for the field.
   Console::Write( "\n Name of class: {0}", myType1->FullName );
   Console::Write( "\n Value of field: {0}", myFieldInfo->GetValue( myObject ) );
   Console::Write( "\n IsPinvokeImpl: {0}", myFieldInfo->IsPinvokeImpl );
}
// </Snippet1>
