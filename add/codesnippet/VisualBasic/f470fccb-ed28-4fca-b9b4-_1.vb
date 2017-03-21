      Dim myTransactedInstaller1 As New TransactedInstaller()
      Dim myTransactedInstaller2 As New TransactedInstaller()
      Dim myAssemblyInstaller As New AssemblyInstaller()
      Dim myInstallContext As InstallContext
      
      ' Create a instance of 'AssemblyInstaller' that installs 'MyAssembly1.exe'.
      myAssemblyInstaller = New AssemblyInstaller("MyAssembly1.exe", Nothing)
      
      ' Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
      myTransactedInstaller1.Installers.Insert(0, myAssemblyInstaller)
      
      ' Create a instance of 'AssemblyInstaller' that installs 'MyAssembly2.exe'.
      myAssemblyInstaller = New AssemblyInstaller("MyAssembly2.exe", Nothing)
      
      ' Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
      myTransactedInstaller1.Installers.Insert(1, myAssemblyInstaller)
      
      ' Copy the installers of 'myTransactedInstaller1' to 'myTransactedInstaller2'.
      myTransactedInstaller2.Installers.AddRange(myTransactedInstaller1.Installers)
      