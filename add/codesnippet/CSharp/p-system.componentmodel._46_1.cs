        // Declare a new BindingListOfT with the Part business object.
        BindingList<Part> listOfParts; 
        private void InitializeListOfParts()
        {
            // Create the new BindingList of Part type.
            listOfParts = new BindingList<Part>();
    
            // Allow new parts to be added, but not removed once committed.        
            listOfParts.AllowNew = true;
            listOfParts.AllowRemove = false;

            // Raise ListChanged events when new parts are added.
            listOfParts.RaiseListChangedEvents = true;

            // Do not allow parts to be edited.
            listOfParts.AllowEdit = false;
            
            // Add a couple of parts to the list.
            listOfParts.Add(new Part("Widget", 1234));
            listOfParts.Add(new Part("Gadget", 5647));
        }