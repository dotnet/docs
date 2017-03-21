        // Implement the LoadViewState method. If the saved view state
        // exists, the view-state value is loaded to the MyItem control. 
        void IStateManager.LoadViewState(object savedState)
        {
            _message = (string)_viewstate["message"];
            if (savedState != null)
                ((IStateManager)_viewstate).LoadViewState(savedState);
        }