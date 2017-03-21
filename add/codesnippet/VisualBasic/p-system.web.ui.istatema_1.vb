        ' Implement the IsTrackingViewState method for this class 
        ' by calling the IsTrackingViewState method of the class's
        ' private _viewstate property. 

        ReadOnly Property IsTrackingViewState() As Boolean Implements IStateManager.IsTrackingViewState
            Get
                Return CType(_viewstate, IStateManager).IsTrackingViewState
            End Get
        End Property
