         Dim myInstallers As New ArrayList()
         Dim myTransactedInstaller As New TransactedInstaller()
         Dim myAssemblyInstaller As AssemblyInstaller
         Dim myInstallContext As InstallContext
         
         ' Create a instance of 'AssemblyInstaller' that installs 'MyAssembly1.exe'.
         myAssemblyInstaller = New AssemblyInstaller("MyAssembly1.exe", Nothing)
         
         ' Add the instance of 'AssemblyInstaller' to the list of installers.  
         myInstallers.Add(myAssemblyInstaller)
         
         ' Create a instance of 'AssemblyInstaller' that installs 'MyAssembly2.exe'.
         myAssemblyInstaller = New AssemblyInstaller("MyAssembly2.exe", Nothing)
         
         ' Add the instance of 'AssemblyInstaller' to the list of installers.  
         myInstallers.Add(myAssemblyInstaller)
         
         ' Add the installers to the 'TransactedInstaller' instance.
         myTransactedInstaller.Installers.AddRange(CType(myInstallers.ToArray(GetType(Installer)), _
                                                                              Installer()))