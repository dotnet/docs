      // Receive data using the BufferedStream.
      Console::WriteLine(  "Receiving data using BufferedStream." );
      bytesReceived = 0;
      startTime = DateTime::Now;
      while ( bytesReceived < numberOfLoops * receivedData->Length )
      {
         bytesReceived += bufStream->Read( receivedData, 0, receivedData->Length );
      }

      bufferedTime = (DateTime::Now - startTime).TotalSeconds;
      Console::WriteLine( "{0} bytes received in {1} seconds.\n", bytesReceived.ToString(), bufferedTime.ToString(  "F1" ) );
      