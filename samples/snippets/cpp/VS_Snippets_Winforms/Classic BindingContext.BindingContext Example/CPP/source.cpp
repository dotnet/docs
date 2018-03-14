

#using <System.Xml.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
protected:
   GroupBox^ groupBox1;
   GroupBox^ groupBox2;
   TextBox^ textBox1;
   TextBox^ textBox2;
   DataSet^ ds;

private:

   // <Snippet1>
   void BindControls()
   {
      System::Windows::Forms::BindingContext^ bcG1 = gcnew System::Windows::Forms::BindingContext;
      System::Windows::Forms::BindingContext^ bcG2 = gcnew System::Windows::Forms::BindingContext;
      groupBox1->BindingContext = bcG1;
      groupBox2->BindingContext = bcG2;
      textBox1->DataBindings->Add( "Text", ds, "Customers.CustName" );
      textBox2->DataBindings->Add( "Text", ds, "Customers.CustName" );
   }

   void Button1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      groupBox1->BindingContext[ds, "Customers"]->Position = groupBox1->BindingContext[ds, "Customers"]->Position + 1;
   }

   void Button2_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      groupBox2->BindingContext[ds, "Customers"]->Position = groupBox2->BindingContext[ds, "Customers"]->Position + 1;
   }

   // </Snippet1>
};
