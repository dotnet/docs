// System::Windows::Forms::DataFormats::StringFormat

/*
*  The following example demonstrates the 'StringFormat' field of 'DataFormats' class. 
*  It stores a String Object^ in Clipboard using the Clipboard's 'SetDataObject' method.
*  It retrieves the String Object^ stored in the Clipboard by using the GetDataObject method
*  which returns the 'IDataObject^'. It checks the String^ data is available or not 
*  by using the 'GetDataPresent' method of 'IDataObject^'. If data is there then it
*  displays the data to the console.   
*/

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing::Imaging;
using namespace System::Windows::Forms;

int main()
{
   // <Snippet1>
   try
   {
      String^ myString = "This is a String from the ClipBoard";
      // Sets the data to the Clipboard.   
      Clipboard::SetDataObject( myString );
      IDataObject^ myDataObject = Clipboard::GetDataObject();
      
      // Checks whether the data is present or not in the Clipboard.
      if ( myDataObject->GetDataPresent( DataFormats::StringFormat ) )
      {
         String^ clipString = (String^)(myDataObject->GetData( DataFormats::StringFormat ));
         Console::WriteLine( clipString );
      }
      else
      {
         Console::WriteLine( "No String information was contained in the clipboard." );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( e->Message );
   }
   // </Snippet1>
}
