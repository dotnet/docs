   String^ fileName = "C:\\mydir\\myfile.ext";
   String^ UncPath = "\\\\myPc\\mydir\\myfile";
   String^ relativePath = "mydir\\sudir\\";
   bool result;
   result = Path::IsPathRooted( fileName );
   Console::WriteLine( "IsPathRooted('{0}') returns {1}", fileName, result.ToString() );
   result = Path::IsPathRooted( UncPath );
   Console::WriteLine( "IsPathRooted('{0}') returns {1}", UncPath, result.ToString() );
   result = Path::IsPathRooted( relativePath );
   Console::WriteLine( "IsPathRooted('{0}') returns {1}", relativePath, result.ToString() );
   
   // This code produces output similar to the following:
   //
   // IsPathRooted('C:\mydir\myfile.ext') returns True
   // IsPathRooted('\\myPc\mydir\myfile') returns True
   // IsPathRooted('mydir\sudir\') returns False