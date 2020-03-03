

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
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
      
      // Checks to see if the property is bindable.
      BindableAttribute^ myAttribute = dynamic_cast<BindableAttribute^>(attributes[ BindableAttribute::typeid ]);
      if ( myAttribute->Bindable )
      {
         // Insert code here.
      }
      // </Snippet1>
   }
};
