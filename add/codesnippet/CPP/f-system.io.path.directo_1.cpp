   Console::WriteLine( "Path::AltDirectorySeparatorChar={0}", (Path::AltDirectorySeparatorChar).ToString() );
   Console::WriteLine( "Path::DirectorySeparatorChar={0}", (Path::DirectorySeparatorChar).ToString() );
   Console::WriteLine( "Path::PathSeparator={0}", (Path::PathSeparator).ToString() );
   Console::WriteLine( "Path::VolumeSeparatorChar={0}", (Path::VolumeSeparatorChar).ToString() );
   Console::Write( "Path::InvalidPathChars=" );
   for ( int i = 0; i < Path::InvalidPathChars->Length; i++ )
      Console::Write( Path::InvalidPathChars[ i ] );
   Console::WriteLine();

   // This code produces output similar to the following:
   // Note that the InvalidPathCharacters contain characters
   // outside of the printable character set.
   //
   // Path.AltDirectorySeparatorChar=/
   // Path.DirectorySeparatorChar=\
   // Path.PathSeparator=;
   // Path.VolumeSeparatorChar=: