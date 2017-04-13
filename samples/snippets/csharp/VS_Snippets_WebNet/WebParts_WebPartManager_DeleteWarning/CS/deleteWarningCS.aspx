<!-- <snippet1> -->
<%@ Page Language="C#" %>
<%@ Register TagPrefix="uc1" 
    TagName="DisplayModeMenuCS"
    Src="~/DisplayModeMenuCS.ascx" %>
<%@ Register TagPrefix="aspSample" 
    Namespace="Samples.AspNet.CS.Controls"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  const String NewWarning = @"If you delete this WebPart " + 
    "control instance, it will be permanently removed and " +
    "cannot be retrieved.  Do you still want to delete it?";
    
  protected void Button1_Click(object sender, EventArgs e)
  {
    mgr1.DeleteWarning = NewWarning;
  }

  // Hide the button to change the property when there is
  // no control available to delete.
  protected void Page_Load(object sender, EventArgs e)
  {
    if (WebPartZone1.WebParts.Count == 0)
      Button1.Visible = false;
    else
      Button1.Visible = true;
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:WebPartManager ID="mgr1" runat="server" 
        DeleteWarning="Do you want to delete this control?" />
      <uc1:DisplayModeMenuCS ID="menu1" runat="server" />
      <h2>Delete Warning Example Page</h2>
      <asp:WebPartZone ID="WebPartZone1" runat="server" />
      <asp:CatalogZone ID="CatalogZone1" runat="server">
        <ZoneTemplate>
          <asp:DeclarativeCatalogPart 
            ID="DeclarativeCatalogPart1" 
            runat="server">
            <WebPartsTemplate>
              <aspSample:TextDisplayWebPart ID="text1" 
                runat="server" 
                Title="My Text WebPart" />
             </WebPartsTemplate>
          </asp:DeclarativeCatalogPart>  
        </ZoneTemplate>
      </asp:CatalogZone>
      <asp:Button ID="Button1" runat="server" 
        Text="Change Delete Warning" 
        OnClick="Button1_Click" />
    </form>
</body>
</html>
<!-- </snippet1> -->