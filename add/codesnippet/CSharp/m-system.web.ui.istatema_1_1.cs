        // Implement the SaveViewState method. If the StateBag
        // that stores the MyItem class's view state contains
        // a value for the message property and if the value
        // has changed since the TrackViewState method was last 
        // called, all view state for this class is deleted, 
        // using the StateBag.Clear method,and the new value is added.
        object IStateManager.SaveViewState()
        {
            // Check whether the message property exists in 
            // the ViewState property, and if it does, check
            // whether it has changed since the most recent
            // TrackViewState method call.
            if (!((IDictionary)_viewstate).Contains("message") || _viewstate.IsItemDirty("message"))
            {
                _viewstate.Clear();
                // Add the _message property to the StateBag.
                _viewstate.Add("message", _message);
            }
            return ((IStateManager)_viewstate).SaveViewState();
        }
