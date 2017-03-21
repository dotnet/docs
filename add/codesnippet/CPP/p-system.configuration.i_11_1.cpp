      // Create an Object* of the 'AssemblyInstaller' class.
      AssemblyInstaller^ myAssemblyInstaller = gcnew AssemblyInstaller(
         "MyAssembly_HelpText.exe", commandLineOptions );
      
      // Set the 'UseNewContext' property to true.
      myAssemblyInstaller->UseNewContext = true;
      