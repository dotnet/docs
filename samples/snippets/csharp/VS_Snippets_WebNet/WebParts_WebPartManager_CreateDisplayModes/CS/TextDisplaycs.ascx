<!-- <snippet2> -->
<%@ Control Language="C#" %>
<%@ Import Namespace="Samples.AspNet.CS.Controls" %>
    
<script runat="server">
  private string textContent;

  [Personalizable]
  public string TextContent
  {
    get { return textContent; }
    set { textContent = value; }
  }

  protected override void OnPreRender(EventArgs e)
  {
    Label1.Text = this.textContent;
    int viewIndex = 0;

    WebPartManager wpmg = 
      WebPartManager.GetCurrentWebPartManager(this.Page);
    NewWebPartManager myNewWpmg = wpmg as NewWebPartManager;
    if (myNewWpmg != null)
    {
      WebPartDisplayMode mode = 
        myNewWpmg.SupportedDisplayModes[myNewWpmg.InLineEditDisplayMode.Name];
      if (mode != null && myNewWpmg.DisplayMode == mode)
      {
        viewIndex = 1;
      }
    }
    this.MultiView1.ActiveViewIndex = viewIndex;

  }

  protected void Button1_Click(object sender, EventArgs e)
  {
    this.TextContent = TextBox1.Text;

    WebPartManager wpmg = 
      WebPartManager.GetCurrentWebPartManager(this.Page);
    WebPartDisplayMode mode = 
      wpmg.SupportedDisplayModes[WebPartManager.BrowseDisplayMode.Name];
    if (mode != null)
      wpmg.DisplayMode = mode;
  }
  
</script>
<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Label" />
    </asp:View>
    <asp:View ID="View2" runat="server">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" OnClick="Button1_Click" 
          runat="server" Text="Button" />
    </asp:View>
</asp:MultiView>
<!-- </snippet2> -->