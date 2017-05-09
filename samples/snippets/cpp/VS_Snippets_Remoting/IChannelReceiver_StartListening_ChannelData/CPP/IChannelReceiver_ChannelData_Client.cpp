// This program acts as a client and calls the remote method 'HelloMethod'.

#using <System.dll>
#using <IChannelReceiver_ChannelData_Share.dll>
#using <system.runtime.remoting.dll>

using namespace System;
using namespace System::Net;
using namespace System::Collections::Specialized;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace System::Security::Permissions;

public ref class MyIChannelReceiverChannelDataClientClass
{
public:
   [PermissionSet(SecurityAction::Demand)]
   static void Main()
   {
      String^ myChannelURL = "tcp://" + Dns::Resolve(Dns::GetHostName())
                                       ->AddressList[0] + ":8085/SayHello";
      ListDictionary^ myListDictionary = gcnew ListDictionary();
      myListDictionary->Add("port",8086);
      TcpChannel^ myCustomChannel = gcnew TcpChannel(myListDictionary,
                                    gcnew SoapClientFormatterSinkProvider(),
                                    gcnew SoapServerFormatterSinkProvider());
      ChannelServices::RegisterChannel(myCustomChannel);
      try
      {
         HelloServer^ myHelloServer = (HelloServer^)Activator::GetObject
                        (HelloServer::typeid, myChannelURL);
         if (myHelloServer == nullptr) 
         {
            Console::WriteLine("Could not locate server.");
         }
         else 
         {
            Console::WriteLine(myHelloServer->HelloMethod("Caveman"));
         }
      }
      catch(Exception^ e)
      {
         Console::WriteLine("Message : " + e->Message);
      }
   }
};

int main() {
   MyIChannelReceiverChannelDataClientClass::Main();
   return 0;
}
