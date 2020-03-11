


// System.Runtime.Remoting.Channels.IChannelReceiverHook
// System.Runtime.Remoting.Channels.IChannelReceiverHook.WantsToListen
// System.Runtime.Remoting.Channels.IChannelReceiverHook.ChannelScheme

/*
This example demonstrates the implementation of the 'ChannelScheme' and
'WantsToListen' properties of the 'IChannelReceiverHook' interface.
It creates  a customized channel 'MyCustomChannel' by implementing 
'IChannelReceiverHook' interface.
*/



#using <System.Runtime.Remoting.dll>
#using <System.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Http;

// <Snippet1>
// Implementation of 'IChannelReceiverHook' interface.
public ref class MyCustomChannel: public IChannelReceiverHook
{
private:
   bool portSet;

public:
   // Constructor for MyCustomChannel.
   MyCustomChannel( int /*port*/ )
   {
      MyChannelScheme = "http";
      portSet = true;
   }

   // Constructor for MyCustomChannel.
   MyCustomChannel()
   {
      MyChannelScheme = "http";
      portSet = false;
   }

   property bool WantsToListen 
   {
      // <Snippet2>
      [System::Security::Permissions::SecurityPermissionAttribute
      (System::Security::Permissions::SecurityAction::LinkDemand,
      Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
      virtual bool get()
      {
         if ( portSet )
         {
            return false;
         }
         else
         {
            return true;
         }
      }
   }
   // </Snippet2>

   // <Snippet3>
private:
   String^ MyChannelScheme;

public:
   property String^ ChannelScheme 
   {
      [System::Security::Permissions::SecurityPermissionAttribute
      (System::Security::Permissions::SecurityAction::LinkDemand,
      Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
      virtual String^ get()
      {
         return MyChannelScheme;
      }
   }
   // </Snippet3>

   property IServerChannelSink^ ChannelSinkChain 
   {
      [System::Security::Permissions::SecurityPermissionAttribute
      (System::Security::Permissions::SecurityAction::LinkDemand,
      Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
      virtual IServerChannelSink^ get()
      {
         
         // Null implementation.
         return nullptr;
      }
   }

   [System::Security::Permissions::SecurityPermissionAttribute
   (System::Security::Permissions::SecurityAction::LinkDemand,
   Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
   virtual void AddHookChannelUri( String^ /*channelUri*/ )
   {
      // Null implementation.
   }
};
// </Snippet1>

int main()
{
   try
   {
      MyCustomChannel^ myCustomChannelWithPort = gcnew MyCustomChannel( 8085 );
      MyCustomChannel^ myCustomChannelNoPort = gcnew MyCustomChannel;
      Console::WriteLine( "Channel Scheme of myCustomChannelWithPort : {0}",
         myCustomChannelWithPort->ChannelScheme );
      Console::WriteLine( "Channel Scheme of myCustomChannelNoPort : {0}",
         myCustomChannelNoPort->ChannelScheme );
      // 'WantsToListen' is false. It is already listening.
      if ( myCustomChannelWithPort->WantsToListen )
      {
         Console::WriteLine( "myCustomChannelWithPort wants to listen." );
      }
      else
      {
         Console::WriteLine( "myCustomChannelWithPort doesn't want to listen." );
      }
      if ( myCustomChannelNoPort->WantsToListen )
      {
         Console::WriteLine( "myCustomChannelNoPort wants to listen." );
      }
      else
      {
         Console::WriteLine( "myCustomChannelNoPort doesn't want to listen." );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception caught!!!" );
      Console::WriteLine( "Source : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }
}
