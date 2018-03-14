

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
   void Method()
   {
      // <Snippet1>
      // Gets the attributes for the property.
      AttributeCollection^ attributes = TypeDescriptor::GetProperties( this )[ "MyPropertyProperty" ]->Attributes;

      // Checks to see if the property is bindable.
      MergablePropertyAttribute^ myAttribute = dynamic_cast<MergablePropertyAttribute^>(attributes[ MergablePropertyAttribute::typeid ]);
      if ( myAttribute->AllowMerge )
      {
         // Insert code here.
      }
      // </Snippet1>
   }
};
