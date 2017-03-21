      Dim myAssemblyInstaller1 As New AssemblyInstaller()
      Dim myInstallerCollection1 As InstallerCollection = _
                                            myAssemblyInstaller1.Installers
      ' 'myAssemblyInstaller' is an installer of type 'AssemblyInstaller'.
      myInstallerCollection1.Add(myAssemblyInstaller)

      Dim myInstaller1 As Installer = myAssemblyInstaller.Parent
      Console.WriteLine("Parent of myAssembly : {0}", myInstaller1.ToString())