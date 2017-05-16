
// <snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   
   // Create a reference to a file.
   FileInfo^ fi = gcnew FileInfo( "temp.txt" );
   
   // Actually create the file.
   FileStream^ fs = fi->Create();
   
   // Modify the file as required, and then close the file.
   fs->Close();
   
   // Delete the file.
   fi->Delete();
}

// </snippet1>
