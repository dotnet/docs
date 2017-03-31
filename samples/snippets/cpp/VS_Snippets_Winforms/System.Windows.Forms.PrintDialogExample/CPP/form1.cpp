

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System::Windows::Forms;
using namespace System::Drawing;
using namespace System;

public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      
      //Add any initialization after the InitializeComponent() call
      docToPrint = gcnew System::Drawing::Printing::PrintDocument;
      docToPrint->PrintPage += gcnew System::Drawing::Printing::PrintPageEventHandler( this, &Form1::document_PrintPage );
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

   //Required by the Windows Form Designer
   System::ComponentModel::IContainer^ components;

internal:

   //NOTE: The following procedure is required by the Windows Form Designer
   //It can be modified using the Windows Form Designer.  
   //Do not modify it using the code editor.
   System::Windows::Forms::PrintDialog^ PrintDialog1;
   System::Windows::Forms::Button^ Button1;

private:

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      this->PrintDialog1 = gcnew System::Windows::Forms::PrintDialog;
      this->Button1 = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();
      
      //
      //Button1
      //
      this->Button1->Location = System::Drawing::Point( 104, 104 );
      this->Button1->Name = "Button1";
      this->Button1->TabIndex = 0;
      this->Button1->Text = "Print";
      this->Button1->Click += gcnew System::EventHandler( this, &Form1::Button1_Click );
      
      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->Button1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<snippet1>
   // Declare the PrintDocument object.
   System::Drawing::Printing::PrintDocument^ docToPrint;

   // This method will set properties on the PrintDialog object and
   // then display the dialog.
   void Button1_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Allow the user to choose the page range he or she would
      // like to print.
      PrintDialog1->AllowSomePages = true;
      
      // Show the help button.
      PrintDialog1->ShowHelp = true;
      
      // Set the Document property to the PrintDocument for 
      // which the PrintPage Event has been handled. To display the
      // dialog, either this property or the PrinterSettings property 
      // must be set 
      PrintDialog1->Document = docToPrint;
      if ( docToPrint == nullptr )
            System::Windows::Forms::MessageBox::Show(  "null" );

      ;
      ;
      if ( PrintDialog1 == nullptr )
            System::Windows::Forms::MessageBox::Show(  "pnull" );

      ;
      ;
      System::Windows::Forms::DialogResult result = PrintDialog1->ShowDialog();
      System::Windows::Forms::MessageBox::Show( result.ToString() );
      ;
      ;
      
      // If the result is OK then print the document.
      if ( result == ::DialogResult::OK )
      {
         docToPrint->Print();
      }

   }

   // The PrintDialog will print the document
   // by handling the document's PrintPage event.
   void document_PrintPage( Object^ /*sender*/, System::Drawing::Printing::PrintPageEventArgs^ e )
   {
      // Insert code to render the page here.
      // This code will be called when the control is drawn.
      // The following code will render a simple
      // message on the printed document.
      String^ text = "In document_PrintPage method.";
      System::Drawing::Font^ printFont = gcnew System::Drawing::Font( "Arial",35,System::Drawing::FontStyle::Regular );
      
      // Draw the content.
      e->Graphics->DrawString( text, printFont, System::Drawing::Brushes::Black, 10, 10 );
   }
   //</snippet1>
};

[System::STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
