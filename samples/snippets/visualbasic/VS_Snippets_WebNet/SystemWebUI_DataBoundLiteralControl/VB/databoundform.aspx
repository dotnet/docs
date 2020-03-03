<!-- <Snippet2> -->
<%@ Page Language="VB" %>
<%@ Register TagPrefix="MyControlSample" Namespace="Samples.AspNet.VB.Controls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>
      DataBoundLiteralControl Example
  </title>
<script language="VB" runat="server">
        Sub Page_Load(ByVal Sender As Object, ByVal e As EventArgs)
            Page.DataBind()
        End Sub
    </script>
  </head>
  <body>
  <h3>
      DataBoundLiteralControl Example
  </h3>
  <form method="post" runat="server" id="Form1">
    <asp:Label id="Label1" Text="This is a string retrieved from 'DataBoundLiteralControl'" Runat="server" Visible="False"></asp:Label>
    <MyControlSample:MyControlVB id="MyControl" runat="server">
        <%# Label1.Text %>
    </MyControlSample:MyControlVB>
  </form>
  </body>
</html>
<!-- </snippet2> -->