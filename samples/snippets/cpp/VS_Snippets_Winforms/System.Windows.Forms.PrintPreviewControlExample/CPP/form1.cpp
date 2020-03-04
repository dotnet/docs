

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
      docToPrint = gcnew System::Drawing::Printing::PrintDocument;
      InitializePrintPreviewControl();
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

private:

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      this->PrintDialog1 = gcnew System::Windows::Forms::PrintDialog;
      this->SuspendLayout();
      
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }



   //<snippet1>
internal:
   // Declare the PrintPreviewControl object and the 
   // PrintDocument object.
   PrintPreviewControl^ PrintPreviewControl1;

private:
   System::Drawing::Printing::PrintDocument^ docToPrint;
   void InitializePrintPreviewControl()
   {
      // Construct the PrintPreviewControl.
      this->PrintPreviewControl1 = gcnew PrintPreviewControl;
      
      // Set location, name, and dock style for PrintPreviewControl1.
      this->PrintPreviewControl1->Location = Point(88,80);
      this->PrintPreviewControl1->Name = "PrintPreviewControl1";
      this->PrintPreviewControl1->Dock = DockStyle::Fill;
      
      // Set the Document property to the PrintDocument 
      // for which the PrintPage event has been handled.
      this->PrintPreviewControl1->Document = docToPrint;
      
      // Set the zoom to 25 percent.
      this->PrintPreviewControl1->Zoom = 0.25;
      
      // Set the document name. This will show be displayed when 
      // the document is loading into the control.
      this->PrintPreviewControl1->Document->DocumentName = "c:\\someFile";
      
      // Set the UseAntiAlias property to true so fonts are smoothed
      // by the operating system.
      this->PrintPreviewControl1->UseAntiAlias = true;
      
      // Add the control to the form.
      this->Controls->Add( this->PrintPreviewControl1 );
      
      // Associate the event-handling method with the
      // document's PrintPage event.
      this->docToPrint->PrintPage += gcnew System::Drawing::Printing::PrintPageEventHandler( this, &Form1::docToPrint_PrintPage );
   }

   // The PrintPreviewControl will display the document
   // by handling the documents PrintPage event
   void docToPrint_PrintPage( Object^ /*sender*/, System::Drawing::Printing::PrintPageEventArgs^ e )
   {
      // Insert code to render the page here.
      // This code will be called when the control is drawn.
      // The following code will render a simple
      // message on the document in the control.
      String^ text = "In docToPrint_PrintPage method.";
      System::Drawing::Font^ printFont = gcnew System::Drawing::Font( "Arial",35,FontStyle::Regular );
      e->Graphics->DrawString( text, printFont, Brushes::Black, 10, 10 );
   }
   //</snippet1>
};


[System::STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
