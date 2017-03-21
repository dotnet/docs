    // The Value property is a type safe convenience property
    // used when the StaticParameter represents string data.
    // It gets the string value of the DataValue property, and
    // sets the DataValue property directly.
    public string Value {
      get {
        object o = DataValue;
        if (o == null || !(o is string))
          return String.Empty;
        return (string)o;
      }
      set {
        DataValue = value;
        OnParameterChanged();
      }
    }