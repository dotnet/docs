#using <system.dll>
#using <system.runtime.remoting.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace System::Runtime::Remoting::Lifetime;

namespace RemotingSamples
{
   public ref class HelloService: public MarshalByRefObject
   {
   public:
      String^ HelloMethod( String^ name )
      {
         Console::WriteLine( "Hello {0}", name );
         return String::Format( "Hello {0}", name );
      }
   };
}
