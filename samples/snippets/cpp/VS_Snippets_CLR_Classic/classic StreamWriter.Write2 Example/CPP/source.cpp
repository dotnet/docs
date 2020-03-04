// <Snippet1>
using namespace System;
using namespace System::IO;

int main()
{
   FileStream^ sb = gcnew FileStream( "MyFile.txt",FileMode::OpenOrCreate );
   array<Char>^b = {'a','b','c','d','e','f','g','h','i','j','k','l','m'};
   StreamWriter^ sw = gcnew StreamWriter( sb );
   sw->Write( b, 3, 8 );
   sw->Close();
}
// </Snippet1>
