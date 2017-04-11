

// System::Windows::Forms::DataFormats::GetFormat(int)
/*
The following example demonstrates the 'GetFormat(int)' method of 'DataFormats'
class. It creates a 'DataFormats' Object* using a integer into the 'GetFormat' method.
By using the 'DatFormats' Object* it displays the format name with respective the id.
*/
#using <System.dll>
#using <System.Windows.Forms.dll>

// <Snippet1>
using namespace System;
using namespace System::Windows::Forms;
int main()
{
   
   // Create a DataFormats::Format for the Unicode data format.
   DataFormats::Format^ myFormat = DataFormats::GetFormat( 13 );
   
   // Display the contents of myFormat.
   Console::WriteLine( "The Format Name corresponding to the ID {0} is :", myFormat->Id );
   Console::WriteLine( myFormat->Name );
}

// </Snippet1>
