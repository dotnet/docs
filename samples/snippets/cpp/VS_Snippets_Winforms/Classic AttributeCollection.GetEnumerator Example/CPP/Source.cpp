#using <system.dll>
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
   void MyEnumerator()
   {
      // Creates a new collection and assigns it the attributes for button1.
      AttributeCollection^ attributes;
      attributes = TypeDescriptor::GetAttributes( button1 );
      
      // Creates an enumerator for the collection.
      System::Collections::IEnumerator^ ie = attributes->GetEnumerator();
      
      // Prints the type of each attribute in the collection.
      Object^ myAttribute;
      System::Text::StringBuilder^ text = gcnew System::Text::StringBuilder;
      while ( ie->MoveNext() == true )
      {
         myAttribute = ie->Current;
         text->Append( myAttribute );
         text->Append( '\n' );
      }
      textBox1->Text = text->ToString();
   }
   // </Snippet1>
};
