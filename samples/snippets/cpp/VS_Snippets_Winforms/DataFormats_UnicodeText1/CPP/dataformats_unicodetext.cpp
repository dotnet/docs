// System::Windows::Forms::DataFormats.UnicodeText;System::Windows::Forms::Text;

/*
*  The following example demonstrates the 'UnicodeText' and 'Text' field of 'DataFormats' class. 
*  It stores a String Object^ in Clipboard using the Clipboard's 'SetDataObject' method.
*  It retrieves the String Object^ stored in the Clipboard by using the GetDataObject method
*  which returns the 'IDataObject^'.  It checks whether the Unicodetext data is present 
*  or not by using the 'GetDataPresent' method of 'IDataObject^'. If data is there then it
*  displays the data to the console. It also checks 'Text' format data is present or not. If
*  the data is there it displays the data to the console.
*    
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
   // <Snippet2>
   try
   {
      String^ myString = "This is a String from the ClipBoard";
      
      // Sets the data into the Clipboard.
      Clipboard::SetDataObject( myString );
      IDataObject^ myDataObject = Clipboard::GetDataObject();
      // Checks whether the format of the data is 'UnicodeText' or not.
      if ( myDataObject->GetDataPresent( DataFormats::UnicodeText ) )
      {
         Console::WriteLine( "Data in 'UnicodeText' format: " +
            myDataObject->GetData( DataFormats::UnicodeText ) );
      }
      else
      {
         Console::WriteLine( "No String information was contained in the clipboard." );
      }

      // Checks whether the format of the data is 'Text' or not.
      if ( myDataObject->GetDataPresent( DataFormats::Text ) )
      {
         String^ clipString = (String^)(myDataObject->GetData( DataFormats::StringFormat ));
         Console::WriteLine( "Data in 'Text' format: {0}", clipString );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( e->Message );
   }
   // </Snippet2>
   // </Snippet1>
}
