

// <snippet10>
#using <remotable.dll>

using namespace System;
using namespace System::Runtime::Remoting;

int main()
{
   // Set up a remoting client.
   RemotingConfiguration::Configure( "Client.config" );

   // Call a method on a remote object.
   Remotable ^ remoteObject = gcnew Remotable;
   Console::WriteLine( remoteObject->GetCount() );
}
// </snippet10>
