

#using <System.Data.dll>
#using <System.Xml.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;

namespace CancelEdit
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::TextBox^ textBox1;
      DataView^ myDataView;

      /// <summary>
      /// Required designer variable.
      /// </summary>
      System::ComponentModel::Container^ components;

   public:
      Form1()
      {
         components = nullptr;
         
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();
         
         //
         // TODO: Add any constructor code after InitializeComponent call
         //
      }

   protected:

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      ~Form1()
      {
         if ( components != nullptr )
         {
            delete components;
         }
      }

   private:

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      void InitializeComponent()
      {
         this->textBox1 = gcnew System::Windows::Forms::TextBox;
         this->SuspendLayout();
         
         //
         // textBox1
         //
         this->textBox1->Location = System::Drawing::Point( 24, 16 );
         this->textBox1->Name = "textBox1";
         this->textBox1->Size = System::Drawing::Size( 216, 20 );
         this->textBox1->TabIndex = 0;
         this->textBox1->Text = "textBox1";
         
         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 292, 266 );
         array<System::Windows::Forms::Control^>^formControls = {this->textBox1};
         this->Controls->AddRange( formControls );
         this->Name = "Form1";
         this->Text = "Form1";
         this->Load += gcnew System::EventHandler( this, &Form1::Form1_Load );
         this->ResumeLayout( false );
      }

      void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         SetBinding();
         CancelEdit();
         EndEdit();
      }

      //<snippet1>
   private:
      void CancelEdit()
      {
         // Gets the CurrencyManager which is returned when the
         // data source is a DataView.
         BindingManagerBase^ myMgr = dynamic_cast<CurrencyManager^>(BindingContext[ myDataView ]);

         // Gets the current row and changes a value. Then cancels the
         // edit and thereby discards the changes.
         DataRowView^ tempRowView = dynamic_cast<DataRowView^>(myMgr->Current);
         Console::WriteLine( "Original: {0}", tempRowView[ "myCol" ] );
         tempRowView[ "myCol" ] = "These changes will be discarded";
         Console::WriteLine( "Edit: {0}", tempRowView[ "myCol" ] );
         myMgr->CancelCurrentEdit();
         Console::WriteLine( "After CanceCurrentlEdit: {0}", tempRowView[ "myCol" ] );
      }

      void EndEdit()
      {
         // Gets the CurrencyManager which is returned when the
         // data source is a DataView.
         BindingManagerBase^ myMgr = dynamic_cast<CurrencyManager^>(BindingContext[ myDataView ]);
         
         // Gets the current row and changes a value. Then ends the
         // edit and thereby keeps the changes.
         DataRowView^ tempRowView = dynamic_cast<DataRowView^>(myMgr->Current);
         Console::WriteLine( "Original: {0}", tempRowView[ "myCol" ] );
         tempRowView[ "myCol" ] = "These changes will be kept";
         Console::WriteLine( "Edit: {0}", tempRowView[ "myCol" ] );
         myMgr->EndCurrentEdit();
         Console::WriteLine( "After EndCurrentEdit: {0}", tempRowView[ "myCol" ] );
      }
      // </snippet1>

      void SetBinding()
      {
         // Creates a DataView to be used as a data source. Sets the
         // myDataView variable, defined in the form, to the DataView.
         // Then binds the TextBox control to the DataView.
         DataTable^ myTable = gcnew DataTable( "myTable" );
         DataColumn^ myCol = gcnew DataColumn( "myCol" );
         myTable->Columns->Add( myCol );
         DataRow^ tempRow;
         tempRow = myTable->NewRow();
         tempRow[ "myCol" ] = "Original Data";
         myTable->Rows->Add( tempRow );
         myDataView = myTable->DefaultView;
         textBox1->DataBindings->Add( gcnew Binding( "Text",myDataView,"myCol" ) );
      }
   };
}


/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew CancelEdit::Form1 );
}
