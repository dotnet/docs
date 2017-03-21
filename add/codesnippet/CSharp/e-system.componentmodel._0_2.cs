        /* This is the OnSelectionChanged handler method.  This method calls
            OnUserChange to display a message that indicates the name of the
            handler that made the call and the type of the event argument. */
        private void OnSelectionChanged(object sender, EventArgs args) 
        {
            OnUserChange("OnSelectionChanged", args.ToString());
        }