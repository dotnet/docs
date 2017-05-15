#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::IO;
using namespace System::Drawing;
using namespace System::Drawing::Printing;
using namespace System::Windows::Forms;

public ref class Sample: public Form
{
protected:
   StreamReader^ streamToPrint;
   String^ filePath;
   String^ printer;
   System::Drawing::Font^ printFont;

public:

   // <Snippet1>
   void Printing()
   {
      try
      {
         
         /* This assumes that a variable of type string, named filePath,
                 has been set to the path of the file to print. */
         streamToPrint = gcnew StreamReader( filePath );
         try
         {
            printFont = gcnew System::Drawing::Font( "Arial",10 );
            PrintDocument^ pd = gcnew PrintDocument;
            
            /* This assumes that a method, named pd_PrintPage, has been
                      defined. pd_PrintPage handles the PrintPage event. */
            pd->PrintPage += gcnew PrintPageEventHandler( this, &Sample::pd_PrintPage );
            
            /* This assumes that a variable of type string, named 
                      printer, has been set to the printer's name. */
            pd->PrinterSettings->PrinterName = printer;
            
            // Set the left and right margins to 1 inch.
            pd->DefaultPageSettings->Margins->Left = 100;
            pd->DefaultPageSettings->Margins->Right = 100;
            
            // Set the top and bottom margins to 1.5 inches.
            pd->DefaultPageSettings->Margins->Top = 150;
            pd->DefaultPageSettings->Margins->Bottom = 150;
            pd->Print();
         }
         finally
         {
            streamToPrint->Close();
         }

      }
      catch ( Exception^ ex ) 
      {
         MessageBox::Show( String::Concat( "An error occurred printing the file - ", ex->Message ) );
      }

   }
   // </Snippet1>

private:
   void pd_PrintPage( Object^, PrintPageEventArgs^ ){}
};
