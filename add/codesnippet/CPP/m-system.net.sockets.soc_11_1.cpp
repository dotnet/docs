      aSocket->Shutdown( SocketShutdown::Both );
      aSocket->Close();
      if ( aSocket->Connected )
      {
         Console::WriteLine( "Winsock error: {0}", Convert::ToString(
            System::Runtime::InteropServices::Marshal::GetLastWin32Error() ) );
      }