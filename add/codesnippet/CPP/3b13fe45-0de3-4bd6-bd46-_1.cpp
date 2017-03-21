      array<String^>^myStringArray = {"/logFile=example.log"};
      String^ myString = "MyAssembly_Uninstall.exe";
      
      // Create an object of the 'AssemblyInstaller' class.
      AssemblyInstaller^ myAssemblyInstaller =
         gcnew AssemblyInstaller( myString,myStringArray );