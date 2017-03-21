        ' Implement the LoadViewState method. If the saved view state
        ' exists, the view-state value is loaded to the MyItem 
        ' control. 
        Sub LoadViewState(ByVal savedState As Object) Implements IStateManager.LoadViewState
            _message = CStr(_viewstate("message"))
            If Not (savedState Is Nothing) Then
                CType(_viewstate, IStateManager).LoadViewState(savedState)
            End If
        End Sub 'LoadViewState