
// <Snippet1>
// The example should be compiled with the /clr:pure compiler option.
using namespace System;
using namespace System::Security::Permissions;

public ref class Example
{


private:
   static void MyHandler(Object^ sender, UnhandledExceptionEventArgs^ args)
   {
      Exception^ e = dynamic_cast<Exception^>(args->ExceptionObject);
      Console::WriteLine( "MyHandler caught : {0}", e->Message );
      Console::WriteLine("Runtime terminating: {0}", args->IsTerminating);
   }
   
public: 
   [SecurityPermissionAttribute( SecurityAction::Demand, ControlAppDomain = true )]
   static void Main()
   {
      AppDomain^ currentDomain = AppDomain::CurrentDomain;
      currentDomain->UnhandledException += gcnew UnhandledExceptionEventHandler(Example::MyHandler);
      try
      {
         throw gcnew Exception("1");
      }
      catch (Exception^ e) 
      {
         Console::WriteLine( "Catch clause caught : {0}\n", e->Message );
      }

      throw gcnew Exception("2");
   }
};

void main()
{
   Example::Main();
}   
// The example displays the following output:
//       Catch clause caught : 1
//       
//       MyHandler caught : 2
//       Runtime terminating: True
//       
//       Unhandled Exception: System.Exception: 2
//          at Example.Main()
//          at mainCRTStartup(String[] arguments)
// </Snippet1>
