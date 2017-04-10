<!--<SNIPPET1>-->
<%@ Page Language="C#" %>
<%@ Register TagPrefix="verbsample" 
    namespace="Samples.AspNet.CS.Controls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:WebPartManager ID="WebPartManager1" runat="server" />
    <verbsample:ZoneWithAddedVerb id="ZoneWithAddedVerb1" 
      HeaderText="Zone with Added Verb" runat="server">
        <ZoneTemplate>
           <verbsample:SimpleControl id="SimpleControl1" 
            title="Simple Control" runat="server" /> 
        </ZoneTemplate>
        </verbsample:ZoneWithAddedVerb>
     </form>
</body>
</html>
<!--</SNIPPET1>-->