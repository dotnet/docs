    // Apply the ServiceKnownTypeAttribute to the 
    // interface specifying the type to include. Apply 
    // the attribute more than once if needed.
    [ServiceKnownType(typeof(Widget))]
    [ServiceKnownType(typeof(Machine))]
    [ServiceContract()]
    public interface ICatalog2
    {
        // Any object type can be inserted into a Hashtable. The 
        // ServiceKnownTypeAttribute allows you to include those types
        // with the client code.
        [OperationContract]
        Hashtable GetItems();
    }