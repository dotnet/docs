         Dim myTransactedInstaller As New TransactedInstaller()
         Dim myAssemblyInstaller1 As AssemblyInstaller
         Dim myAssemblyInstaller2 As AssemblyInstaller
         Dim myInstallContext As InstallContext
         
         ' Create a instance of 'AssemblyInstaller' that installs 'MyAssembly1.exe'.
         myAssemblyInstaller1 = New AssemblyInstaller("MyAssembly1.exe", Nothing)
         
         ' Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
         myTransactedInstaller.Installers.Insert(0, myAssemblyInstaller1)
         
         ' Create a instance of 'AssemblyInstaller' that installs 'MyAssembly2.exe'.
         myAssemblyInstaller2 = New AssemblyInstaller("MyAssembly2.exe", Nothing)
         
         ' Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
         myTransactedInstaller.Installers.Insert(1, myAssemblyInstaller2)
         
         ' Remove the 'myAssemblyInstaller2' from the 'Installers' collection.
         If myTransactedInstaller.Installers.Contains(myAssemblyInstaller2) Then
            Console.WriteLine(ControlChars.Newline + "Installer at index : {0} is being removed", _
                              myTransactedInstaller.Installers.IndexOf(myAssemblyInstaller2))
            myTransactedInstaller.Installers.Remove(myAssemblyInstaller2)
         End If