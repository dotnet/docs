
// <Snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Threading;
ref class Search
{
private:

   // Maintain state information to pass to FindCallback.
   ref class State
   {
   public:
      AutoResetEvent^ autoEvent;
      String^ fileName;
      State( AutoResetEvent^ autoEvent, String^ fileName )
         : autoEvent( autoEvent ), fileName( fileName )
      {}

   };


public:
   array<AutoResetEvent^>^autoEvents;
   array<String^>^diskLetters;

   // Search for stateInfo->fileName.
   void FindCallback( Object^ state )
   {
      State^ stateInfo = dynamic_cast<State^>(state);
      
      // Signal if the file is found.
      if ( File::Exists( stateInfo->fileName ) )
      {
         stateInfo->autoEvent->Set();
      }
   }

   Search()
   {
      
      // Retrieve an array of disk letters.
      diskLetters = Environment::GetLogicalDrives();
      autoEvents = gcnew array<AutoResetEvent^>(diskLetters->Length);
      for ( int i = 0; i < diskLetters->Length; i++ )
      {
         autoEvents[ i ] = gcnew AutoResetEvent( false );

      }
   }


   // Search for fileName in the root directory of all disks.
   void FindFile( String^ fileName )
   {
      for ( int i = 0; i < diskLetters->Length; i++ )
      {
         Console::WriteLine(  "Searching for {0} on {1}.", fileName, diskLetters[ i ] );
         ThreadPool::QueueUserWorkItem( gcnew WaitCallback( this, &Search::FindCallback ), gcnew State( autoEvents[ i ],String::Concat( diskLetters[ i ], fileName ) ) );

      }
      
      // Wait for the first instance of the file to be found.
      int index = WaitHandle::WaitAny( autoEvents, TimeSpan(0,0,3), false );
      if ( index == WaitHandle::WaitTimeout )
      {
         Console::WriteLine( "\n{0} not found.", fileName );
      }
      else
      {
         Console::WriteLine( "\n{0} found on {1}.", fileName, diskLetters[ index ] );
      }
   }

};

int main()
{
   Search^ search = gcnew Search;
   search->FindFile( "SomeFile.dat" );
}

// </Snippet1>
