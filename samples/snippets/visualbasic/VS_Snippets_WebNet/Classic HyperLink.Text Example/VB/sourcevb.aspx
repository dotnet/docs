<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>HyperLink Sample</title>
</head>
<body>
<form id="Form1" runat="server">

    <h3>HyperLink Sample</h3>

    Click on the HyperLink:<br />  

    <asp:HyperLink id="hyperlink1" 
                   NavigateUrl="http://www.microsoft.com"
                   Text="Microsoft Official Site"
                   Target="_new"
                   runat="server"/>       

</form>
</body>
</html>

<!--</Snippet1>-->
