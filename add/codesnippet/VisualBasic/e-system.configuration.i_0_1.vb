   ' MyInstaller is derived from the class 'Installer'.
   Sub New()
      MyBase.New()
      AddHandler BeforeInstall, AddressOf BeforeInstallEventHandler
   End Sub 'New

   Private Sub BeforeInstallEventHandler(sender As Object, e As InstallEventArgs)
      ' Add steps to perform any actions before the install process.
      Console.WriteLine("Code for BeforeInstallEventHandler")
   End Sub 'BeforeInstallEventHandler