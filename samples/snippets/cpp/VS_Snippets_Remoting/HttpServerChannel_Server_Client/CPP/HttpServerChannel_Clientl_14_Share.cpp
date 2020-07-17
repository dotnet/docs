/* This program will define the methods to execute from the client.
  */
using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;

public ref class MyHelloServer : public MarshalByRefObject 
{
public:
   MyHelloServer() 
   {
      Console::WriteLine("HelloServer activated");
   }

public:
   String^ myHelloMethod(String^ name) 
   {
      Console::WriteLine("Hello.HelloMethod : {0}", name);
      return "Hi there " + name;
   }
};