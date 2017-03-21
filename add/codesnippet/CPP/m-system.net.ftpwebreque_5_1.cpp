   // The EndGetResponseCallback method  
   // completes a call to BeginGetResponse.
   static void EndGetResponseCallback( IAsyncResult^ ar )
   {
      FtpState^ state = dynamic_cast<FtpState^>(ar->AsyncState);
      FtpWebResponse ^ response = nullptr;
      try
      {
         response = dynamic_cast<FtpWebResponse^>(state->Request->EndGetResponse( ar ));
         response->Close();
         state->StatusDescription = response->StatusDescription;

         // Signal the main application thread that 
         // the operation is complete.
         state->OperationComplete->Set();
      }
      // Return exceptions to the main application thread.
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Error getting response." );
         state->OperationException = e;
         state->OperationComplete->Set();
      }
   }