

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

private:

   // <Snippet1>
   void PrintIndexItem2()
   {
      
      // Creates a new collection and assigns it the attributes for button1.
      AttributeCollection^ attributes;
      attributes = TypeDescriptor::GetAttributes( button1 );
      
      // Gets the designer attribute from the collection.
      DesignerAttribute^ myDesigner;
      
      // You must supply a valid fully qualified assembly name here. 
      myDesigner = dynamic_cast<DesignerAttribute^>(attributes[ Type::GetType(  "Assembly text name, Version, Culture, PublicKeyToken" ) ]);
      textBox1->Text = myDesigner->DesignerTypeName;
   }

   // </Snippet1>
};
