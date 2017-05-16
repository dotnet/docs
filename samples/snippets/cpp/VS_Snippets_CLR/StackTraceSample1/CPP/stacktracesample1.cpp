

//<snippet1>
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;
ref class StackTraceSample
{
private:
   ref class MyInternalClass
   {
   public:
      void ThrowsException()
      {
         try
         {
            throw gcnew Exception( "A problem was encountered." );
         }
         catch ( Exception^ e ) 
         {
            
            // Create a StackTrace that captures
            // filename, line number, and column
            // information for the current thread.
            StackTrace^ st = gcnew StackTrace( true );
            String^ stackIndent = "";
            for ( int i = 0; i < st->FrameCount; i++ )
            {
               
               // Note that at this level, there are five
               // stack frames, one for each method invocation.
               StackFrame^ sf = st->GetFrame( i );
               Console::WriteLine();
               Console::WriteLine( "{0}Method: {1}", stackIndent, sf->GetMethod() );
               Console::WriteLine( "{0}File: {1}", stackIndent, sf->GetFileName() );
               Console::WriteLine( "{0}Line Number: {1}", stackIndent, sf->GetFileLineNumber().ToString() );
               stackIndent = String::Concat( stackIndent, "  " );

            }
            throw e;
         }

      }

   };


protected:
   void MyProtectedMethod()
   {
      MyInternalClass^ mic = gcnew MyInternalClass;
      mic->ThrowsException();
   }


public:
   void MyPublicMethod()
   {
      MyProtectedMethod();
   }

};

int main()
{
   StackTraceSample^ sample = gcnew StackTraceSample;
   try
   {
      sample->MyPublicMethod();
   }
   catch ( Exception^ ) 
   {
      
      // Create a StackTrace that captures
      // filename, line number, and column
      // information for the current thread.
      StackTrace^ st = gcnew StackTrace( true );
      for ( int i = 0; i < st->FrameCount; i++ )
      {
         
         // For an executable built from C++, there
         // are two stack frames here: one for main,
         // and one for the _mainCRTStartup stub. 
         StackFrame^ sf = st->GetFrame( i );
         Console::WriteLine();
         Console::WriteLine( "High up the call stack, Method: {0}", sf->GetMethod()->ToString() );
         Console::WriteLine( "High up the call stack, Line Number: {0}", sf->GetFileLineNumber().ToString() );

      }
   }

}

/*
This console application produces the following output when
compiled with the Debug configuration.

  Method: Void ThrowsException()
  File: c:\samples\stacktraceframe\myclass.cpp
  Line Number: 20

    Method: Void MyProtectedMethod()
    File: c:\samples\stacktraceframe\myclass.cpp
    Line Number: 45

      Method: Void MyPublicMethod()
      File: c:\samples\stacktraceframe\myclass.cpp
      Line Number: 50
 
        Method: Int32 main()
        File: c:\samples\stacktraceframe\myclass.cpp
        Line Number: 56

          Method: UInt32 _mainCRTStartup()
          File:
          Line Number: 0

  High up the call stack, Method: Int32 main()
  High up the call stack, Line Number: 62

  High up the call stack, Method: UInt32 _mainCRTStartup()
  High up the call stack, Line Number: 0

This console application produces the following output when
compiled with the Release configuration.

  Method: Void ThrowsException()
  File:
  Line Number: 0

    Method: Int32 main()
    File:
    Line Number: 0

      Method: UInt32 _mainCRTStartup()
      File:
      Line Number: 0

  High up the call stack, Method: Int32 main()
  High up the call stack, Line Number: 0

  High up the call stack, Method: UInt32 _mainCRTStartup()
  High up the call stack, Line Number: 0

*/
//</snippet1>
