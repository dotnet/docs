
//<snippet20>
using namespace System;
public ref class HelloServer: public MarshalByRefObject
{
public:
   HelloServer( String^ myString )
   {
      Console::WriteLine( "HelloServer activated" );
      Console::WriteLine( "Paramater passed to the constructor is {0}", myString );
   }

   String^ HelloMethod( String^ myName )
   {
      Console::WriteLine( "HelloMethod : {0}", myName );
      return String::Format( "Hi there {0}", myName );
   }

};

//</snippet20>
