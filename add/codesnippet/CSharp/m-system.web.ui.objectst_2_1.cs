
    ArrayList controlProperties = new ArrayList(3);

    controlProperties.Add( SortDirection );
    controlProperties.Add( SelectedColumn );
    controlProperties.Add( CurrentPage.ToString() );

    // Create an ObjectStateFormatter to serialize the ArrayList.
    ObjectStateFormatter formatter = new ObjectStateFormatter();

    // Call the Serialize method to serialize the ArrayList to a Base64 encoded string.
    string base64StateString = formatter.Serialize(controlProperties);