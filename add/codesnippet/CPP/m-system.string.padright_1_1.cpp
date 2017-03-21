      String^ str = "forty-two";
      Console::Write( "|" );
      Console::Write( str->PadRight( 15, '.' ) );
      Console::WriteLine( "|" ); // Displays "|forty-two......|".
      Console::Write( "|" );
      Console::Write( str->PadRight( 5, '.' ) );
      Console::WriteLine( "|" ); // Displays "|forty-two|".