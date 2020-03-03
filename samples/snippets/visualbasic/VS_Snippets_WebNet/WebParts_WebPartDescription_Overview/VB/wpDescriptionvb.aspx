<!-- <snippet1> -->
<%@ Page Language="vb" %>
<%@ Register TagPrefix="uc1"
    TagName="DisplayModeMenuVB"
    Src="~/DisplayModeMenuVB.ascx" %>
<%@ Register TagPrefix="aspSample" 
    Namespace="Samples.AspNet.VB.Controls"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  ' <snippet2>
  Protected Sub Button1_Click(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    
    Label1.Text = String.Empty
        
    Dim descriptions As WebPartDescriptionCollection = _
     DeclarativeCatalogPart1.GetAvailableWebPartDescriptions()
            
    Dim desc As WebPartDescription
        
    For Each desc In descriptions
      Label1.Text += "ID: " & desc.ID & "<br />" & _
        "Title: " & desc.Title & "<br />" & _
        "Description: " & desc.Description & "<br />" & _
        "ImageUrl: " & desc.CatalogIconImageUrl & "<br />" & _
        "<hr />"
    Next
    
  End Sub
  ' </snippet2>

  Protected Sub Page_PreRender(ByVal sender As Object, _
    ByVal e As System.EventArgs)
        
    If mgr1.DisplayMode Is WebPartManager.CatalogDisplayMode Then
      Button1.Visible = True
      Label1.Visible = True
    Else
      Button1.Visible = False
      Label1.Visible = False
    End If
        
  End Sub


</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title>Untitled Page</title>
</head>
<body>
  <form id="form1" runat="server">
    <asp:WebPartManager ID="mgr1" runat="server">
    </asp:WebPartManager>
    <uc1:DisplayModeMenuVB ID="menu1" runat="server" />
    <asp:WebPartZone ID="WebPartZone1" runat="server">
      <ZoneTemplate>
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
      </ZoneTemplate>
    </asp:WebPartZone>
    <asp:CatalogZone ID="CatalogZone1" runat="server">
      <ZoneTemplate>
        <asp:DeclarativeCatalogPart ID="DeclarativeCatalogPart1" runat="server">
          <WebPartsTemplate>
            <aspSample:TextDisplayWebPart ID="txtDisplayWebPart1" runat="server"
              Title="Text Display"
              Description="Displays entered text in a label control."
              CatalogIconImageUrl="MyWebPartIcon.gif" 
              />
            <asp:BulletedList 
              ID="BulletedList1"
              Runat="server"
              DisplayMode="HyperLink" 
              Title="Favorite Links"
              CatalogIconImageUrl="MyLinksIcon.gif"
              Description="My Favorite Links">
              <asp:ListItem Value="http://msdn.microsoft.com">
                MSDN
              </asp:ListItem>
              <asp:ListItem Value="http://www.asp.net">
                ASP.NET
              </asp:ListItem>
              <asp:ListItem Value="http://www.msn.com">
                MSN
              </asp:ListItem>
            </asp:BulletedList>
          </WebPartsTemplate>
        </asp:DeclarativeCatalogPart>
      </ZoneTemplate>
    </asp:CatalogZone> 
    <hr />
    <asp:Button ID="Button1" runat="server" 
      Text="List WebPartDescription Info" OnClick="Button1_Click" /> 
    <br />
    <asp:Label ID="Label1" runat="server" Text="" />
    <div>
    </div>
  </form>
</body>
</html>
<!-- </snippet1> -->