

#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

public:

   property int MyProperty 
   {
      // <Snippet1>
      [ReadOnly(true)]
      int get()
      {
         // Insert code here.
         return 0;
      }
   }
   // </Snippet1>

   void Method1()
   {
      // <Snippet2>
      // Gets the attributes for the property.
      AttributeCollection^ attributes = TypeDescriptor::GetProperties( this )[ "MyProperty" ]->Attributes;

      // Checks to see whether the value of the ReadOnlyAttribute is Yes.
      if ( attributes[ ReadOnlyAttribute::typeid ]->Equals( ReadOnlyAttribute::Yes ) )
      {
         // Insert code here.
      }

      // This is another way to see whether the property is read-only.
      ReadOnlyAttribute^ myAttribute = dynamic_cast<ReadOnlyAttribute^>(attributes[ ReadOnlyAttribute::typeid ]);
      if ( myAttribute->IsReadOnly )
      {
         // Insert code here.
      }
      // </Snippet2>
   }

   void Method2()
   {
      // <Snippet3>
      AttributeCollection^ attributes = TypeDescriptor::GetAttributes( MyProperty );
      if ( attributes[ ReadOnlyAttribute::typeid ]->Equals( ReadOnlyAttribute::Yes ) )
      {
         // Insert code here.
      }
      // </Snippet3>
   }
};

/*
This code produces the following output.

myQ is not synchronized.
mySyncdQ is synchronized.
*/
