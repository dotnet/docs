<!-- <snippet1> -->
<%@ page language="VB" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuVB" 
  Src="DisplayModeMenuVB.ascx" %>
<%@ register tagprefix="aspSample" 
  Namespace="Samples.AspNet.VB.Controls" 
  Assembly="UserInfoWebPartVB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    Button1.Visible = False
    TextBox1.Visible = False
  End Sub

  ' <snippet3>
  Shared editControlTitle As String
  
  Protected Sub Button1_Click(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    editControlTitle = Server.HtmlEncode(TextBox1.Text)
    PropertyGridEditorPart1.Title = editControlTitle 
  End Sub
  
  Protected Sub PropertyGridEditorPart1_Init(ByVal _
    sender As Object, ByVal e As System.EventArgs)
    If Not editControlTitle Is Nothing Then
      PropertyGridEditorPart1.Title = editControlTitle
    End If
  End Sub
  ' </snippet3>

  ' <snippet4>
  Protected Sub PropertyGridEditorPart1_PreRender(ByVal _
    sender As Object, ByVal e As System.EventArgs)
    Button1.Visible = True
    TextBox1.Visible = True
  End Sub
  ' </snippet4>

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>
      User Information WebPart with EditorPart
    </title>
  </head>
  <body>
    <form id="form1" runat="server">
      <asp:webpartmanager id="WebPartManager1" runat="server"  />
      <uc1:DisplayModeMenuVB ID="DisplayModeMenu1" runat="server" />
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