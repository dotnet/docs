      Dim myAssemblyInstaller As New AssemblyInstaller()
      Dim myServiceInstaller As New ServiceInstaller()
      Dim myEventLogInstaller As New EventLogInstaller()
      Dim myInstallerCollection As InstallerCollection = _
                                             myAssemblyInstaller.Installers

      ' Add Installers to the InstallerCollection of 'myAssemblyInstaller'.
      myInstallerCollection.Add(myServiceInstaller)
      myInstallerCollection.Add(myEventLogInstaller)

      Dim myInstaller(1) As Installer
      myInstallerCollection.CopyTo(myInstaller, 0)
      ' Show the contents of the InstallerCollection of 'myAssemblyInstaller'.
      Console.WriteLine("Installers in the InstallerCollection : ")
      Dim iIndex As Integer
      For iIndex = 0 To myInstaller.Length - 1
         Console.WriteLine(myInstaller(iIndex).ToString())
      Next iIndex