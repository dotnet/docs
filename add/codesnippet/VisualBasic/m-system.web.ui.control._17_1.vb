      Protected Overrides Function SaveViewState() As Object
         ' Change Text Property of Label when this function is invoked.
         If HasControls() And Page.IsPostBack Then
            CType(Controls(0), Label).Text = "Custom Control Has Saved State"
         End If
         ' Save State as a cumulative array of objects.
         Dim baseState As Object = MyBase.SaveViewState()
         Dim _userText As String = UserText
         Dim _passwordText As String = PasswordText
         Dim allStates(3) As Object
         allStates(0) = baseState
         allStates(1) = _userText
         allStates(2) = PasswordText
         Return allStates
      End Function