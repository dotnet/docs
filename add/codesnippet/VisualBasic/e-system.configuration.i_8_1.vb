   ' MyInstaller is derived from the class 'Installer'.
   Sub New()
      MyBase.New()
      AddHandler AfterUninstall, AddressOf AfterUninstallEventHandler
   End Sub 'New

   Private Sub AfterUninstallEventHandler(sender As Object, e As InstallEventArgs)
      ' Add steps to perform any actions before the Uninstall process.
      Console.WriteLine("Code for AfterUninstallEventHandler")
   End Sub 'AfterUninstallEventHandler