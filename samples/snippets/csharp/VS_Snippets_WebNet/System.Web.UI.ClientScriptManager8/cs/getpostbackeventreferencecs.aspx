<!-- <Snippet1> -->
<%@ Page Language="C#"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  public class MyControl : Label, IPostBackEventHandler
  {

    // Use the constructor to defined default label text.
    public MyControl()
    {
      base.Text = "No postback raised.";
    }
    
    // Implement the RaisePostBackEvent method from the
    // IPostBackEventHandler interface. 
    public void RaisePostBackEvent(string eventArgument)
    {
      base.Text = "Postback handled by " + this.ID.ToString() + ". <br/>" +
                  "Postback caused by " + eventArgument.ToString() + ".";
      
    }
  }

  protected void Page_Load(object sender, EventArgs e)
  {
    // Get a ClientScriptManager reference from the Page class.
    ClientScriptManager cs = Page.ClientScript;

    // Create an instance of the custom label control and 
    // add it to the page.
    MyControl mycontrol = new MyControl();
    mycontrol.ID = "mycontrol1";
    PlaceHolder1.Controls.Add(mycontrol);
    PlaceHolder1.Controls.Add(new LiteralControl("<br/>"));
    
    // Create a button element with its onClick attribute defined
    // to create a postback event reference to the custom label control.
    HtmlInputButton b = new HtmlInputButton();
    b.ID = "mybutton1";
    b.Value = "Click";
    b.Attributes.Add("onclick", cs.GetPostBackEventReference(mycontrol, b.ID.ToString()));
    PlaceHolder1.Controls.Add(b);
    PlaceHolder1.Controls.Add(new LiteralControl("<br/>"));
    
    // Create a link element with its href attribute defined
    // to create a postback event reference to the custom label control.
    HtmlAnchor a = new HtmlAnchor();
    a.ID = "myanchor1";
    a.InnerText = "link";
    a.HRef = cs.GetPostBackClientHyperlink(mycontrol, a.ID.ToString());
    PlaceHolder1.Controls.Add(a);
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ClientScriptManager Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:PlaceHolder id="PlaceHolder1" 
                       runat="server">
      </asp:PlaceHolder>
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->