<!-- <snippet1> -->
<%@ Page Language="VB" %>
<%@ Register Src="~/displayModeMenuVB.ascx" 
  TagPrefix="uc1" 
  TagName="DisplayModeMenuVB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
    Button1.Visible = False
    TextBox1.Visible = False
    BulletedList1.DataBind()
  End Sub

  ' <snippet3>
  Protected Sub Button1_Click(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    LayoutEditorPart1.Title = Server.HtmlEncode(TextBox1.Text)
  End Sub
  ' </snippet3>

  ' <snippet4>
  Protected Sub LayoutEditorPart1_PreRender(ByVal sender As Object, _
    ByVal e As System.EventArgs)
   
    Button1.Visible = True
    TextBox1.Visible = True
    
  End Sub
  ' </snippet4>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
  <form id="form1" runat="server">
    <!-- This example uses Microsoft SQL Server and connects    -->
    <!-- to the Pubs sample database. Use an ASP.NET expression -->
    <!-- like the one in the following control to retrieve the  -->
    <!-- connection string value from the Web.config file.      -->
    <asp:SqlDataSource ID="ds1" runat="server" 
      connectionString="<%$ ConnectionStrings:PubsConnection %>" 
      SelectCommand="Select au_id, au_lname, au_fname From Authors"/>
    <asp:WebPartManager ID="WebPartManager1" runat="server" />
    <uc1:DisplayModeMenuVB id="menu1" runat="server" />
    <asp:WebPartZone ID="WebPartZone1" runat="server" Width="150" 
      style="z-index: 100; left: 10px; position: absolute; top: 90px" >
      <ZoneTemplate>
        <asp:Panel ID="panel1" runat="server" Title="Author List WebPart">
          <asp:Label ID="Label1" runat="server" 
            Text="Author Names" 
            Font-Bold="true" 
            Font-Size="120%"
            AssociatedControlID="BulletedList1"/>
          <asp:BulletedList ID="BulletedList1" runat="server" 
            DataSourceID="ds1" 
            DataTextField="au_lname" 
            DataValueField="au_id"/>
        </asp:Panel>
      </ZoneTemplate>
    </asp:WebPartZone>
    <asp:WebPartZone ID="WebPartZone2" runat="server" Width="150" 
      style="z-index: 101; left: 170px; position: absolute; top: 90px" />
    <!-- <snippet2> -->
    <asp:EditorZone ID="EditorZone1" runat="server" 
      style="z-index: 102; left: 340px; position: absolute; top: 90px" 
      Width="170px">
      <ZoneTemplate>
        <asp:LayoutEditorPart ID="LayoutEditorPart1" runat="server" 
          Title="My Layout Editor" 
          OnPreRender="LayoutEditorPart1_PreRender" />
      </ZoneTemplate>
    </asp:EditorZone>
    <!-- </snippet2> -->
    <asp:Button ID="Button1" runat="server" Width="140" 
      Text="Update EditorPart Title" 
      style="left: 340px; position: absolute; top: 65px; z-index: 103;" 
      OnClick="Button1_Click" />
    <asp:TextBox ID="TextBox1" runat="server" 
      style="z-index: 105; left: 500px; position: absolute; top: 65px" />
  </form>
</body>
</html>
<!-- </snippet1> -->