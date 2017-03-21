    ' Create a class that implements IStateManager so that
    ' it can manage its own view state.   

    <AspNetHostingPermission(SecurityAction.Demand, _
       Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class MyItem
        Implements IStateManager
        Private _message As String

        ' The StateBag object that allows you to save
        ' and restore view-state information.
        Private _viewstate As StateBag


        ' The constructor for the MyItem class.
        Public Sub New(ByVal mesg As String)
            _message = mesg
            _viewstate = New StateBag()
            _viewstate.Add("message", _message)
        End Sub 'New

        ' Create a Message property that reads from and writes
        ' to view state. If the set accessor writes the message
        ' value to view state, the StateBag.SetItemDirty method
        ' is called, telling view state that the item has changed. 

        Public Property Message() As String
            Get
                Return CStr(_viewstate("message"))
            End Get
            Set(ByVal value As String)
                _message = value
                _viewstate.SetItemDirty("message", True)
            End Set
        End Property

        ' Implement the LoadViewState method. If the saved view state
        ' exists, the view-state value is loaded to the MyItem 
        ' control. 
        Sub LoadViewState(ByVal savedState As Object) Implements IStateManager.LoadViewState
            _message = CStr(_viewstate("message"))
            If Not (savedState Is Nothing) Then
                CType(_viewstate, IStateManager).LoadViewState(savedState)
            End If
        End Sub 'LoadViewState
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


        ' Implement the TrackViewState method for this class by
        ' calling the TrackViewState method of the class's private
        ' _viewstate property.
        Sub TrackViewState() Implements IStateManager.TrackViewState
            CType(_viewstate, IStateManager).TrackViewState()
        End Sub 'IStateManager.TrackViewState
        ' Implement the IsTrackingViewState method for this class 
        ' by calling the IsTrackingViewState method of the class's
        ' private _viewstate property. 

        ReadOnly Property IsTrackingViewState() As Boolean Implements IStateManager.IsTrackingViewState
            Get
                Return CType(_viewstate, IStateManager).IsTrackingViewState
            End Get
        End Property

        ' Create a function that iterates through the view-state
        ' values stored for this class and returns the
        ' results as a string.
        Public Function EnumerateViewState() As String
            Dim keyName, keyValue As String
            Dim result As String = [String].Empty
            Dim myStateItem As StateItem
            Dim myDictionaryEnumerator As IDictionaryEnumerator = _viewstate.GetEnumerator()
            While myDictionaryEnumerator.MoveNext()
                keyName = CStr(myDictionaryEnumerator.Key)
                myStateItem = CType(myDictionaryEnumerator.Value, StateItem)
                keyValue = CStr(myStateItem.Value)
                result = result + "<br>ViewState[" + keyName + "] = " + keyValue
            End While
            Return result
        End Function 'EnumerateViewState
    End Class 'MyItem 