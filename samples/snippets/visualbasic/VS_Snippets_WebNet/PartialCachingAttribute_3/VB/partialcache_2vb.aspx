<!-- <snippet4> -->
<%@ Page Language="VB" %>
<%@ Register Src="partialcache_2vb.ascx" TagPrefix="Acme" TagName="Cache" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Sub Page_Load(ByVal Src As [Object], ByVal E As EventArgs)
        TimeMsg.Text = DateTime.Now.ToString("G")
    End Sub 'Page_Load
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
  
  <form id="Form1" runat="server">
    <Acme:Cache runat="server"/>
    <br />

    <i>Page last generated on:</i> <asp:label id="TimeMsg" runat="server" />

  </form>
</body>
</html>
<!-- </snippet4> -->