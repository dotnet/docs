<!-- <snippet6> -->
<!-- The WebForms page that contains the user control generated
     by partialcache.cs. -->
<%@ Register TagPrefix="Acme" TagName="Cache" Src="partialcache.cs.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<script language="C#" runat="server">

      void Page_Load(Object Src, EventArgs E ) {

          TimeMsg.Text = DateTime.Now.ToString("G");
      }

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