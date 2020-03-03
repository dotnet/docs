

#using <System.Windows.Forms.dll>
#using <System.Xml.dll>
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

private:

   // <Snippet1>
   void ShowGetItemProperties()
   {
      
      // Create a new DataTable and add two columns.
      DataTable^ dt = gcnew DataTable;
      dt->Columns->Add( "Name", Type::GetType( "System.String" ) );
      dt->Columns->Add( "ID", Type::GetType( "System.String" ) );
      
      // Add a row to the table.
      DataRow^ dr = dt->NewRow();
      dr[ "Name" ] = "Ann";
      dr[ "ID" ] = "AAA";
      dt->Rows->Add( dr );
      PropertyDescriptorCollection^ myPropertyDescriptors = this->BindingContext[ dt ]->GetItemProperties();
      PropertyDescriptor^ myPropertyDescriptor = myPropertyDescriptors[ "Name" ];
      Console::WriteLine( myPropertyDescriptor->Name );
      Console::WriteLine( myPropertyDescriptor->GetValue( dt->DefaultView[ 0 ] ) );
   }

   // </Snippet1>
};
