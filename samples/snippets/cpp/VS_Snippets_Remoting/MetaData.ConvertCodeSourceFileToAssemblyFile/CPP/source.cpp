

// <Snippet1>
#using <system.dll>
#using <system.runtime.remoting.dll>

using namespace System;
using namespace System::Runtime::Remoting::MetadataServices;
int main()
{
   MetaData::ConvertCodeSourceFileToAssemblyFile( "CsSource.cs", "testAssm.dll", "" );
   return 0;
}

// </Snippet1>
