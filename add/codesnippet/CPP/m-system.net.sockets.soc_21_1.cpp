      try
      {
         aSocket->Bind( anEndPoint );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Winsock error: {0}", e );
      }