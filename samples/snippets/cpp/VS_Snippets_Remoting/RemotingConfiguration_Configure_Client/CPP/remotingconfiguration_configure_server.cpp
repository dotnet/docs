

// System.Runtime.Remoting.RemotingConfiguration.Configure
// System.Runtime.Remoting.RemotingConfiguration.GetRegisteredWellKnownServiceTypes
/*
  The following example demonstrates the 'Configure' and 
  'GetRegisteredWellKnownServiceTypes' methods of 'RemotingConfiguration' class.
  It configures the remoting infrastructure using the 'Configure' method.Then gets
  the registered well-known objects at the service end and displays it's properties 
  on the console.
*/
#using <System.Runtime.Remoting.dll>
#using <System.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace System::Runtime::Remoting::Channels::Http;

int main()
{
   // <Snippet1>
   // Configure the remoting structure.
   RemotingConfiguration::Configure( "server.config" );
   // </Snippet1>

   // <Snippet2>
   // Retrive the array of objects registered as well known types at
   // the service end.
   array<WellKnownServiceTypeEntry^>^myEntries = RemotingConfiguration::GetRegisteredWellKnownServiceTypes();
   Console::WriteLine( "The number of WellKnownServiceTypeEntries are:{0}", myEntries->Length );
   Console::WriteLine( "The Object Type is:{0}", myEntries[ 0 ]->ObjectType );
   Console::WriteLine( "The Object Uri is:{0}", myEntries[ 0 ]->ObjectUri );
   Console::WriteLine( "The Mode is:{0}", myEntries[ 0 ]->Mode );
   // </Snippet2>

   Console::WriteLine( "Press <enter> to exit..." );
   Console::ReadLine();
}
