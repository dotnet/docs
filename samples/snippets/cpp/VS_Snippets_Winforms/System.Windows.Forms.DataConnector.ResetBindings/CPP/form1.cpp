//<snippet1>
#using <System.Xml.dll>
#using <System.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Collections::Generic;
using namespace System::ComponentModel;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Text;
using namespace System::Xml;
using namespace System::Windows::Forms;
using namespace System::IO;

namespace System_Windows_Forms_UpdateBinding
{
   public ref class Form1: public Form
   {
   public:
      Form1()
      {
         InitializeComponent();
      }

      [STAThread]
      static void Main()
      {
         Application::EnableVisualStyles();
         Application::Run( gcnew Form1 );
      }

      //<snippet2>
   private:
      void Form1_Load( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // The xml to bind to.
         String^ xml = "<US><states>" +
            "<state><name>Washington</name><capital>Olympia</capital></state>" +
            "<state><name>Oregon</name><capital>Salem</capital></state>" +
            "<state><name>California</name><capital>Sacramento</capital></state>" +
            "<state><name>Nevada</name><capital>Carson City</capital></state>" +
            "</states></US>";
         
         // Convert the xml string to bytes and load into a memory stream.
         array<Byte>^ xmlBytes = Encoding::UTF8->GetBytes( xml );
         MemoryStream^ stream = gcnew MemoryStream( xmlBytes,false );
         
         // Create a DataSet and load the xml into it.
         dataSet1->ReadXml( stream );
         
         // Set the DataSource to the DataSet, and the DataMember
         // to state.
         bindingSource1->DataSource = dataSet1;
         bindingSource1->DataMember = "state";

         dataGridView1->DataSource = bindingSource1;
      }
      //</snippet2>

      //<snippet3>
   private:
      void button1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         String^ xml = "<US><states>"
            + "<state><name>Washington</name><capital>Olympia</capital> "
            + "<flower>Coast Rhododendron</flower></state>"
            + "<state><name>Oregon</name><capital>Salem</capital>"
            + "<flower>Oregon Grape</flower></state>"
            + "<state><name>California</name><capital>Sacramento</capital>"
            + "<flower>California Poppy</flower></state>"
            + "<state><name>Nevada</name><capital>Carson City</capital>"
            + "<flower>Sagebrush</flower></state>"
            + "</states></US>";
         
         // Convert the xml string to bytes and load into a memory stream.
         array<Byte>^ xmlBytes = Encoding::UTF8->GetBytes( xml );
         MemoryStream^ stream = gcnew MemoryStream( xmlBytes,false );
         
         // Create a DataSet and load the xml into it.
         dataSet2->ReadXml( stream );
         
         // Set the data source.
         bindingSource1->DataSource = dataSet2;
         bindingSource1->ResetBindings( true );
      }
      //</snippet3>

      System::Windows::Forms::Button^ button1;
      System::Windows::Forms::DataGridView^ dataGridView1;
      System::Windows::Forms::BindingSource^ bindingSource1;
      System::Data::DataSet^ dataSet1;
      DataSet^ dataSet2;

      #pragma region Windows Form Designer generated code 

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      void InitializeComponent()
      {
         this->button1 = gcnew System::Windows::Forms::Button;
         this->dataGridView1 = gcnew System::Windows::Forms::DataGridView;
         this->bindingSource1 = gcnew System::Windows::Forms::BindingSource;
         this->dataSet1 = gcnew System::Data::DataSet;
         this->dataSet2 = gcnew System::Data::DataSet;
         ( (System::ComponentModel::ISupportInitialize^)(this->dataGridView1) )->BeginInit();
         ( (System::ComponentModel::ISupportInitialize^)(this->bindingSource1) )->BeginInit();
         ( (System::ComponentModel::ISupportInitialize^)(this->dataSet1) )->BeginInit();
         ( (System::ComponentModel::ISupportInitialize^)(this->dataSet2) )->BeginInit();
         this->SuspendLayout();
         
         //
         // button1
         //
         this->button1->Location = System::Drawing::Point( 98, 222 );
         this->button1->Name = "button1";
         this->button1->TabIndex = 0;
         this->button1->Text = "button1";
         this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );
         
         //
         // dataGridView1
         //
         this->dataGridView1->Dock = System::Windows::Forms::DockStyle::Top;
         this->dataGridView1->Location = System::Drawing::Point( 0, 0 );
         this->dataGridView1->Name = "dataGridView1";
         this->dataGridView1->Size = System::Drawing::Size( 292, 150 );
         this->dataGridView1->TabIndex = 1;
         
         //
         // dataSet1
         //
         this->dataSet1->DataSetName = "NewDataSet";
         this->dataSet1->Locale = gcnew System::Globalization::CultureInfo( "en-US" );
         
         //
         // dataSet2
         //
         this->dataSet2->DataSetName = "NewDataSet";
         this->dataSet2->Locale = gcnew System::Globalization::CultureInfo( "en-US" );
         
         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 292, 273 );
         this->Controls->Add( this->dataGridView1 );
         this->Controls->Add( this->button1 );
         this->Name = "Form1";
         this->Text = "Form1";
         this->Load += gcnew EventHandler( this, &Form1::Form1_Load );
         ( (System::ComponentModel::ISupportInitialize^)(this->dataGridView1) )->EndInit();
         ( (System::ComponentModel::ISupportInitialize^)(this->bindingSource1) )->EndInit();
         ( (System::ComponentModel::ISupportInitialize^)(this->dataSet1) )->EndInit();
         ( (System::ComponentModel::ISupportInitialize^)(this->dataSet2) )->EndInit();
         this->ResumeLayout( false );
      }
      #pragma endregion 
   };
}

int main()
{
   System_Windows_Forms_UpdateBinding::Form1::Main();
}
//</snippet1>
