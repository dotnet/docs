// <snippet1>
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LookupBindingPropertiesAttributeDemo
{
    // <snippet2>
    // The DemoControl class shows properties 
    // used with lookup-based binding.
    [LookupBindingProperties(
        "DataSource", 
        "DisplayMember", 
        "ValueMember", 
        "LookupMember")]
    public class DemoControl : Control
    {   
    }
    // </snippet2>

    // <snippet3>
    // The DemoComboBox control shows a standard
    // combo box binding definition.
    [LookupBindingProperties(
        "DataSource", 
        "DisplayMember", 
        "ValueMember", 
        "SelectedValue")]
    public class DemoComboBox : Control
    {
    }
    // </snippet3>

    // <snippet4>
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
    // </snippet4>

    // <snippet5>
    // NonBindableCombo control shows how to unset the
    // LookupBindingProperties by specifying no arguments.
    [LookupBindingProperties()]
    public class NonBindableCombo : Control
    {
    }
    // </snippet5>
}
// </snippet1>