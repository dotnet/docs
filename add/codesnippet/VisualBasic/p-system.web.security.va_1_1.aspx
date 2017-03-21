Public Sub Page_Load()
    AddHandler Membership.ValidatingPassword, _
    New MembershipValidatePasswordEventHandler(AddressOf OnValidatePassword)
End Sub

Public Sub OnValidatePassword(sender As Object, _
                               args As ValidatePasswordEventArgs)
  Dim r As System.Text.RegularExpressions.Regex =  _
    New System.Text.RegularExpressions.Regex("(?=.{6,})(?=(.*\d){1,})(?=(.*\W){1,})")
         

  If Not r.IsMatch(args.Password) Then
    args.FailureInformation = _
      New HttpException("Password must be at least 6 characters long and " & _
                        "contain at least one number and one special character.")
    args.Cancel = True
  End If
End Sub