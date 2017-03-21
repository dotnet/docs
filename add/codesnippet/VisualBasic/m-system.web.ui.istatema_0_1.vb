        ' Implement the TrackViewState method for this class by
        ' calling the TrackViewState method of the class's private
        ' _viewstate property.
        Sub TrackViewState() Implements IStateManager.TrackViewState
            CType(_viewstate, IStateManager).TrackViewState()
        End Sub 'IStateManager.TrackViewState