//<snippet1>
#using <System.Transactions.dll>
#using <System.EnterpriseServices.dll>
#using <System.Xml.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Data::SqlClient;
using namespace System::Windows::Forms;
using namespace System::Drawing;
public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      InitializeDataGridView();
      
      //Add any initialization after the InitializeComponent() call
   }


protected:

   ~Form1()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:
   System::Windows::Forms::DataGridView ^ dataGridView1;
   System::Windows::Forms::BindingSource ^ bindingSource1;

   //Required by the Windows Form Designer
   System::ComponentModel::IContainer^ components;

   //NOTE: The following procedure is required by the Windows Form Designer
   //It can be modified using the Windows Form Designer.  
   //Do not modify it using the code editor.

   [System::Diagnostics::DebuggerNonUserCode]
   void InitializeComponent()
   {
      this->dataGridView1 = gcnew System::Windows::Forms::DataGridView;
      this->bindingSource1 = gcnew System::Windows::Forms::BindingSource;
      this->SuspendLayout();

      //
      //DataGridView1
      //
      this->dataGridView1->Location = System::Drawing::Point( 96, 71 );
      this->dataGridView1->Name = "DataGridView1";
      this->dataGridView1->Size = System::Drawing::Size( 321, 286 );
      this->dataGridView1->TabIndex = 0;

      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 518, 413 );
      this->Controls->Add( this->dataGridView1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

internal:

   static property Form1^ GetInstance 
   {
      Form1^ get()
      {
         if ( m_DefaultInstance == nullptr || m_DefaultInstance->IsDisposed )
         {
            System::Threading::Monitor::Enter( m_SyncObject );
            try
            {
               if ( m_DefaultInstance == nullptr || m_DefaultInstance->IsDisposed )
               {
                  m_DefaultInstance = gcnew Form1;
               }
            }
            finally
            {
               System::Threading::Monitor::Exit( m_SyncObject );
            }
         }

         return m_DefaultInstance;
      }
   }

private:
   static Form1^ m_DefaultInstance;
   static Object^ m_SyncObject = gcnew Object;

   //<snippet2>
   void InitializeDataGridView()
   {
      try
      {
         // Set up the DataGridView.
         dataGridView1->Dock = DockStyle::Fill;

         // Automatically generate the DataGridView columns.
         dataGridView1->AutoGenerateColumns = true;

         // Set up the data source.
         bindingSource1->DataSource = GetData( "Select * From Products" );
         dataGridView1->DataSource = bindingSource1;

         // Automatically resize the visible rows.
         dataGridView1->AutoSizeRowsMode = DataGridViewAutoSizeRowsMode::DisplayedCellsExceptHeaders;

         // Set the DataGridView control's border.
         dataGridView1->BorderStyle = BorderStyle::Fixed3D;

         // Put the cells in edit mode when user enters them.
         dataGridView1->EditMode = DataGridViewEditMode::EditOnEnter;
      }
      catch ( SqlException^ ) 
      {
         MessageBox::Show( "To run this sample replace connection.ConnectionString"
         " with a valid connection string to a Northwind"
         " database accessible to your system.", "ERROR", MessageBoxButtons::OK, MessageBoxIcon::Exclamation );
         System::Threading::Thread::CurrentThread->Abort();
      }
      catch ( System::Exception^ ex ) 
      {
         MessageBox::Show( ex->ToString() );
      }
   }


   //</snippet2>
   //<snippet3>
   DataTable^ GetData( String^ sqlCommand )
   {
      String^ connectionString = "Integrated Security=SSPI;Persist Security Info=False;"
      "Initial Catalog=Northwind;Data Source= localhost";
      SqlConnection^ northwindConnection = gcnew SqlConnection( connectionString );
      SqlCommand^ command = gcnew SqlCommand( sqlCommand,northwindConnection );
      SqlDataAdapter^ adapter = gcnew SqlDataAdapter;
      adapter->SelectCommand = command;
      DataTable^ table = gcnew DataTable;
      adapter->Fill( table );
      return table;
   }
   //</snippet3>
};

int main()
{
   Application::Run( gcnew Form1 );
}
//</snippet1>
