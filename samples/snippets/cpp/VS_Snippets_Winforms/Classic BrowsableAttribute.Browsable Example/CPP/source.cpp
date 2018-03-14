

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
      AttributeCollection^ attributes = TypeDescriptor::GetProperties( this )[ "MyProperty" ]->Attributes;

      // Checks to see if the property is browsable.
      BrowsableAttribute^ myAttribute = dynamic_cast<BrowsableAttribute^>(attributes[ BrowsableAttribute::typeid ]);
      if ( myAttribute->Browsable )
      {
         // Insert code here.
      }
      // </Snippet1>
   }
};
