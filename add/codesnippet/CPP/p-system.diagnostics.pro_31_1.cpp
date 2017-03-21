      Process^ myProcess = gcnew Process;
      ProcessStartInfo^ myProcessStartInfo = gcnew ProcessStartInfo( "net ",String::Concat( "use ", args[ 0 ] ) );

      myProcessStartInfo->UseShellExecute = false;
      myProcessStartInfo->RedirectStandardError = true;
      myProcess->StartInfo = myProcessStartInfo;
      myProcess->Start();

      StreamReader^ myStreamReader = myProcess->StandardError;
      // Read the standard error of net.exe and write it on to console.
      Console::WriteLine( myStreamReader->ReadLine() );
      myProcess->Close();