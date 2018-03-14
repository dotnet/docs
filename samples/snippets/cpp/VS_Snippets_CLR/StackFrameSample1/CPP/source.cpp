

//<snippet1>
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;

// This console application illustrates various uses
// of the StackTrace and StackFrame classes.
namespace SampleInternal
{
   public ref class ClassLevel6
   {
   public:
      void Level6Method()
      {
         throw gcnew Exception( "An error occurred in the lowest internal class method." );
      }

   };

   public ref class ClassLevel5
   {
   public:

      //<snippet8>
      void Level5Method()
      {
         try
         {
            ClassLevel6^ nestedClass = gcnew ClassLevel6;
            nestedClass->Level6Method();
         }
         catch ( Exception^ e ) 
         {
            Console::WriteLine( " Level5Method exception handler" );
            StackTrace^ st = gcnew StackTrace;
            
            // Display the most recent function call.
            StackFrame^ sf = st->GetFrame( 0 );
            Console::WriteLine();
            Console::WriteLine( "  Exception in method: " );
            Console::WriteLine( "      {0}", sf->GetMethod() );
            if ( st->FrameCount > 1 )
            {
               
               // Display the highest-level function call
               // in the trace.
               sf = st->GetFrame( st->FrameCount - 1 );
               Console::WriteLine( "  Original function call at top of call stack):" );
               Console::WriteLine( "      {0}", sf->GetMethod() );
            }
            Console::WriteLine();
            Console::WriteLine( "   ... throwing exception to next level ..." );
            Console::WriteLine( "-------------------------------------------------\n" );
            throw e;
         }

      }

      //</snippet8>   
   };

   public ref class ClassLevel4
   {
   public:
      void Level4Method()
      {
         
         //<snippet6>
         try
         {
            ClassLevel5^ nestedClass = gcnew ClassLevel5;
            nestedClass->Level5Method();
         }
         catch ( Exception^ e ) 
         {
            Console::WriteLine( " Level4Method exception handler" );
            
            // Build a stack trace from a dummy stack frame.
            // Explicitly specify the source file name, line number
            // and column number.
            StackTrace^ st = gcnew StackTrace( gcnew StackFrame( "source.cs",79,24 ) );
            Console::WriteLine( " Stack trace with dummy stack frame: {0}", st->ToString() );
            
            // Access the StackFrames explicitly to display the file
            // name, line number and column number properties.
            // StackTrace.ToString only includes the method name. 
            for ( int i = 0; i < st->FrameCount; i++ )
            {
               StackFrame^ sf = st->GetFrame( i );
               Console::WriteLine( " File: {0}", sf->GetFileName() );
               Console::WriteLine( " Line Number: {0}", sf->GetFileLineNumber().ToString() );
               Console::WriteLine( " Column Number: {0}", sf->GetFileColumnNumber().ToString() );

            }
            Console::WriteLine();
            Console::WriteLine( "   ... throwing exception to next level ..." );
            Console::WriteLine( "-------------------------------------------------\n" );
            throw e;
         }

         
         //</snippet6>
      }

   };

   public ref class ClassLevel3
   {
   public:

      //<snippet5>
      void Level3Method()
      {
         try
         {
            ClassLevel4^ nestedClass = gcnew ClassLevel4;
            nestedClass->Level4Method();
         }
         catch ( Exception^ e ) 
         {
            Console::WriteLine( " Level3Method exception handler" );
            
            // Build a stack trace from a dummy stack frame.
            // Explicitly specify the source file name and line number.
            StackTrace^ st = gcnew StackTrace( gcnew StackFrame( "source.cs",60 ) );
            Console::WriteLine( " Stack trace with dummy stack frame: {0}", st->ToString() );
            for ( int i = 0; i < st->FrameCount; i++ )
            {
               
               //<snippet7>
               // Display the stack frame properties.
               StackFrame^ sf = st->GetFrame( i );
               Console::WriteLine( " File: {0}", sf->GetFileName() );
               Console::WriteLine( " Line Number: {0}", sf->GetFileLineNumber().ToString() );
               
               // Note that the column number defaults to zero
               // when not initialized.
               Console::WriteLine( " Column Number: {0}", sf->GetFileColumnNumber().ToString() );
               Console::WriteLine( " Intermediate Language Offset: {0}", sf->GetILOffset().ToString() );
               Console::WriteLine( " Native Offset: {0}", sf->GetNativeOffset().ToString() );
               
               //</snippet7>

            }
            Console::WriteLine();
            Console::WriteLine( "   ... throwing exception to next level ..." );
            Console::WriteLine( "-------------------------------------------------\n" );
            throw e;
         }

      }

      //</snippet5>
   };

