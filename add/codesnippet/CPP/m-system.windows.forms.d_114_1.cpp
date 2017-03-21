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
