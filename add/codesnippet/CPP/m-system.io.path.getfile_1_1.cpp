   String^ fileName = "C:\\mydir\\myfile.ext";
   String^ path = "C:\\mydir\\";
   String^ result;
   result = Path::GetFileName( fileName );
   Console::WriteLine( "GetFileName('{0}') returns '{1}'", fileName, result );
   result = Path::GetFileName( path );
   Console::WriteLine( "GetFileName('{0}') returns '{1}'", path, result );

   // This code produces output similar to the following:
   //
   // GetFileName('C:\mydir\myfile.ext') returns 'myfile.ext'
   // GetFileName('C:\mydir\') returns ''