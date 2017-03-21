         // Compare the file name and 'RequestUri' is same or not.
         if ( myFileWebRequest->RequestUri->Equals( myUrl ) )
         {
            // 'GetRequestStream' method returns the stream handler for writing into the file.
            Stream^ readStream = myFileWebRequest->GetRequestStream();
            // Write to the stream
            readStream->Write( byteArray, 0, userInput->Length );
            readStream->Close();
         }

         Console::WriteLine( "\nThe String you entered was successfully written into the file." );
         Console::WriteLine( "The content length sent to the server is {0}.", myFileWebRequest->ContentLength );