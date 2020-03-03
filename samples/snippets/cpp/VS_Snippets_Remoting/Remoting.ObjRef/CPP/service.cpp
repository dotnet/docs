

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
   // Define the remote service class
   public ref class SampleService: public MarshalByRefObject
   {
   public:
      bool SampleMethod()
      {
         Console::WriteLine( "Hello, you have called SampleMethod()." );
         return true;
      }
   };
}
