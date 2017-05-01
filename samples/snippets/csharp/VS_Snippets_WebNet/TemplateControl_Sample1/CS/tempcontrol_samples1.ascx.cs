// <snippet1>
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;

// The custom user control class.
[AspNetHostingPermission(SecurityAction.Demand,
   Level = AspNetHostingPermissionLevel.Minimal)]
public class MyControl : UserControl
{
    // Create a Message property and accessors.
    private string _message = "No message";

    public string Message
    {
        get { return _message; }
        set { _message = value; }
    }

    //<Snippet2>
    // Create an event for this user control
    public event System.EventHandler myControl;

    // Override the default constructor.
    protected override void Construct()
    {
        // Specify the handler for the OnInit method.
        this.myControl += new EventHandler(MyInit);
    }

    protected override void OnInit(EventArgs e)
    {
        myControl(this, e);
        Response.Write("The OnInit() method is used to raise the Init event.");
    }

    // Use the MyInit handler to set the Message property
    void MyInit(object sender, System.EventArgs e)
    {
        Message = "Hello World!";
    }
    // </Snippet2>

    // Render the value of the Message property
    protected override void Render(HtmlTextWriter writer)
    {
        writer.Write("<br>Message :" + Message);
    }
}
// </Snippet1>
