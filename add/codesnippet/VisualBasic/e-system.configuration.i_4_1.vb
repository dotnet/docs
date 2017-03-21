   ' MyInstaller is derived from the class 'Installer'.
   Sub New()
      MyBase.New()
      AddHandler BeforeUninstall, AddressOf BeforeUninstallEventHandler
   End Sub 'New

   Private Sub BeforeUninstallEventHandler(sender As Object, e As InstallEventArgs)
      ' Add steps to perform any actions before the Uninstall process.
      Console.WriteLine("Code for BeforeUninstallEventHandler")
   End Sub 'BeforeUninstallEventHandler