
// This is the implementation class for the remote object.
using namespace System;
public ref class MyServerImpl: public MarshalByRefObject
{
public:
   MyServerImpl(){}

   String^ MyMethod( String^ name )
   {
      return String::Format( "The string from client is {0}", name );
   }
};
