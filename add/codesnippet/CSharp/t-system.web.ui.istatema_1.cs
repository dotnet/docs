    // Create a class that implements IStateManager so that
    // it can manage its own view state.   
    [AspNetHostingPermission(SecurityAction.Demand,
       Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class MyItem : IStateManager
    {
        private string _message;

        // The StateBag object that allows you to save
        // and restore view-state information.
        private StateBag _viewstate;

        // The constructor for the MyItem class.
        public MyItem(string mesg)
        {
            _message = mesg;
            _viewstate = new StateBag();
            _viewstate.Add("message", _message);
        }

        // Create a Message property that reads from and writes
        // to view state. If the set accessor writes the message
        // value to view state, the StateBag.SetItemDirty method
        // is called, telling view state that the item has changed. 
        public string Message
        {
            get
            {
                return (string)_viewstate["message"];
            }
            set
            {
                _message = value;
                _viewstate.SetItemDirty("message", true);
            }
        }

        // Implement the LoadViewState method. If the saved view state
        // exists, the view-state value is loaded to the MyItem control. 
        void IStateManager.LoadViewState(object savedState)
        {
            _message = (string)_viewstate["message"];
            if (savedState != null)
                ((IStateManager)_viewstate).LoadViewState(savedState);
        }

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


        // Implement the TrackViewState method for this class by
        // calling the TrackViewState method of the class's private
        // _viewstate property.
        void IStateManager.TrackViewState()
        {
            ((IStateManager)_viewstate).TrackViewState();
        }

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

        // Create a function that iterates through the view-state
        // values stored for this class and returns the
        // results as a string.
        public string EnumerateViewState()
        {
            string keyName, keyValue;
            string result = String.Empty;
            StateItem myStateItem;
            IDictionaryEnumerator myDictionaryEnumerator = _viewstate.GetEnumerator();
            while (myDictionaryEnumerator.MoveNext())
            {
                keyName = (string)myDictionaryEnumerator.Key;
                myStateItem = (StateItem)myDictionaryEnumerator.Value;
                keyValue = (string)myStateItem.Value;
                result = result + "<br>ViewState[" + keyName + "] = " + keyValue;
            }
            return result;
        }
    }