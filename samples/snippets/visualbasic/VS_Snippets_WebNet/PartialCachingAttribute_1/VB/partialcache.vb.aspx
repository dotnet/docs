<!-- <snippet6> -->
<!-- The WebForms page that contains the user control generated
     by partialcache.vb. -->
<%@ Register TagPrefix="Acme" TagName="Cache" Src="partialcache.vb.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<script language="vb" runat="server">

   Sub Page_Load(Src As [Object], E As EventArgs) 
      TimeMsg.Text = DateTime.Now.ToString("G")
   End Sub 'Page_Load

  </script>

<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
  
  <form id="form1" runat="server">
    <Acme:Cache runat="server"/>
    <br />

    <i>Page last generated on:</i> <asp:label id="TimeMsg" runat="server" />

  </form>
</body>
</html>
<!-- </snippet6> -->