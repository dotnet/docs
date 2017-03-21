         string[] myStringArray = new string[ 1 ];
         string myString;


         // Set the commandline argument array for 'logfile'.
         myStringArray[ 0 ] = "/logFile=example.log";

         // Set the name of the assembly to install.
         myString = "MyAssembly_Uninstall.exe";

         // Create an object of the 'AssemblyInstaller' class.
         AssemblyInstaller myAssemblyInstaller = new 
                  AssemblyInstaller( myString , myStringArray );