// <snippet1>
using System;
using System.Web.UI;
using System.Web.UI.Adapters;

public class CustomControlAdapter : ControlAdapter
{
    // Override the ControlAdapter default OnInit implementation.
    protected override void OnInit (EventArgs e)
    {
        // Make the control invisible.
        Control.Visible = false;

        // Call the base method, which calls OnInit of the control,
        // which raises the control Init event.
        base.OnInit(e);
    }
}
// </snippet1>

public class MainClass
{
    public static void Main()
    {
    }
}     