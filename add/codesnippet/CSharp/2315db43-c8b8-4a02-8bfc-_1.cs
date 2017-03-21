    // The StaticParameter copy constructor is provided to ensure that
    // the state contained in the DataValue property is copied to new
    // instances of the class.
    protected StaticParameter(StaticParameter original) : base(original) {
      DataValue = original.DataValue;
    }

    // The Clone method is overridden to call the
    // StaticParameter copy constructor, so that the data in
    // the DataValue property is correctly transferred to the
    // new instance of the StaticParameter.
    protected override Parameter Clone() {
      return new StaticParameter(this);
    }