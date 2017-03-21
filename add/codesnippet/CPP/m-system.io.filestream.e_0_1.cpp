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
