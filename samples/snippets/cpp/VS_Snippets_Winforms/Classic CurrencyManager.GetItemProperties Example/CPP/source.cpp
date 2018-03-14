

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;
using namespace System::ComponentModel;
public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

private:

   // <Snippet1>
   void PrintPropertyDescriptions( BindingManagerBase^ b )
   {
      Console::WriteLine( "Printing Property Descriptions" );
      PropertyDescriptorCollection^ ps = b->GetItemProperties();
      for ( int i = 0; i < ps->Count; i++ )
      {
         Console::WriteLine( "\t{0}\t{1}", ps[ i ]->Name, ps[ i ]->PropertyType );

      }
   }

   // </Snippet1>
};
