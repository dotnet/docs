// <snippet1>
namespace Samples.AspNet {

  using System;
  using System.ComponentModel;
  using System.Security.Permissions;
  using System.Web;
  using System.Web.UI;
  using System.Web.UI.WebControls;

  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public class StaticParameter : Parameter {

    public StaticParameter() {
    }
// <snippet2>
    // The StaticParameter(string, object) constructor
    // initializes the DataValue property and calls the
    // Parameter(string) constructor to initialize the Name property.
    public StaticParameter(string name, object value) : base(name) {
      DataValue = value;
    }
// </snippet2>
// <snippet3>
    // The StaticParameter(string, TypeCode, object) constructor
    // initializes the DataValue property and calls the
    // Parameter(string, TypeCode) constructor to initialize the Name and
    // Type properties.
    public StaticParameter(string name, TypeCode type, object value) : base(name, type) {
      DataValue = value;
    }
// </snippet3>
// <snippet4>
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
// </snippet4>
// <snippet5>
    // The DataValue can be any arbitrary object and is stored in ViewState.
    public object DataValue {
      get {
        return ViewState["Value"];
      }
      set {
        ViewState["Value"] = value;
      }
    }
// </snippet5>
// <snippet7>
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
// </snippet7>

// <snippet6>
    // The Evaluate method is overridden to return the
    // DataValue property instead of the DefaultValue.
    protected override object Evaluate(HttpContext context, Control control) {

      if (context.Request == null)
          return null;

      return DataValue;
    }
// </snippet6>
  }
}
// </snippet1>