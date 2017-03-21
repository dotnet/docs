' Resets all of a user and shared personalization data for the page.
Protected Sub Reset_CurrentState_Button_Click(ByVal src As Object, ByVal e As EventArgs) 
    ' User must be authorized to modify state before a reset can occur.
    'When in user scope, all users by default can change their own data.
    If _manager.Personalization.IsModifiable Then
        _manager.Personalization.ResetPersonalizationState()
    End If

End Sub 'Reset_CurrentState_Button_Click
