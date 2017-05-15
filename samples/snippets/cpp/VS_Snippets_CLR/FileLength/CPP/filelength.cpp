
// <Snippet1>
// The following example displays the names and sizes
// of the files in the specified directory.
using namespace System;
using namespace System::IO;
int main()
{
   
   // Make a reference to a directory.
   DirectoryInfo^ di = gcnew DirectoryInfo( "c:\\" );
   
   // Get a reference to each file in that directory.
   array<FileInfo^>^fiArr = di->GetFiles();
   
   // Display the names and sizes of the files.
   Console::WriteLine( "The directory {0} contains the following files:", di->Name );
   System::Collections::IEnumerator^ myEnum = fiArr->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      FileInfo^ f = safe_cast<FileInfo^>(myEnum->Current);
      Console::WriteLine( "The size of {0} is {1} bytes.", f->Name, f->Length );
   }
}
//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//
//The directory c:\ contains the following files:
//The size of MyComputer.log is 274 bytes.
//The size of AUTOEXEC.BAT is 0 bytes.
//The size of boot.ini is 211 bytes.
//The size of CONFIG.SYS is 0 bytes.
//The size of hiberfil.sys is 1072775168 bytes.
//The size of IO.SYS is 0 bytes.
//The size of MASK.txt is 2700 bytes.
//The size of mfc80.dll is 1093632 bytes.
//The size of mfc80u.dll is 1079808 bytes.
//The size of MSDOS.SYS is 0 bytes.
//The size of NTDETECT.COM is 47564 bytes.
//The size of ntldr is 250032 bytes.
//The size of pagefile.sys is 1610612736 bytes.
//The size of UpdatePatch.log is 22778 bytes.
//The size of UpdatePatch.txt is 30 bytes.
//The size of wt3d.ini is 234 bytes.
// </Snippet1>
