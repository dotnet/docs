

// <Snippet3>
#using <system.dll>

using namespace System;

public ref class HelloServiceClass: public MarshalByRefObject
{
private:
   static int n_instance;

public:
   HelloServiceClass()
   {
      n_instance++;
      Console::WriteLine(  "{0} has been created.  Instance # = {1}", this->GetType()->Name, n_instance );
   }

   ~HelloServiceClass()
   {
      Console::WriteLine( "Destroyed instance {0} of HelloServiceClass.", n_instance );
      n_instance--;
   }

   String^ HelloMethod( String^ name )
   {
      // Reports that the method was called.
      Console::WriteLine();
      Console::WriteLine( "Called HelloMethod on instance {0} with the '{1}' parameter.", n_instance, name );

      // Calculates and returns the result to the client.
      return String::Format( "Hi there {0}", name );
   }
};
// </Snippet3>
