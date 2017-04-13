<!-- <snippet1> -->
<%@ Page Language="vb" %>
<%@ Register TagPrefix="uc1" 
    TagName="DisplayModeMenuVB"
    Src="~/DisplayModeMenuVB.ascx" %>
<%@ Register TagPrefix="aspSample" 
    Namespace="Samples.AspNet.VB.Controls"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  Protected Sub Button1_Click(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    
    mgr1.CloseWebPart(text1)

  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:WebPartManager ID="mgr1" runat="server" />
      <uc1:DisplayModeMenuVB ID="menu1" runat="server" />
      <asp:WebPartZone ID="WebPartZone1" runat="server">
        <ZoneTemplate>
          <aspSample:TextDisplayWebPart ID="text1" 
            runat="server" 
            Title="My Text WebPart" />
        </ZoneTemplate>
      </asp:WebPartZone>
      <asp:CatalogZone ID="CatalogZone1" runat="server">
        <ZoneTemplate>
          <asp:PageCatalogPart ID="PageCatalogPart1" runat="server" />   
        </ZoneTemplate>
      </asp:CatalogZone>
      <asp:Button ID="Button1" runat="server" 
        Text="Close WebPart" 
        OnClick="Button1_Click" />
    </form>
</body>
</html>
<!-- </snippet1> -->