   public ref class ClassLevel2
   {
   public:

      //<snippet4>
      void Level2Method()
      {
         try
         {
            ClassLevel3^ nestedClass = gcnew ClassLevel3;
            nestedClass->Level3Method();
         }
         catch ( Exception^ e ) 
         {
            Console::WriteLine( " Level2Method exception handler" );
            
            // Display the full call stack at this level.
            StackTrace^ st1 = gcnew StackTrace( true );
            Console::WriteLine( " Stack trace for this level: {0}", st1->ToString() );
            
            // Build a stack trace from one frame, skipping the
            // current frame and using the next frame.
            StackTrace^ st2 = gcnew StackTrace( gcnew StackFrame( 1,true ) );
            Console::WriteLine( " Stack trace built with next level frame: {0}", st2->ToString() );
            
            // Build a stack trace skipping the current frame, and
            // including all the other frames.
            StackTrace^ st3 = gcnew StackTrace( 1,true );
            Console::WriteLine( " Stack trace built from the next level up: {0}", st3->ToString() );
            Console::WriteLine();
            Console::WriteLine( "   ... throwing exception to next level ..." );
            Console::WriteLine( "-------------------------------------------------\n" );
            throw e;
         }

      }

      //</snippet4>
   };

   public ref class ClassLevel1
   {
   public:

      //<snippet3>
      void InternalMethod()
      {
         try
         {
            ClassLevel2^ nestedClass = gcnew ClassLevel2;
            nestedClass->Level2Method();
         }
         catch ( Exception^ e ) 
         {
            Console::WriteLine( " InternalMethod exception handler" );
            
            // Build a stack trace from one frame, skipping the
            // current frame and using the next frame.  By
            // default, file and line information are not displayed.
            StackTrace^ st = gcnew StackTrace( gcnew StackFrame( 1 ) );
            Console::WriteLine( " Stack trace for next level frame: {0}", st->ToString() );
            Console::WriteLine( " Stack frame for next level: " );
            Console::WriteLine( "   {0}", st->GetFrame( 0 )->ToString() );
            Console::WriteLine( " Line Number: {0}", st->GetFrame( 0 )->GetFileLineNumber().ToString() );
            Console::WriteLine();
            Console::WriteLine( "   ... throwing exception to next level ..." );
            Console::WriteLine( "-------------------------------------------------\n" );
            throw e;
         }

      }

      //</snippet3>
   };

}


using namespace SampleInternal;

namespace SamplePublic
{
   class ConsoleApp
   {
   public:

      //<snippet2>

      [STAThread]
      static void Main()
      {
         ClassLevel1 ^ mainClass = gcnew ClassLevel1;
         try
         {
            mainClass->InternalMethod();
         }
         catch ( Exception^ e ) 
         {
            Console::WriteLine( " Main method exception handler" );
            
            // Display file and line information, if available.
            StackTrace^ st = gcnew StackTrace( gcnew StackFrame( true ) );
            Console::WriteLine( " Stack trace for current level: {0}", st->ToString() );
            Console::WriteLine( " File: {0}", st->GetFrame( 0 )->GetFileName() );
            Console::WriteLine( " Line Number: {0}", st->GetFrame( 0 )->GetFileLineNumber().ToString() );
            Console::WriteLine();
            Console::WriteLine( "-------------------------------------------------\n" );
         }

      }

      //</snippet2>
   };

}

int main()
{
   SamplePublic::ConsoleApp::Main();
}

//</snippet1>
