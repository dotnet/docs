
// <Snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   DirectoryInfo^ dir = gcnew DirectoryInfo( "." );
   String^ dirName = dir->Name;
   Console::WriteLine( "DirectoryInfo name is {0}.", dirName );
}

// </Snippet1>
