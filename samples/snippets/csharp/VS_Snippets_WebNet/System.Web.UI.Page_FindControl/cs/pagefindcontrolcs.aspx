<!-- <Snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  private class RepeaterObject
  {
    private string _string;

    public RepeaterObject(string label)
    {
      _string = label;
    }

    public string RepeaterLabel
    {
      get { return _string; }
      set { _string = value; }
    }
  }

  protected void Page_Load()
  {
    if (!IsPostBack)
    {
      ArrayList al = new ArrayList();

      al.Add(new RepeaterObject("RepeaterObject1"));
      al.Add(new RepeaterObject("RepeaterObject2"));
      al.Add(new RepeaterObject("RepeaterObject3"));
      Repeater1.DataSource = al;
      Repeater2.DataSource = al;
      DataBind();
    }
  }


  // This occurs for Repeater1 and originates from LinkButton onClick.
  protected void OnMyCommand1(object sender, CommandEventArgs e)
  {
    LinkButton b = sender as LinkButton;
    if (b != null)
    {
      Label c = (Label)b.Parent.FindControl("Label1");
      if (c != null)
      {
        c.Text = "text changed in handler";
        c.ForeColor = System.Drawing.Color.Green;
      }
    }
  }

  // This occurs for Repeater2 and comes from the Repeater onItemCommand.
  protected void OnMyCommand2(object sender, RepeaterCommandEventArgs e)
  {
    Label l = (Label)e.Item.FindControl("Label1");
    if (l != null)
    {
      l.Text = "text changed in handler";
      l.ForeColor = System.Drawing.Color.Red;
    }
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Page FindControl Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <asp:Panel ID="Panel1" runat="server" >
        This repeater sample shows the bubbled event and FindControl when the repeater item OnCommand event occurs.<br />
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <asp:Label runat="server" ID="Label1" Text='<%#Eval("RepeaterLabel")%>' />&nbsp;
                <asp:LinkButton Text="Change" runat="server" OnCommand="OnMyCommand1" /> <br />
            </ItemTemplate>
        </asp:Repeater>
        <hr />

        This repeater shows the bubbled event and FindControl when the repeater OnItemCommand event occurs. <br />
        <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="OnMyCommand2">
            <ItemTemplate>
                <asp:Label runat="server" ID="Label1" Text='<%#Eval("RepeaterLabel")%>' />&nbsp;
                <asp:LinkButton Text="Change" runat="server" /> <br />
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>

    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->