      Protected Overrides Sub LoadViewState(savedState As Object)
         If Not (savedState Is Nothing) Then
            ' Load State from the array of objects that was saved at ;
            ' SavedViewState.
            Dim myState As Object() = CType(savedState, Object())
            If Not (myState(0) Is Nothing) Then
               MyBase.LoadViewState(myState(0))
            End If
            If Not (myState(1) Is Nothing) Then
               UserText = CStr(myState(1))
            End If
            If Not (myState(2) Is Nothing) Then
               PasswordText = CStr(myState(2))
            End If
         End If
      End Sub