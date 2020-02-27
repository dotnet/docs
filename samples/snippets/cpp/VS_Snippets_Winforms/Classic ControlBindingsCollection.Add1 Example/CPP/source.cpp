

#using <System.dll>
#using <System.Xml.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

   // <Snippet1>
private:
   void BindTextBoxProperties()
   {
      // Clear the collection before adding new Binding objects.
      textBox1->DataBindings->Clear();

      // Create a DataTable containing Color objects.
      DataTable^ t = MakeTable();

      /* Bind the Text, BackColor, and ForeColor properties
         to columns in the DataTable. */
      textBox1->DataBindings->Add( "Text", t, "Text" );
      textBox1->DataBindings->Add( "BackColor", t, "BackColor" );
      textBox1->DataBindings->Add( "ForeColor", t, "ForeColor" );
   }

   DataTable^ MakeTable()
   {
      /* Create a DataTable with three columns.
         Two of the columns contain Color objects. */
      DataTable^ t = gcnew DataTable( "Control" );
      t->Columns->Add( "BackColor", Color::typeid );
      t->Columns->Add( "ForeColor", Color::typeid );
      t->Columns->Add( "Text" );

      // Add three rows to the table.
      DataRow^ r;
      r = t->NewRow();
      r[ "BackColor" ] = Color::Blue;
      r[ "ForeColor" ] = Color::Yellow;
      r[ "Text" ] = "Yellow on Blue";
      t->Rows->Add( r );
      r = t->NewRow();
      r[ "BackColor" ] = Color::White;
      r[ "ForeColor" ] = Color::Green;
      r[ "Text" ] = "Green on white";
      t->Rows->Add( r );
      r = t->NewRow();
      r[ "BackColor" ] = Color::Orange;
      r[ "ForeColor" ] = Color::Black;
      r[ "Text" ] = "Black on Orange";
      t->Rows->Add( r );
      return t;
   }
   // </Snippet1>
};
