
// <Snippet1>
using namespace System;
using namespace System::Reflection;

public ref class TestClass
{
   // Define a field.
   private:
      String^ field = "private field" ;

// public:
//    Myfield()
//       : field( "private field" )
//    {}
// 
// 
//    property String^ Field 
//    {
//       String^ get()
//       {
//          return field;
//       }
// 
//   }
};

void main()
{
   TestClass^ cl = gcnew TestClass;
   
   // Get the type and FieldInfo.
   Type^ t = cl->GetType();
   FieldInfo^ fi = t->GetField("field", 
                   static_cast<BindingFlags>(BindingFlags::Instance | BindingFlags::NonPublic));
   
   // Get and display the Ftype s ieldType.
   Console::WriteLine("Field Name: {0}.{1}", t->FullName, fi->Name );
   Console::WriteLine("Field Value: '{0}'", fi->GetValue(cl));
   Console::WriteLine("Field Type: {0}", fi->FieldType);
}
// The example displays the following output:
//       Field Name: TestClass.field
//       Field Value: 'private field'
//       Field Type: System.String
// </Snippet1>
