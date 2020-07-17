#using <system.dll>
#using <system.runtime.remoting.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Http;
using namespace System::Security::Permissions;

[SecurityPermission(SecurityAction::Demand)]
int main()
{
   // <Snippet1>
   IDictionary^ prop = gcnew Hashtable;
   prop[ "port" ] = 9000;
   IClientChannelSinkProvider^ clientChain = gcnew BinaryClientFormatterSinkProvider;
   IServerChannelSinkProvider^ serverChain = gcnew SoapServerFormatterSinkProvider;
   serverChain->Next = gcnew BinaryServerFormatterSinkProvider;
   ChannelServices::RegisterChannel( gcnew HttpChannel( prop,clientChain,serverChain ) );
   // </Snippet1>

   return 0;
}
