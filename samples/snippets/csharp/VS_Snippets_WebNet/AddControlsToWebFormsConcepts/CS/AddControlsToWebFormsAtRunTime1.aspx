<%@ Page Language="C#"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>How to: Add Controls to a Web Forms Page at Run Time</title>
</head>
<script runat="server">
 
//<Snippet1>          
private void Button1_Click(object sender, System.EventArgs e)
{  
      Button Button1 = new Button();

    if (ViewState["controlsadded"] == null)
    {
        AddControls();
    }
}

    protected override void LoadViewState(object savedState)
    {
        base.LoadViewState(savedState);
        if (ViewState["controlsadded"] ==(object) true)
        {
            AddControls();
        }
    }
    
    Panel Panel1 = new Panel();
    
    private void AddControls()
    {
        TextBox dynamictextbox = new TextBox();
        dynamictextbox.Text = "(Enter some text)";
        dynamictextbox.ID = "dynamictextbox";
        Button dynamicbutton = new Button();
        
        dynamicbutton.Click += new System.EventHandler(this.dynamicbutton_Click);

        dynamicbutton.Text = "Dynamic Button";
        Panel1.Controls.Add(dynamictextbox);
        Panel1.Controls.Add(new LiteralControl("<br /><br />"));
        Panel1.Controls.Add(dynamicbutton);
        ViewState["controlsadded"] = true;
    }
    
     void dynamicbutton_Click(object sender, System.EventArgs e)
    {
        TextBox tb = new TextBox();
        tb = (TextBox)(Panel1.FindControl("dynamictextbox"));
        Label1.Text = Server.HtmlEncode(tb.Text);
    }
    //</Snippet1> 
      
   </script>


<body>
    <form id="form1" runat="server">
    <div>
    
      <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
