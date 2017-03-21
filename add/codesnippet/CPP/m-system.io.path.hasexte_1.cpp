   String^ fileName1 = "myfile.ext";
   String^ fileName2 = "mydir\\myfile";
   String^ path = "C:\\mydir.ext\\";
   bool result;
   result = Path::HasExtension( fileName1 );
   Console::WriteLine( "HasExtension('{0}') returns {1}", fileName1, result.ToString() );
   result = Path::HasExtension( fileName2 );
   Console::WriteLine( "HasExtension('{0}') returns {1}", fileName2, result.ToString() );
   result = Path::HasExtension( path );
   Console::WriteLine( "HasExtension('{0}') returns {1}", path, result.ToString() );

   // This code produces output similar to the following:
   //
   // HasExtension('myfile.ext') returns True
   // HasExtension('mydir\myfile') returns False
   // HasExtension('C:\mydir.ext\') returns False