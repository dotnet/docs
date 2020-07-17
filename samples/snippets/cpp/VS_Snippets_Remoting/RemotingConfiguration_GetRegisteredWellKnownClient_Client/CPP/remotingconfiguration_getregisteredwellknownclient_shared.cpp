
using namespace System;

public ref class MyServerImpl: public MarshalByRefObject
{
public:
   MyServerImpl()
   {
      Console::WriteLine( "Server Activated" );
   }

   String^ MyMethod( String^ name )
   {
      return String::Format( "The string from client is {0}", name );
   }
};
