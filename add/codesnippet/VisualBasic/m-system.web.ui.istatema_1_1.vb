        ' Implement the SaveViewState method. If the StateBag
        ' that stores the MyItem class's view state contains
        ' a value for the message property and if the value
        ' has changed since the TrackViewState method was last 
        ' called, all view state for this class is deleted, 
        ' using the StateBag.Clear method,and the new value is added.
        Function SaveViewState() As Object Implements IStateManager.SaveViewState
            ' Check whether the message property exists in 
            ' the ViewState property, and if it does, check
            ' whether it has changed since the most recent
            ' TrackViewState method call.
            If Not CType(_viewstate, IDictionary).Contains("message") OrElse _viewstate.IsItemDirty("message") Then
                _viewstate.Clear()
                ' Add the _message property to the StateBag.
                _viewstate.Add("message", _message)
            End If
            Return CType(_viewstate, IStateManager).SaveViewState()
        End Function 'IStateManager.SaveViewState

