

//<snippet2>
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;
ref class MyConsoleApp
{
private:
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
            
            // Create a StackTrace starting at the next level
            // stack frame.  Skip the first frame, the frame of
            // this level, which hides the internal implementation
            // of the ThrowsException method.  Include the line
            // number, file name, and column number information
            // for each frame.
            //<snippet3>
            StackTrace^ st = gcnew StackTrace( 1,true );
            array<StackFrame^>^stFrames = st->GetFrames();
            for ( int i; i < stFrames->Length; i++ )
            {
               StackFrame^ sf = stFrames[ i ];
               Console::WriteLine( "Method: {0}", sf->GetMethod() );

            }
            //</Snippet3>
         }

      }

   };


public:
   void MyPublicMethod()
   {
      MyInnerClass^ helperClass = gcnew MyInnerClass;
      helperClass->ThrowsException();
   }

};

void main()
{
   MyConsoleApp^ myApp = gcnew MyConsoleApp;
   myApp->MyPublicMethod();
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
