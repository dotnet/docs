/* The class 'HelloServer' is derived from 'MarshalByRefObject' to make
   it remotable. Ihe method 'HelloMethod' can be called by the client
   after creating instance of the 'HelloServer' class.
*/
using namespace System;

public ref class HelloServer : public MarshalByRefObject 
{

public:
   HelloServer() 
   {
      Console::WriteLine("HelloServer activated");
   }

public:
   String^ HelloMethod(String^ name) 
   {
      Console::WriteLine("Hello.HelloMethod : {0}", name);
      return "Hi there " + name;
   }
};
