   String^ fileName = "myfile.ext";
   String^ path = "\\mydir\\";
   String^ fullPath;
   fullPath = Path::GetFullPath( path );
   Console::WriteLine( "GetFullPath('{0}') returns '{1}'", path, fullPath );
   fullPath = Path::GetFullPath( fileName );
   Console::WriteLine( "GetFullPath('{0}') returns '{1}'", fileName, fullPath );
   
   // Output is based on your current directory, except
   // in the last case, where it is based on the root drive
   // GetFullPath('mydir') returns 'C:\temp\Demo\mydir'
   // GetFullPath('myfile.ext') returns 'C:\temp\Demo\myfile.ext'
   // GetFullPath('\mydir') returns 'C:\mydir'