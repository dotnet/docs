
//<snippet1>
using namespace System;
using namespace System::Threading;
using namespace System::Runtime::InteropServices;

// A simple class that exposes two static Win32 functions.
// One is a delegate type and the other is an enumerated type.
public ref class MyWin32
{
public:

   // An enumerated type for the control messages sent to the handler routine.
   enum class CtrlTypes
   {
      CTRL_C_EVENT = 0,
      CTRL_BREAK_EVENT, CTRL_CLOSE_EVENT, CTRL_LOGOFF_EVENT = 5,
      CTRL_SHUTDOWN_EVENT
   };

   delegate Boolean HandlerRoutine(    // A delegate type to be used as the Handler Routine for SetConsoleCtrlHandler.
   CtrlTypes CtrlType );

   // Declare the SetConsoleCtrlHandler function as external and receiving a delegate.

   [DllImport("Kernel32")]
   static Boolean SetConsoleCtrlHandler( HandlerRoutine^ Handler, Boolean Add );
};

public ref class MyApp
{
private:

   // A private static handler function in the MyApp class.
   static Boolean Handler( MyWin32::CtrlTypes CtrlType )
   {
      String^ message = "This message should never be seen!";
      
      // A switch to handle the event type.
      switch ( CtrlType )
      {
         case MyWin32::CtrlTypes::CTRL_C_EVENT:
            message = "A CTRL_C_EVENT was raised by the user.";
            break;

         case MyWin32::CtrlTypes::CTRL_BREAK_EVENT:
            message = "A CTRL_BREAK_EVENT was raised by the user.";
            break;

         case MyWin32::CtrlTypes::CTRL_CLOSE_EVENT:
            message = "A CTRL_CLOSE_EVENT was raised by the user.";
            break;

         case MyWin32::CtrlTypes::CTRL_LOGOFF_EVENT:
            message = "A CTRL_LOGOFF_EVENT was raised by the user.";
            break;

         case MyWin32::CtrlTypes::CTRL_SHUTDOWN_EVENT:
            message = "A CTRL_SHUTDOWN_EVENT was raised by the user.";
            break;
      }
      
      // Use interop to display a message for the type of event.
      Console::WriteLine( message );
      return true;
   }


public:
   static void Test()
   {
      
      // Use interop to set a console control handler.
      MyWin32::HandlerRoutine^ hr = gcnew MyWin32::HandlerRoutine( Handler );
      MyWin32::SetConsoleCtrlHandler( hr, true );
      
      // Give the user some time to raise a few events.
      Console::WriteLine( "Waiting 30 seconds for console ctrl events..." );
      
      // The Object hr is not referred to again.
      // The garbage collector can detect that the object has no
      // more managed references and might clean it up here while
      // the unmanaged SetConsoleCtrlHandler method is still using it.
      // Force a garbage collection to demonstrate how the hr
      // object will be handled.
      GC::Collect();
      GC::WaitForPendingFinalizers();
      GC::Collect();
      Thread::Sleep( 30000 );
      
      // Display a message to the console when the unmanaged method
      // has finished its work.
      Console::WriteLine( "Finished!" );
      
      // Call GC::KeepAlive(hr) at this point to maintain a reference to hr.
      // This will prevent the garbage collector from collecting the
      // object during the execution of the SetConsoleCtrlHandler method.
      GC::KeepAlive( hr );
   }

};

int main()
{
   MyApp::Test();
}

//</snippet1>
