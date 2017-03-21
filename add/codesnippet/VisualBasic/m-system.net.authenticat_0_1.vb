   ' This is the program entry point. It allows the user to enter 
   ' her credentials and the Internet resource (Web page) to access.
   ' It also unregisters the standard and registers the customized basic 
   ' authentication.
  Private Overloads Shared Sub Main(ByVal args() As String)

    If args.Length < 4 Then
      showusage()
    Else

      ' Read the user's credentials.
      uri = args(1)
      username = args(2)
      password = args(3)

      If args.Length = 4 Then
        domain = String.Empty
        ' If the domain exists, store it. Usually the domain name
        ' is by default the name of the server hosting the Internet
        ' resource.
      Else
        domain = args(5)
      End If
      ' Unregister the standard Basic authentication module.
      AuthenticationManager.Unregister("Basic")

      ' Instantiate the custom Basic authentication module.
      Dim customBasicModule As New CustomBasic()

      ' Register the custom Basic authentication module.
      AuthenticationManager.Register(customBasicModule)

      ' Display registered Authorization modules.
      displayRegisteredModules()

      ' Read the specified page and display it on the console.
      getPage(uri)
    End If
    Return
  End Sub 'Main
End Class 'ClientAuthentication 