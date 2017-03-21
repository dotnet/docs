    private ICollection LoadControlProperties (string serializedProperties) {

        ICollection controlProperties = null;

        // Create an ObjectStateFormatter to deserialize the properties.
        ObjectStateFormatter formatter = new ObjectStateFormatter();

        // Call the Deserialize method.
        controlProperties = (ArrayList) formatter.Deserialize(serializedProperties);

        return controlProperties;
    }