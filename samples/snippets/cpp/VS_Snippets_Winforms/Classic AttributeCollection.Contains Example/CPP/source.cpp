#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;
using namespace System::ComponentModel;

public ref class Form1: public Form
{
protected:
   Button^ button1;
   TextBox^ textBox1;

   // <Snippet1>
protected:
   void ContainsAttribute()
   {
      // Creates a new collection and assigns it the attributes for button1.
      AttributeCollection^ attributes;
      attributes = TypeDescriptor::GetAttributes( button1 );
      
      // Sets an Attribute to the specific attribute.
      BrowsableAttribute^ myAttribute = BrowsableAttribute::Yes;

      if ( attributes->Contains( myAttribute ) )
      {
         textBox1->Text = "button1 has a browsable attribute.";
      }
      else
      {
         textBox1->Text = "button1 does not have a browsable attribute.";
      }
   }
   // </Snippet1>
};
