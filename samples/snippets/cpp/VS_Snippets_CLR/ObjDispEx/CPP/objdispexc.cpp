
//<Snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   MemoryStream^ ms = gcnew MemoryStream( 16 );
   ms->Close();
   try
   {
      ms->ReadByte();
   }
   catch ( ObjectDisposedException^ e ) 
   {
      Console::WriteLine( "Caught: {0}", e->Message );
   }

}

//</Snippet1>
