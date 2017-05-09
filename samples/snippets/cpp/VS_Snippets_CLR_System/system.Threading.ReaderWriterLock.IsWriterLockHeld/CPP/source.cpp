
// <Snippet1>
using namespace System;
using namespace System::Threading;
int main()
{
   ReaderWriterLock^ rwLock = gcnew ReaderWriterLock;
   rwLock->AcquireWriterLock( Timeout::Infinite );
   rwLock->AcquireReaderLock( Timeout::Infinite );
   if ( rwLock->IsReaderLockHeld )
   {
      Console::WriteLine( "Reader lock held." );
      rwLock->ReleaseReaderLock();
   }
   else
   if ( rwLock->IsWriterLockHeld )
   {
      Console::WriteLine( "Writer lock held." );
      rwLock->ReleaseWriterLock();
   }
   else
   {
      Console::WriteLine( "No locks held." );
   }


   if ( rwLock->IsReaderLockHeld )
   {
      Console::WriteLine( "Reader lock held." );
      rwLock->ReleaseReaderLock();
   }
   else
   if ( rwLock->IsWriterLockHeld )
   {
      Console::WriteLine( "Writer lock held." );
      rwLock->ReleaseWriterLock();
   }
   else
   {
      Console::WriteLine( "No locks held." );
   }
}

// </Snippet1>
