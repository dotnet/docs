         Dim myTransactedInstaller As New TransactedInstaller()
         Dim myAssemblyInstaller As AssemblyInstaller
         Dim myInstallContext As InstallContext
         
         ' Create a instance of 'AssemblyInstaller' that installs 'MyAssembly1.exe'.
         myAssemblyInstaller = New AssemblyInstaller("MyAssembly1.exe", Nothing)
         
         ' Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
         myTransactedInstaller.Installers.Add(myAssemblyInstaller)
         
         ' Create a instance of 'AssemblyInstaller' that installs 'MyAssembly2.exe'.
         myAssemblyInstaller = New AssemblyInstaller("MyAssembly2.exe", Nothing)
         
         ' Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.  
         myTransactedInstaller.Installers.Add(myAssemblyInstaller)
         
         'Print the assemblies to be installed.
         Dim myInstallers As InstallerCollection = myTransactedInstaller.Installers
         Console.WriteLine(ControlChars.Newline + "Printing all assemblies to be installed")
         Dim i As Integer
         For i = 0 To myInstallers.Count - 1
            If myInstallers(i).GetType().Equals(GetType(AssemblyInstaller)) Then
               Console.WriteLine("{0} {1}", i + 1, CType(myInstallers(i), AssemblyInstaller).Path)
            End If
         Next i