' Allows authorized user to change personalization scope.
Protected Sub Toggle_Scope_Button_Click(ByVal sender As Object, ByVal e As EventArgs) 
    If _manager.Personalization.CanEnterSharedScope Then
        _manager.Personalization.ToggleScope()
    End If

End Sub 'Toggle_Scope_Button_Click 