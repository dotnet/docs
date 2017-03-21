      // Set the logfile name in the commandline argument array.
      array<String^>^commandLineOptions = {"/LogFile=example.log"};
      myAssemblyInstaller->CommandLine = commandLineOptions;
      