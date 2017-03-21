   ' MyInstaller is derived from the class 'Installer'.
   Sub New()
      MyBase.New()
      AddHandler AfterInstall, AddressOf AfterInstallEventHandler
   End Sub 'New

   Private Sub AfterInstallEventHandler(ByVal sender As Object, _
                                       ByVal e As InstallEventArgs)
      ' Add steps to perform any actions after the install process.
      Console.WriteLine("Code for AfterInstallEventHandler")
   End Sub 'AfterInstallEventHandler