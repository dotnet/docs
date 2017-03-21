    // The DemoComboBox2 class shows that a control can
    // support both simple binding as well as list binding.
    [LookupBindingProperties(
        "DataSource", 
        "DisplayMember", 
        "ValueMember", 
        "SelectedValue")]
    [DefaultBindingProperty("Text")]
    public class DemoComboBox2 : Control 
    {
    }