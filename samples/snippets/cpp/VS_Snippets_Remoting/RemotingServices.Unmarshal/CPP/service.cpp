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
   public ref class SampleTwo: public MarshalByRefObject
   {
   public:
      void PrintMessage( String^ s )
      {
         Console::WriteLine( "This message was received from the client:" );
	         Console::WriteLine( "\t {0}", s );
      }
   };

   // Define the remote service class
   public ref class SampleService: public MarshalByRefObject
   {
   public:
      bool SampleMethod()
      {
         Console::WriteLine( "Hello, you have called SampleMethod()." );
         return true;
      }

      ObjRef^ GetManuallyMarshaledObject()
      {
         SampleTwo^ objectTwo = gcnew SampleTwo;
         ObjRef^ objRefTwo = RemotingServices::Marshal( objectTwo );
         return objRefTwo;
      }
   };
}
