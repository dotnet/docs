    // The Evaluate method is overridden to return the
    // DataValue property instead of the DefaultValue.
    protected override object Evaluate(HttpContext context, Control control) {

      if (context.Request == null)
          return null;

      return DataValue;
    }