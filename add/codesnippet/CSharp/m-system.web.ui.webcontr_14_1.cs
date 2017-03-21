    // The StaticParameter(string, object) constructor
    // initializes the DataValue property and calls the
    // Parameter(string) constructor to initialize the Name property.
    public StaticParameter(string name, object value) : base(name) {
      DataValue = value;
    }