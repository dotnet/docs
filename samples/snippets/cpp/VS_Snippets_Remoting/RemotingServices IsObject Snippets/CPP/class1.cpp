

#using <system.dll>

using namespace System;
using namespace System::Runtime::Remoting;

namespace TempConverter
{
   public ref class Converter: public MarshalByRefObject{};

}

ref class Client
{
public:
   void RunSnippet()
   {
      // <Snippet1>
      // Create a remote version of TempConverter::Converter.
      TempConverter::Converter^ converter1 =
            dynamic_cast<TempConverter::Converter^>(Activator::GetObject(
            TempConverter::Converter::typeid,
            "http://localhost:8085/TempConverter" ));

      // Create a local version of TempConverter::Converter.
      TempConverter::Converter^ converter2 = gcnew TempConverter::Converter;

      // Returns true, converter1 is remote and in a different appdomain.
      System::Runtime::Remoting::RemotingServices::IsObjectOutOfAppDomain( converter1 );

      // Returns false, converter2 is local and running in this appdomain.
      System::Runtime::Remoting::RemotingServices::IsObjectOutOfAppDomain( converter2 );

      // Returns true, converter1 is remote and in a different context.
      System::Runtime::Remoting::RemotingServices::IsObjectOutOfContext( converter1 );

      // Returns false, converter2 is local and running in this context.
      System::Runtime::Remoting::RemotingServices::IsObjectOutOfContext( converter2 );
      // </Snippet1>        

      // Print those function calls.
      System::Console::WriteLine( " {0}", RemotingServices::IsObjectOutOfAppDomain( converter1 ) );
      System::Console::WriteLine( " {0}", RemotingServices::IsObjectOutOfAppDomain( converter2 ) );
      System::Console::WriteLine( " {0}", RemotingServices::IsObjectOutOfContext( converter1 ) );
      System::Console::WriteLine( " {0}", RemotingServices::IsObjectOutOfContext( converter2 ) );
   }
};

int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   Client^ client = gcnew Client;
   client->RunSnippet();
   return 0;
}
