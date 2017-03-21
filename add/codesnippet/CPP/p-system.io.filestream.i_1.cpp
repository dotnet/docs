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
