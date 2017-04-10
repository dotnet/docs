<!-- <snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html" />
  <title>Virtual Path Provider Example</title>
</head>
<body>
  <form id="form1" runat="server">
    <asp:HyperLink ID="hyperLink1" runat="server" NavigateUrl="vrDir/Level1FileA.vrf" Text="Level 1, File A" /><br />
    <asp:HyperLink ID="hyperLink2" runat="server" NavigateUrl="vrDir/Level1FileB.vrf" Text="Level 1, File B" /><br />
    <asp:HyperLink ID="hyperLink3" runat="server" NavigateUrl="vrDir/Level2DirA/Level2FileA.vrf" Text="Level 2a, File A" /><br />
    <asp:HyperLink ID="hyperLink4" runat="server" NavigateUrl="vrDir/Level2DirA/Level2FileB.vrf" Text="Level 2a, File B" /><br />
    <asp:HyperLink ID="hyperLink5" runat="server" NavigateUrl="vrDir/Level2DirB/Level2FileA.vrf" Text="Level 2b, File A" /><br />
    <asp:HyperLink ID="hyperLink6" runat="server" NavigateUrl="vrDir/Level2DirB/Level2FileB.vrf" Text="Level 2b, File B" /><br />
  </form>
</body>
</html>
<!-- </snippet1> -->