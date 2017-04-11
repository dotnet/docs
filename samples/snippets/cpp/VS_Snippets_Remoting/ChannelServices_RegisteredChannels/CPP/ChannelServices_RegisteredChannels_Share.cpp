/*
   The class 'HelloServer' is derived from 'MarshalByRefObject' to 
   make it remotable.  
*/
using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;

namespace RemotingSamples 
{
   public ref class HelloServer : public MarshalByRefObject 
   {
public:
      HelloServer() 
      {
         Console::WriteLine("HelloServer activated");
      }

public:
      String^ HelloMethod(String^ myName) 
      {
         Console::WriteLine("Hello.HelloMethod : {0}", myName);
         return "Hi there " + myName;
      }
   };
}
