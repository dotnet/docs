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
private:
   void MatchesAttribute()
   {
      // Creates a new collection and assigns it the attributes for button1.
      AttributeCollection^ attributes;
      attributes = TypeDescriptor::GetAttributes( button1 );
      
      // Checks to see if the browsable attribute is true.
      if ( attributes->Matches( BrowsableAttribute::Yes ) )
      {
         textBox1->Text = "button1 is browsable.";
      }
      else
      {
         textBox1->Text = "button1 is not browsable.";
      }
   }
   // </Snippet1>
};
