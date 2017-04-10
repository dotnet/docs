<!-- <Snippet2> -->
<%@ Register TagPrefix="aspSample" 
  Namespace="Samples.AspNet.vB.Controls" Assembly="Samples.AspNet.VB" %>
<%@ Page Language="VB" Trace="true" EnableViewState="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Label1.Text = IndexButton1.Index.ToString()
        Label2.Text = IndexButton1.IndexInViewState.ToString()
        IndexButton1.Index += 1
        IndexButton1.IndexInViewState += 1
    End Sub
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>IndexButton test page</title>
  </head>
  <body>
    <form id="form1" runat="server">
        Click the button:
        <aspSample:IndexButton Text="IndexButton" 
            ID="IndexButton1" runat="server"/>
      <br />
      <br />
      The value of the Index property of IndexButton is:<br />
      <asp:Label ID="Label1" Runat="server" Text="Label">
      </asp:Label>
      <br />
      <br />
      The value of the IndexInViewState property of IndexButton is:
      <br />
      <asp:Label ID="Label2" Runat="server" Text="Label">
      </asp:Label>
      <br />
    </form>
  </body>
</html>
<!-- </Snippet2> -->
