         Dim myStringArray(0) As String
         Dim myString As String
         

         ' Set the commandline argument array for 'logfile'.
         myStringArray(0) = "/logFile=example.log"
         
         ' Set the name of the assembly to install.
         myString = "MyAssembly_Uninstall.exe"
         
         ' Create an object of the 'AssemblyInstaller' class.
         Dim myAssemblyInstaller As New AssemblyInstaller(myString, myStringArray)