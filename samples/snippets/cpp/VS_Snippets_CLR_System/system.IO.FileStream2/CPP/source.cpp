
// <Snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Threading;

// Maintain state information to be passed to 
// EndWriteCallback and EndReadCallback.
ref class State
{
private:

   // fStream is used to read and write to the file.
   FileStream^ fStream;

   // writeArray stores data that is written to the file.
   array<Byte>^writeArray;

   // readArray stores data that is read from the file.
   array<Byte>^readArray;

   // manualEvent signals the main thread 
   // when verification is complete.
   ManualResetEvent^ manualEvent;

public:
   State( FileStream^ fStream, array<Byte>^writeArray, ManualResetEvent^ manualEvent )
   {
      this->fStream = fStream;
      this->writeArray = writeArray;
      this->manualEvent = manualEvent;
      readArray = gcnew array<Byte>(writeArray->Length);
   }


   property FileStream^ FStream 
   {
      FileStream^ get()
      {
         return fStream;
      }

   }

   property array<Byte>^ WriteArray 
   {
      array<Byte>^ get()
      {
         return writeArray;
      }

   }

   property array<Byte>^ ReadArray 
   {
      array<Byte>^ get()
      {
         return readArray;
      }

   }

   property ManualResetEvent^ ManualEvent 
   {
      ManualResetEvent^ get()
      {
         return manualEvent;
      }

   }

};

ref class FStream
{
private:

   // When BeginRead is finished reading data from the file, the 
   // EndReadCallback method is called to end the asynchronous 
   // read operation and then verify the data.
   // <Snippet4>
   static void EndReadCallback( IAsyncResult^ asyncResult )
   {
      State^ tempState = dynamic_cast<State^>(asyncResult->AsyncState);
      int readCount = tempState->FStream->EndRead( asyncResult );
      int i = 0;
      while ( i < readCount )
      {
         if ( tempState->ReadArray[ i ] != tempState->WriteArray[ i++ ] )
         {
            Console::WriteLine( "Error writing data." );
            tempState->FStream->Close();
            return;
         }
      }

      Console::WriteLine( "The data was written to {0} "
      "and verified.", tempState->FStream->Name );
      tempState->FStream->Close();
      
      // Signal the main thread that the verification is finished.
      tempState->ManualEvent->Set();
   }


public:

   // </Snippet4>
   // When BeginWrite is finished writing data to the file, the
   // EndWriteCallback method is called to end the asynchronous 
   // write operation and then read back and verify the data.
   // <Snippet3>
   static void EndWriteCallback( IAsyncResult^ asyncResult )
   {
      State^ tempState = dynamic_cast<State^>(asyncResult->AsyncState);
      FileStream^ fStream = tempState->FStream;
      fStream->EndWrite( asyncResult );
      
      // Asynchronously read back the written data.
      fStream->Position = 0;
      asyncResult = fStream->BeginRead( tempState->ReadArray, 0, tempState->ReadArray->Length, gcnew AsyncCallback( &FStream::EndReadCallback ), tempState );
      
      // Concurrently do other work, such as 
      // logging the write operation.
   }

};


// </Snippet3>
// <Snippet2>
int main()
{
   
   // Create a synchronization object that gets 
   // signaled when verification is complete.
   ManualResetEvent^ manualEvent = gcnew ManualResetEvent( false );
   
   // Create the data to write to the file.
   array<Byte>^writeArray = gcnew array<Byte>(100000);
   (gcnew Random)->NextBytes( writeArray );
   FileStream^ fStream = gcnew FileStream(  "Test#@@#.dat",FileMode::Create,FileAccess::ReadWrite,FileShare::None,4096,true );
   
   // Check that the FileStream was opened asynchronously.
   Console::WriteLine( "fStream was {0}opened asynchronously.", fStream->IsAsync ? (String^)"" : "not " );
   
   // Asynchronously write to the file.
   IAsyncResult^ asyncResult = fStream->BeginWrite( writeArray, 0, writeArray->Length, gcnew AsyncCallback( &FStream::EndWriteCallback ), gcnew State( fStream,writeArray,manualEvent ) );
   
   // Concurrently do other work and then wait 
   // for the data to be written and verified.
   manualEvent->WaitOne( 5000, false );
}

// </Snippet2>
// </Snippet1>
