      // Create an InstallContext object with the given parameters.
      array<String^>^commandLine = gcnew array<String^>(args->Length - 1);
      for ( int i = 0; i < args->Length - 1; i++ )
      {
         commandLine[ i ] = args[ i + 1 ];
      }
      myInstallObject->myInstallContext = gcnew InstallContext( args[ 1 ],commandLine );