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
  
  Private Const NewWarning As String = "If you delete this WebPart " & _
    "control instance, it will be permanently removed and " & _
    "cannot be retrieved.  Do you still want to delete it?"

  Protected Sub Button1_Click(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    
    mgr1.DeleteWarning = NewWarning

  End Sub
  
  Protected Sub Page_Load(ByVal sender As Object, _
    ByVal e As EventArgs)

    If WebPartZone1.WebParts.Count = 0 Then
      Button1.Visible = False
    Else
      Button1.Visible = True
    End If
    
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:WebPartManager ID="mgr1" runat="server" 
        DeleteWarning="Do you want to delete this control?" />
      <uc1:DisplayModeMenuVB ID="menu1" runat="server" />
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