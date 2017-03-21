   Public Sub New()
      MyBase.New()
      ' Attach the 'Committed' event.
      AddHandler Me.Committed, AddressOf MyInstaller_Committed
   End Sub 'New

   ' Event handler for 'Committed' event.
   Private Sub MyInstaller_Committed(ByVal sender As Object, ByVal e As InstallEventArgs)
      Console.WriteLine("")
      Console.WriteLine("Committed Event occured.")
      Console.WriteLine("")
   End Sub 'MyInstaller_Committed