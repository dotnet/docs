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