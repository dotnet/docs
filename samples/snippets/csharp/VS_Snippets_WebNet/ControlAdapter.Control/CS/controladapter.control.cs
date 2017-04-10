// <snippet1>
using System;
using System.Web.UI;
using System.Web.UI.Adapters;
using System.Web.UI.WebControls;

public class CustomControl : Control
{
    // Add your custom control code.
}

public class CustomControlAdapter : ControlAdapter
{
    // Return a strongly-typed reference to your custom control.
    public new CustomControl Control
    {
        get
        {
            return (CustomControl)base.Control;
        }

        // Override other ControlAdapter members, as necessary. 
    }
}
// </snippet1>

public class MainClass
{
    public static void Main()
    {
    }
}
