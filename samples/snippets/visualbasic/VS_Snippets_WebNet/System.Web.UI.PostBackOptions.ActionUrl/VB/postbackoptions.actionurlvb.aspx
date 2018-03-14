<!-- <snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  
  Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
    
    Dim reference As String = Page.ClientScript.GetPostBackEventReference _
      (New PostBackOptions(Me, "", "http://www.wingtiptoys.com", False, True, False, True, False, ""))
    Label1.Attributes.Add("onmouseover", reference)
    
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ActionUrl Example Page</title>
  </head>
  <body>
    <form id="form1" runat="server">
      <h3>PostBackOptions ActionUrl Example</h3>
      <asp:Label runat="server" 
        id="Label1" >
        Placing the mouse pointer on this label will cause a cross-page post to occur.
      </asp:Label>
    </form>
  </body>
</html>
<!-- </snippet1> -->
