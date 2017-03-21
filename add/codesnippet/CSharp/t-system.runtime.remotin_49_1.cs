// Implementation of 'IChannelReceiverHook' interface.
[PermissionSet(SecurityAction.Demand, Name="FullTrust")]
public class MyCustomChannel : IChannelReceiverHook 
{
   private bool portSet;
   // Constructor for MyCustomChannel.
   public MyCustomChannel(int port)
   {
      portSet = true;
   }
   // Constructor for MyCustomChannel.
   public MyCustomChannel()
   {
      portSet = false;
   }
   public bool WantsToListen
   {
      get
      {
         if (portSet)
         {
            return false;
         }
         else
         {
            return true;
         }
      }
   }
   private string MyChannelScheme = "http";
   public string ChannelScheme
   {
      get
      {
         return MyChannelScheme;
      }
   }
   public IServerChannelSink ChannelSinkChain
   {
      get
      {
         // Null implementation.
         return null;
      }
   }
   public void AddHookChannelUri(string channelUri)
   {
      // Null implementation.
   }
}