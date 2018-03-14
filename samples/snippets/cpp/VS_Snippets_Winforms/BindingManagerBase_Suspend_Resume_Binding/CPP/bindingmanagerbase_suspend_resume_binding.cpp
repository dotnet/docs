

// System::BindingManagerBase::SuspendBinding
// System::BindingManagerBase::ResumeBinding
/* This program demonstrates 'SuspendBinding' and 'ResumeBinding' method of 'BindingManagerBase'class.
It creates a 'DataTable'and two 'TextBox' controls. The 'Text' property of the two 'TextBox' is
binded with the two columns of the 'DataTable'. If 'SuspendBinding' button is pressed it
suspend the Data Binding between TextBoxes and a 'DataTable' and if ResumeButton is pressed it
resumes Data Binding.
*/
#using <System.Xml.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Globalization;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
private:
   Button^ button1;
   Button^ button2;
   TextBox^ textBox1;
   TextBox^ textBox2;
   BindingManagerBase^ myBindingManager;
   Button^ button3;
   Button^ button4;
   Label^ label1;
   Label^ label2;
   DataSet^ myDataSet;

public:
   Form1()
   {
      InitializeComponent();
      
      // Call SetUp to bind the controls.
      SetUp();
   }

private:
   void InitializeComponent()
   {
      button1 = gcnew Button;
      button2 = gcnew Button;
      button3 = gcnew Button;
      textBox2 = gcnew TextBox;
      textBox1 = gcnew TextBox;
      button4 = gcnew Button;
      label1 = gcnew Label;
      label2 = gcnew Label;
      SuspendLayout();
      button1->Location = Point(120,8);
      button1->Name = "button1";
      button1->Size = System::Drawing::Size( 64, 24 );
      button1->TabIndex = 0;
      button1->Text = "<";
      button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );
      button2->Location = Point(184,8);
      button2->Name = "button2";
      button2->Size = System::Drawing::Size( 64, 24 );
      button2->TabIndex = 1;
      button2->Text = ">";
      button2->Click += gcnew System::EventHandler( this, &Form1::button2_Click );
      button3->Location = Point(96,112);
      button3->Name = "button3";
      button3->TabIndex = 4;
      button3->Text = "Suspend";
      button3->Click += gcnew System::EventHandler( this, &Form1::button3_Click );
      textBox2->Location = Point(200,72);
      textBox2->Name = "textBox2";
      textBox2->Size = System::Drawing::Size( 150, 20 );
      textBox2->TabIndex = 3;
      textBox2->Text = "";
      textBox1->Location = Point(40,72);
      textBox1->Name = "textBox1";
      textBox1->Size = System::Drawing::Size( 150, 20 );
      textBox1->TabIndex = 2;
      textBox1->Text = "";
      button4->Location = Point(192,112);
      button4->Name = "button4";
      button4->TabIndex = 5;
      button4->Text = "Resume";
      button4->Click += gcnew System::EventHandler( this, &Form1::button4_Click );
      label1->Location = Point(48,48);
      label1->Name = "label1";
      label1->TabIndex = 6;
      label1->Text = "Customer Name";
      label2->Location = Point(216,48);
      label2->Name = "label2";
      label2->TabIndex = 7;
      label2->Text = "CustomerID";
      ClientSize = System::Drawing::Size( 450, 200 );
      array<Control^>^temp0 = {label2,label1,button4,button3,button1,button2,textBox1,textBox2};
      Controls->AddRange( temp0 );
      Name = "Form1";
      Text = "Binding Sample";
      ResumeLayout( false );
   }

   void SetUp()
   {
      MakeDataSet();
      BindControls();
   }

protected:
   void BindControls()
   {
      textBox1->DataBindings->Add( gcnew Binding( "Text",myDataSet,"customers.custName" ) );
      textBox2->DataBindings->Add( gcnew Binding( "Text",myDataSet,"customers.custID" ) );
      myBindingManager = BindingContext[ myDataSet, "Customers" ];
   }

private:
   void button1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      
      // Go to the previous item in the Customer list.
      myBindingManager->Position = myBindingManager->Position - 1;
   }

private:
   void button2_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      
      // Go to the next item in the Customer list.
      myBindingManager->Position = myBindingManager->Position + 1;
   }

private:

   // Create a DataSet with two tables and populate it.
   void MakeDataSet()
   {
      // Create a DataSet.
      myDataSet = gcnew DataSet( "myDataSet" );

      // Create a DataTable.
      DataTable^ myCustomerTable = gcnew DataTable( "Customers" );

      // Create two columns, and add them to the first table.
      DataColumn^ myCustomerColumnID = gcnew DataColumn( "CustID",int::typeid );
      DataColumn^ myCustomerName = gcnew DataColumn( "CustName" );
      myCustomerTable->Columns->Add( myCustomerColumnID );
      myCustomerTable->Columns->Add( myCustomerName );

      // Add the tables to the DataSet.
      myDataSet->Tables->Add( myCustomerTable );
      DataRow^ newRow1;

      // Create three customers in the Customers Table.
      for ( int i = 1; i < 4; i++ )
      {
         newRow1 = myCustomerTable->NewRow();
         newRow1[ "custID" ] = i;
         
         // Add the row to the Customers table.
         myCustomerTable->Rows->Add( newRow1 );
      }
      myCustomerTable->Rows[ 0 ][ "custName" ] = "Alpha";
      myCustomerTable->Rows[ 1 ][ "custName" ] = "Beta";
      myCustomerTable->Rows[ 2 ][ "custName" ] = "Omega";
      UniqueConstraint^ idKeyRestraint = gcnew UniqueConstraint( myCustomerColumnID );
      myCustomerTable->Constraints->Add( idKeyRestraint );
      myDataSet->EnforceConstraints = true;
   }

   // <Snippet1>
   void button3_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      try
      {
         BindingManagerBase^ myBindingManager1 = BindingContext[ myDataSet, "Customers" ];
         myBindingManager1->SuspendBinding();
      }
      catch ( Exception^ ex ) 
      {
         MessageBox::Show( ex->Source );
         MessageBox::Show( ex->Message );
      }
   }
   // </Snippet1>

   // <Snippet2>
   void button4_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      try
      {
         BindingManagerBase^ myBindingManager2 = BindingContext[ myDataSet, "Customers" ];
         myBindingManager2->ResumeBinding();
      }
      catch ( Exception^ ex ) 
      {
         MessageBox::Show( ex->Source );
         MessageBox::Show( ex->Message );
      }
   }
   // </Snippet2>
};

int main()
{
   Application::Run( gcnew Form1 );
}
