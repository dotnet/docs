

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
   void Method()
   {
      // <Snippet1>
      // Gets the attributes for the property.
      AttributeCollection^ attributes = TypeDescriptor::GetProperties( this )[ "MyProperty" ]->Attributes;

      // Checks to see if the value of the DesignerSerializationVisibilityAttribute is set to Content.
      if ( attributes[ DesignerSerializationVisibilityAttribute::typeid ]->Equals( DesignerSerializationVisibilityAttribute::Content ) )
      {
         // Insert code here.
      }

      
      // This is another way to see whether the property is marked as serializing content.
      DesignerSerializationVisibilityAttribute^ myAttribute = dynamic_cast<DesignerSerializationVisibilityAttribute^>(attributes[ DesignerSerializationVisibilityAttribute::typeid ]);
      if ( myAttribute->Visibility == DesignerSerializationVisibility::Content )
      {
         // Insert code here.
      }
      // </Snippet1>
   }
};
