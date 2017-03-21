        // Implement the TrackViewState method for this class by
        // calling the TrackViewState method of the class's private
        // _viewstate property.
        void IStateManager.TrackViewState()
        {
            ((IStateManager)_viewstate).TrackViewState();
        }