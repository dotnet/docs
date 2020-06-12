

// <Snippet4>
#using <system.dll>

using namespace System;
public ref class HelloService: public MarshalByRefObject
{
private:
   static int n_instances;

public:
   HelloService()
   {
      n_instances++;
      Console::WriteLine( "" );
      Console::WriteLine( "HelloService activated - instance # {0}.", n_instances );
   }

   ~HelloService()
   {
      Console::WriteLine( "HelloService instance {0} destroyed.", n_instances );
      n_instances--;
   }

   String^ HelloMethod( String^ name )
   {
      Console::WriteLine( "HelloMethod called on HelloService instance {0}.", n_instances );
      return String::Format( "Hi there {0}.", name );
   }

};

// </Snippet4>
