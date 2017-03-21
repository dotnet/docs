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

