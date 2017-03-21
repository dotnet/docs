      Dim myServiceInstaller As New ServiceInstaller()
      ' Check whether 'ServiceInstaller' object can handle the same 
      ' kind of installation as 'EventLogInstaller' object.
      If myEventLogInstaller.IsEquivalentInstaller(myServiceInstaller) Then
         Console.WriteLine("'ServiceInstaller' can handle the same kind" + _
                                    " of installation as EventLogInstaller")
      Else
         Console.WriteLine("'ServiceInstaller' can't handle the same" + _
                              " kind of installation as 'EventLogInstaller'")
      End If