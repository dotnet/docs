        // Implement the IsTrackingViewState method for this class 
        // by calling the IsTrackingViewState method of the class's
        // private _viewstate property. 
        bool IStateManager.IsTrackingViewState
        {
            get
            {
                return ((IStateManager)_viewstate).IsTrackingViewState;
            }
        }