    // The StaticParameter(string, TypeCode, object) constructor
    // initializes the DataValue property and calls the
    // Parameter(string, TypeCode) constructor to initialize the Name and
    // Type properties.
    public StaticParameter(string name, TypeCode type, object value) : base(name, type) {
      DataValue = value;
    }