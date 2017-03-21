#using <system.dll>

using namespace System;
using namespace System::IO;
void ChangeExtension()
{
   String^ goodFileName = "C:\\mydir\\myfile.com.extension";
   String^ badFileName = "C:\\mydir\\";
   String^ result;
   result = Path::ChangeExtension( goodFileName,  ".old" );
   Console::WriteLine( "ChangeExtension({0}, '.old') returns '{1}'", goodFileName, result );
   result = Path::ChangeExtension( goodFileName,  "" );
   Console::WriteLine( "ChangeExtension({0}, '') returns '{1}'", goodFileName, result );
   result = Path::ChangeExtension( badFileName,  ".old" );
   Console::WriteLine( "ChangeExtension({0}, '.old') returns '{1}'", badFileName, result );
   
   // This code produces output similar to the following:
   //
   // ChangeExtension(C:\mydir\myfile.com.extension, '.old') returns 'C:\mydir\myfile.com.old'
   // ChangeExtension(C:\mydir\myfile.com.extension, '') returns 'C:\mydir\myfile.com.'
   // ChangeExtension(C:\mydir\, '.old') returns 'C:\mydir\.old'