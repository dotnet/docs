using namespace System;

public ref class HelloServer: public MarshalByRefObject
{
public:
   HelloServer( String^ passedString )
   {
      Console::WriteLine( "HelloServer activated" );
      Console::WriteLine(  "Paramater passed to the constructor is {0}", passedString );
   }

   String^ HelloMethod( String^ name )
   {
      Console::WriteLine( "HelloMethod : {0}", name );
      return String::Format(  "Hi there {0}", name );
   }
};
