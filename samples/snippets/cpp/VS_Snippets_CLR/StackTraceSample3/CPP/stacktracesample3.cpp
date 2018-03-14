

#using <System.dll>

using namespace System;
using namespace System::Diagnostics;
ref class MyConsoleApp
{
private:

   //<snippet5>
   ref class MyInnerClass
   {
   public:
      void ThrowsException()
      {
         try
         {
            throw gcnew Exception( "A problem was encountered." );
         }
         catch ( Exception^ ) 
         {
            
            // Log the Exception. We do not want to reveal the
            // inner workings of the class, or be too verbose, so
            // we will create a StackTrace with a single
            // StackFrame, where the frame is that of the calling
            // method.
            //<snippet6>
            StackFrame^ fr = gcnew StackFrame( 1,true );
            StackTrace^ st = gcnew StackTrace( fr );
            EventLog::WriteEntry( fr->GetMethod()->Name, st->ToString(), EventLogEntryType::Warning );
            //</snippet6>

            // Note that whenever this application is run, the EventLog
            // contains an Event similar to the following Event.
            //
            //     Event Type: Warning
            //     Event Source:   MyPublicMethod
            //     Event Category: None
            //     Event ID:   0
            //     Date:       6/17/2001
            //     Time:       6:39:56 PM
            //     User:       N/A
            //     Computer:   MYCOMPUTER
            //     Description:
            //
            //        at MyConsoleApp.MyPublicMethod()
            //
            //     For more information, see Help and Support Center at
            //     http://go.microsoft.com/fwlink/events.asp.
         }

      }

   };
   //</snippet5>


public:

   //<snippet2>
   void MyPublicMethod()
   {
      MyInnerClass^ helperClass = gcnew MyInnerClass;
      helperClass->ThrowsException();
   }

};

void main()
{
   MyConsoleApp^ helperClass = gcnew MyConsoleApp;
   helperClass->MyPublicMethod();
}

/*
This console application produces the following output
when compiled with optimization off.

Note that the ThrowsException() method is not identified in
this stack trace.

  Method: Void MyPublicMethod()
  Method: Void Main()

*/
//</snippet2>
