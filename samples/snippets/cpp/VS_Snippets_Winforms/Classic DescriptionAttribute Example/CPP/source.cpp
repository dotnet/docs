

#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Drawing;

public ref class Form1: public Form
{
protected:
   Image^ image1;

   // <Snippet1>
public:
   property Image^ MyImage 
   {
      [Description("The image associated with the control"),Category("Appearance")]
      Image^ get()
      {
         // Insert code here.
         return image1;
      }

      void set( Image^ value )
      {
         // Insert code here.
      }
   }
   // </Snippet1>

protected:
   void Method()
   {
      // <Snippet2>
      // Gets the attributes for the property.
      AttributeCollection^ attributes = TypeDescriptor::GetProperties( this )[ "MyImage" ]->Attributes;
      
      /* Prints the description by retrieving the DescriptionAttribute 
            * from the AttributeCollection. */
      DescriptionAttribute^ myAttribute = dynamic_cast<DescriptionAttribute^>(attributes[ DescriptionAttribute::typeid ]);
      Console::WriteLine( myAttribute->Description );
      // </Snippet2>
   }

};
