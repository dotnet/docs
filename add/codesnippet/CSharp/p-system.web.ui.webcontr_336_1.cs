    // The DataValue can be any arbitrary object and is stored in ViewState.
    public object DataValue {
      get {
        return ViewState["Value"];
      }
      set {
        ViewState["Value"] = value;
      }
    }