// <Snippet1>

#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::IO;
using namespace System::Drawing;
using namespace System::Drawing::Printing;
using namespace System::Windows::Forms;

public ref class PrintingExample: public System::Windows::Forms::Form
{
private:
   System::ComponentModel::Container^ components;
   System::Windows::Forms::Button^ printButton;
   System::Drawing::Font^ printFont;
   StreamReader^ streamToPrint;

public:
   PrintingExample()
      : Form()
   {
      
      // The Windows Forms Designer requires the following call.
      InitializeComponent();
   }


private:

   // The Click event is raised when the user clicks the Print button.
   void printButton_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      try
      {
         streamToPrint = gcnew StreamReader( "C:\\My Documents\\MyFile.txt" );
         try
         {
            printFont = gcnew System::Drawing::Font( "Arial",10 );
            PrintDocument^ pd = gcnew PrintDocument;
            pd->PrintPage += gcnew PrintPageEventHandler( this, &PrintingExample::pd_PrintPage );
            pd->Print();
         }
         finally
         {
            streamToPrint->Close();
         }

      }
      catch ( Exception^ ex ) 
      {
         MessageBox::Show( ex->Message );
      }

   }


   // The PrintPage event is raised for each page to be printed.
   void pd_PrintPage( Object^ /*sender*/, PrintPageEventArgs^ ev )
   {
      float linesPerPage = 0;
      float yPos = 0;
      int count = 0;
      float leftMargin = (float)ev->MarginBounds.Left;
      float topMargin = (float)ev->MarginBounds.Top;
      String^ line = nullptr;
      
      // Calculate the number of lines per page.
      linesPerPage = ev->MarginBounds.Height / printFont->GetHeight( ev->Graphics );
      
      // Print each line of the file.
      while ( count < linesPerPage && ((line = streamToPrint->ReadLine()) != nullptr) )
      {
         yPos = topMargin + (count * printFont->GetHeight( ev->Graphics ));
         ev->Graphics->DrawString( line, printFont, Brushes::Black, leftMargin, yPos, gcnew StringFormat );
         count++;
      }

      
      // If more lines exist, print another page.
      if ( line != nullptr )
            ev->HasMorePages = true;
      else
            ev->HasMorePages = false;
   }


   // The Windows Forms Designer requires the following procedure.
   void InitializeComponent()
   {
      this->components = gcnew System::ComponentModel::Container;
      this->printButton = gcnew System::Windows::Forms::Button;
      this->ClientSize = System::Drawing::Size( 504, 381 );
      this->Text = "Print Example";
      printButton->ImageAlign = System::Drawing::ContentAlignment::MiddleLeft;
      printButton->Location = System::Drawing::Point( 32, 110 );
      printButton->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      printButton->TabIndex = 0;
      printButton->Text = "Print the file.";
      printButton->Size = System::Drawing::Size( 136, 40 );
      printButton->Click += gcnew System::EventHandler( this, &PrintingExample::printButton_Click );
      this->Controls->Add( printButton );
   }

};


// This is the main entry point for the application.
int main()
{
   Application::Run( gcnew PrintingExample );
}

// </Snippet1>
