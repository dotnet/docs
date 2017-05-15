<!-- <snippet1> -->
<%@ page language="c#" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuCS" 
  Src="DisplayModeMenuCS.ascx" %>
<%@ register tagprefix="aspSample" 
  Namespace="Samples.AspNet.CS.Controls" 
  Assembly="UserInfoWebPartCS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  protected void Page_Load(object sender, EventArgs e)
  {
    Button1.Visible = false;
    TextBox1.Visible = false;
  }

  // <snippet3>
  private static String editControlTitle;
  
  protected void Button1_Click(object sender, EventArgs e)
  {
    editControlTitle = Server.HtmlEncode(TextBox1.Text);
    PropertyGridEditorPart1.Title = editControlTitle;
  }

  protected void PropertyGridEditorPart1_Init(object sender, EventArgs e)
  {
    if (editControlTitle != null)
      PropertyGridEditorPart1.Title = editControlTitle;
  }  
  // </snippet3>

  // <snippet4>
  protected void PropertyGridEditorPart1_PreRender(object sender,
    EventArgs e)
  {
    Button1.Visible = true;
    TextBox1.Visible = true;
  }
  // </snippet4> 

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>
      User Information WebPart with EditorPart
    </title>
  </head>
  <body>
    <form id="form1" runat="server">
      <asp:webpartmanager id="WebPartManager1" runat="server"  />
      <uc1:DisplayModeMenuCS ID="DisplayModeMenu1" runat="server" />
      <asp:webpartzone id="zone1" runat="server" >
        <PartTitleStyle BorderWidth="1" 
          Font-Names="Verdana, Arial"
          Font-Size="110%"
          BackColor="LightBlue" />
        <zonetemplate>
          <aspSample:UserInfoWebPart 
            runat="server"   
            id="userinfo" 
            title = "User Information WebPart"
            BackColor="Beige" />          
        </zonetemplate>
      </asp:webpartzone> 
      <div>
      <hr />
      <asp:Button ID="Button1" runat="server" 
        Text="Update EditorPart Title" 
        OnClick="Button1_Click" />
      <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
      </div>
      <!-- <snippet2> -->
      <asp:EditorZone ID="EditorZone1" runat="server">
        <ZoneTemplate>
          <asp:PropertyGridEditorPart ID="PropertyGridEditorPart1" 
            runat="server" 
            Title="Edit Custom Properties"
            OnPreRender="PropertyGridEditorPart1_PreRender" 
            OnInit="PropertyGridEditorPart1_Init" />   
        </ZoneTemplate>
      </asp:EditorZone>
      <!-- </snippet2> --> 
    </form>
  </body>
</html>
<!-- </snippet1> -->