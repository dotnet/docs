         // Enter the string to write into the file.
         Console::WriteLine( "Enter the string you want to write:" );
         String^ userInput = Console::ReadLine();
         
         // Convert the string to Byte array.
         ASCIIEncoding^ encoder = gcnew ASCIIEncoding;
         array<Byte>^byteArray = encoder->GetBytes( userInput );
         
         // Set the ContentLength property.
         myFileWebRequest->ContentLength = byteArray->Length;
         String^ contentLength = myFileWebRequest->ContentLength.ToString();
         Console::WriteLine( "\nThe content length is {0}.", contentLength );
         
         // Get the file stream handler to write into the file.
         Stream^ readStream = myFileWebRequest->GetRequestStream();
         
         // Write to the file stream.
         // Note. In order for this to work the file must be accessible
         // on the network. This can be accomplished by setting the property
         // sharing of the folder containg the file. The permissions
         // can be set so everyone can modify the file.
         // FileWebRequest::Credentials property cannot be used for this purpose.
         readStream->Write( byteArray, 0, userInput->Length );
         Console::WriteLine( "\nThe String you entered was successfully written into the file." );
         