// <Snippet1>
using namespace System;
using namespace System::Reflection;

public ref class FieldsClass
{
  public:
     String^ fieldA;
     String^ fieldB;

     FieldsClass()
     {
        fieldA = "A public field";
        fieldB = "Another public field";
     }
};

int main()
{
   FieldsClass^ fieldsInst = gcnew FieldsClass;
   
   // Get the type of FieldsClass.
   Type^ fieldsType = FieldsClass::typeid;

   // Get the FieldInfo of FieldsClass.
   array<FieldInfo^>^ fields = fieldsType->GetFields(static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::Instance));

   // Display the values of the fields.
   Console::WriteLine("Displaying the values of the fields of {0}:", fieldsType);
   for (int i = 0; i < fields->Length; i++)
   {
      Console::WriteLine("   {0}:\t'{1}'", 
                         fields[i]->Name, fields[i]->GetValue(fieldsInst));
   }
}
// The example displays the following output:
//     Displaying the values of the fields of FieldsClass:
//        fieldA:      'A public field'
//        fieldB:      'Another public field'
// </Snippet1>
