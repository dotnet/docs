#using <system.dll>
#using <system.runtime.remoting.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace System::Runtime::Remoting::Channels::Http;
using namespace System::Runtime::Remoting::Lifetime;

namespace SampleNamespace
{
   // Define the event arguments
   [Serializable]
   public ref class SampleServiceEventArgs: public EventArgs
   {
   private:
      String^ m_Message;

   public:
      SampleServiceEventArgs( String^ message )
      {
         m_Message = message;
      }

      property String^ Message 
      {
         String^ get()
         {
            return m_Message;
         }
      }
   };
   
   // Define the delegate for the event
   public delegate void SomethingHappenedEventHandler(Object^ sender, SampleServiceEventArgs^ e );

   // Define the remote service class
   public ref class SampleService: public MarshalByRefObject
   {
      // The client will subscribe and unsubscribe to this event
   public:
      event SomethingHappenedEventHandler^ SomethingHappened;

      bool SampleMethod()
      {
         Console::WriteLine( "Hello, you have called SampleMethod()." );
         
         // Fire Event
         // Package String in TimerServiceEventArgs
         SampleServiceEventArgs^ sampleEventArgs = gcnew SampleServiceEventArgs( "Something happened" );
         Console::WriteLine( "Firing SomethingHappened Event" );
         SomethingHappened( this, sampleEventArgs );

         return true;
      }
   };
}
