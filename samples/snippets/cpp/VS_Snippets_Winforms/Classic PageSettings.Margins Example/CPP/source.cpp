#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Drawing::Printing;
using namespace System::IO;
using namespace System::Windows::Forms;

public ref class Sample
{
protected:
   StreamReader^ streamToPrint;
   Font^ printFont;
   String^ filePath;
   String^ printer;

   // <Snippet1>
public:
   void Printing()
   {
      try
      {
         streamToPrint = gcnew StreamReader( filePath );
         try
         {
            printFont = gcnew Font( "Arial",10 );
            PrintDocument^ pd = gcnew PrintDocument;
            pd->PrintPage += gcnew PrintPageEventHandler(
               this, &Sample::pd_PrintPage );
            pd->PrinterSettings->PrinterName = printer;
            // Create a new instance of Margins with 1-inch margins.
            Margins^ margins = gcnew Margins( 100,100,100,100 );
            pd->DefaultPageSettings->Margins = margins;
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
   // </Snippet1>

private:
   // Method added so sample will compile
   void pd_PrintPage( Object^, PrintPageEventArgs^ ){}
};
